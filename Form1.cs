using System.ComponentModel;
using System.Configuration;
using DapperWork;
using DapperCrud.Models;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;
using ToastNotification;
using System.Text.RegularExpressions;
using System.Diagnostics.Metrics;
using CliWrap;
using System.Diagnostics;
using Markdig;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Extensions.Configuration;

namespace ProjectDiary;

public partial class Form1 : Form
{

    List<Catalog> catalogList = null;

    BindingList<Catalog> bindingList;

    public List<String> hashTags = new List<string>();

    //const string XYplorer = @"C:\Program Files (x86)\XYplorer\XYplorer.exe";
    const string XYplorer = "explorer";

    string locationsFile;

    public string selectedTagsFromTagForm;

    private Catalog currentCatalog;

    private FavoritesManager favoritesManager;

    private bool isControlPressed = false;

    Repository repo;

    int currentGridRowIndex = 0;

    public Form1()
    {
        InitializeComponent();

        DapperConnectionProvider dapperProvider = new(Program.Configuration);

        repo = new Repository(dapperProvider);

        this.Text = System.Configuration.ConfigurationManager.AppSettings["version_number"];

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;

        datagridviewLocations.AutoGenerateColumns = false;

        favoritesManager = new FavoritesManager(this);

        // Overlay add and update buttons (only one shows at a time).
        panelAddButtons.Location = panelUpdateButtons.Location;

        this.KeyPreview = true; // Ensure the form receives key events
    }


    public async Task updateLocation(Catalog catalog)
    {
        if (catalog.id == 0)
        {
            showToast("Something weird here!",
                    $"Trying to update with a zero id",
                    Toast.ToastPosition.LOWER_LEFT,
                    Toast.ToastDuration.MEDIUM,
                    Toast.ToastStatus.ERROR,
                    true);
            // MessageBox.Show($"Something weird here! It's trying to update with a zero id");
        }

        var results = await repo.Upsert<Catalog>(catalog);
        showToast("Update successful",
                    $"{catalog.ShortName} updated",
                    Toast.ToastPosition.LOWER_LEFT,
                    Toast.ToastDuration.SHORT,
                    Toast.ToastStatus.SUCCESS,
                    true);
    }

    public async Task deleteCatalog(Catalog catalog)
    {
        //MessageBox.Show("location deleted");
        await repo.Delete<Catalog>(catalog);

        //showToast("Delete successful",
        //            $"{catalog.ShortName} deleted",
        //            Toast.ToastPosition.LOWER_LEFT,
        //            Toast.ToastDuration.SHORT,
        //            Toast.ToastStatus.SUCCESS,
        //            true);

    }

    public async Task ddaddLocation(Catalog catalog)
    {
        var testObj = await repo.GetCatalogByLocation(catalog.Location);
        if (testObj is null)
        {
        }
        else
        {
            MessageBox.Show($"Something weird here! It's trying to add a duplicate location: {catalog.Location}");
        }

        var results = await repo.Upsert<Catalog>(catalog);
    }

    public async void OnFavoriteClicked(object sender, EventArgs e)
    {
        // The menu option tag is the LocationObject.Location.
        ToolStripMenuItem mi = (ToolStripMenuItem)sender;
        selectRowWithLocation(mi.Tag.ToString());

        Catalog cat = await repo.GetCatalogByLocation(mi.Tag.ToString());

        currentCatalog = cat;
        await refreshDetailPanel();
    }

    private async Task clearFilter()
    {
        if (linklabelFilter.Text == "Filter") return;

        string savedLocation = currentCatalog.Location;

        catalogList = catalogList.OrderByDescending(o => o.Dateadded).ToList();
        bindingList = new BindingList<Catalog>(catalogList);
        datagridviewLocations.DataSource = bindingList;

        selectRowWithLocation(savedLocation);
        currentCatalog = getCatalogObjectByLocation(savedLocation);

        linklabelFilter.Text = "Filter";
        textboxFilter.Text = "";
        //linklabelFilter.Left = linklabelFilter.Left + 50;

        await refreshDetailPanel();
    }

    private async void setFilter(string searchValue)
    {
        searchValue = searchValue.Trim();

        List<Catalog> filteredList;

        if (searchValue.StartsWith("#"))
        {
            filteredList = await repo.SearchForTags(searchValue);
        }
        else
        {
            filteredList = await repo.SearchCatalogRows(searchValue);
        }

        if (filteredList.Count > 0)
        {
            bindingList = new BindingList<Catalog>(filteredList);
            datagridviewLocations.DataSource = bindingList;
        }
        else
        {
            showToast("Search failed",
                      $"No search results for {searchValue}",
                      Toast.ToastPosition.UPPER_RIGHT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.INFO,
                      true);
        }
    }

    private void showToast(string header,
                           string message,
                           Toast.ToastPosition position,
                           Toast.ToastDuration duration,
                           Toast.ToastStatus status,
                           bool userClose = true)
    {
        Toast frm;
        frm = new Toast(this);
        frm.Opacity = 0;

        // frm.ChangeDefaultDurationSeconds(4000, 4000, 4000, 4000);

        frm.HeaderText = header;
        frm.MessageText = message;
        frm.Position = position;
        frm.Duration = duration;
        frm.Status = status;
        frm.HideUserCloseButton = false;
        frm.StayOnTop = true;

        frm.ShowToast();
    }

    private async Task readSavedLocations(bool byDate = true)
    {
        List<Catalog> results;

        if (byDate) results = await repo.GetAllCatalogRowsByDateAdded();
        else results = await repo.GetAllCatalogRowsByShortName();

        catalogList = results.ToList();

        //foreach (var item in catalogList)
        //{
        //    item.ShortName = item.ShortName + " |  " + item.Tags;
        //}

        favoritesManager.AddFavoritesToMenu(catalogList);

        bindingList = new BindingList<Catalog>(catalogList);
        datagridviewLocations.DataSource = bindingList;

        GetHashTags();

        linklabelFilter.Text = "Filter";
        textboxFilter.Text = "";
    }

    private async void saveLocations()
    {
        await clearFilter();
    }

    public async void GetHashTags()
    {
        hashTags = await repo.GetUniqueTags();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        
       string? vs = config["visual_studio"] ?? null;

 
        textboxFilter.Select();

        await readSavedLocations(true);
    }

    private Catalog getCatalogObjectByLocation(string location)
    {
        Catalog loc = catalogList.SingleOrDefault(loc => loc.Location == location);
        return loc;
    }

    private async Task refreshDetailPanel()
    {
        Catalog loc = await repo.GetCatalogByLocation(currentCatalog.Location);

        textboxDescription.Text = currentCatalog.Description;
        textboxHashtags.Text = currentCatalog.Tags;
        textboxName.Text = loc.ShortName;
        //textboxName.Text = currentCatalog.ShortName;
        textboxLocation.Text = currentCatalog.Location;
        textboxUrl.Text = currentCatalog.Url;
    }

    private async void datagridviewLocations_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
        currentGridRowIndex = e.RowIndex;

        string location = datagridviewLocations.Rows[e.RowIndex].Cells["col_Location"].FormattedValue.ToString();
        currentCatalog = getCatalogObjectByLocation(location);

        await refreshDetailPanel();
    }

    private void toggleReadOnlyStatus()
    {
        textboxDescription.ReadOnly = !textboxDescription.ReadOnly;
        textboxHashtags.ReadOnly = !textboxHashtags.ReadOnly;
        textboxName.ReadOnly = !textboxName.ReadOnly;
        textboxLocation.ReadOnly = !textboxLocation.ReadOnly;
        textboxUrl.ReadOnly = !textboxUrl.ReadOnly;

        if (linklabelUpdateMode.Tag.ToString() == "enable")
        {
            textboxName.Focus();
            linklabelUpdateMode.Text = "Cancel update";
            linklabelUpdateMode.Tag = "disable";
            buttonUpdate.Enabled = true;
            textboxDescription.BackColor = Color.WhiteSmoke;
            textboxHashtags.BackColor = Color.WhiteSmoke;
            textboxName.BackColor = Color.WhiteSmoke;
            textboxLocation.BackColor = Color.WhiteSmoke;
            textboxUrl.BackColor = Color.WhiteSmoke;
            textboxDescription.TabStop = true;
            textboxHashtags.TabStop = true;
            textboxName.TabStop = true;
            textboxLocation.TabStop = true;
            textboxUrl.TabStop = true;

            datagridviewLocations.Enabled = false;
            linklabelFilter.Enabled = false;

            buttonUpdate.BackColor = Color.ForestGreen;
            buttonUpdate.ForeColor = Color.WhiteSmoke;
        }
        else
        {
            // This is the cancel update action.

            linklabelUpdateMode.Text = "Enable update";
            linklabelUpdateMode.Tag = "enable";

            buttonUpdate.Enabled = false;
            textboxDescription.BackColor = Color.LightGoldenrodYellow;
            textboxHashtags.BackColor = Color.LightGoldenrodYellow;
            textboxName.BackColor = Color.LightGoldenrodYellow;
            textboxLocation.BackColor = Color.LightGoldenrodYellow;
            textboxUrl.BackColor = Color.LightGoldenrodYellow;

            textboxDescription.TabStop = false;
            textboxHashtags.TabStop = false;
            textboxName.TabStop = false;
            textboxLocation.TabStop = false;
            textboxUrl.TabStop = false;

            datagridviewLocations.Enabled = true;
            linklabelFilter.Enabled = true;

            buttonUpdate.BackColor = Color.LightBlue;
            buttonUpdate.ForeColor = Color.Black;
        }
    }

    private Catalog IsCatalogRegistered(string newLocation)
    {
        var existingCatalog = catalogList.SingleOrDefault(loc => loc.Location == newLocation);

        return existingCatalog;
        //return existingLocation != null;
    }

    private void buttonAddOrUpdate_Click(object sender, EventArgs e)
    {
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop) ||
               e.Data.GetDataPresent(DataFormats.Text) ||
               e.Data.GetDataPresent(DataFormats.UnicodeText))
        {
            e.Effect = DragDropEffects.Copy;
        }


        //if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        ItemDroppedForAdd(e);
    }

    private async void ItemDroppedForAdd(DragEventArgs e)
    {
        if (linklabelFilter.Text != "Filter")
        {
            await clearFilter();
        }

        bool singleItem = true;
        string draggedItem = "";

        //if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        //    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        //    file = files[0];
        //}

        //if (e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.UnicodeText))
        //{
        //    string url = (string)e.Data.GetData(DataFormats.Text);
        //    file = url;
        //}

        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            draggedItem = files[0];
            singleItem = true;
        }
        else if (e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.UnicodeText))
        {
            string text = (string)e.Data.GetData(DataFormats.Text);
            draggedItem = text;

            singleItem = draggedItem.ToLower().StartsWith("http");
        }

        Catalog existingCatalog = IsCatalogRegistered(draggedItem);
        if (existingCatalog is not null)
        {
            selectRowWithLocation(existingCatalog.Location);
            currentCatalog = existingCatalog;
            await refreshDetailPanel();

            showToast("Location aleady exists",
                      $"That location has been made the current location",
                      Toast.ToastPosition.LOWER_LEFT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.INFO);

            return;
        }

        showToast("Adding a new item",
                  "Enter necessary info and click 'Add'",
                  Toast.ToastPosition.LOWER_LEFT,
                  Toast.ToastDuration.SHORT,
                  Toast.ToastStatus.INFO);

        setAddItemMode();

        if (singleItem)
        {
            textboxLocation.Text = draggedItem;
        }
        else
        {
            textboxDescription.Text = draggedItem;
        }
    }

    private void setAddItemMode()
    {
        textboxDescription.Text = "";
        textboxHashtags.Text = "";
        textboxName.Text = "";
        textboxUrl.Text = "";
        textboxLocation.Text = "";

        toggleReadOnlyStatus();

        toggleAddUpdatePanels();

        panelAddButtons.Visible = true;
        buttonAdd.Visible = true;

        textboxName.Focus();
    }

    private void toggleAddUpdatePanels()
    {
        panelAddButtons.Left = panelUpdateButtons.Left;
        panelAddButtons.Top = panelUpdateButtons.Top;

        panelUpdateButtons.Visible = !panelUpdateButtons.Visible;
        panelAddButtons.Visible = !panelAddButtons.Visible;
    }

    private void linklabelUpdateMode_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
    {
        //if (linklabelFilter.Text != "Filter")
        //{
        //    showToast("Clear filter first",
        //              $"Clear filter before updating a location",
        //              Toast.ToastPosition.LOWER_LEFT,
        //              Toast.ToastDuration.SHORT,
        //              Toast.ToastStatus.INFO);
        //    return;
        //}

        LinkLabel lbl = (LinkLabel)sender;

        if (lbl.Text.ToLower().Contains("cancel"))
        {
            buttonUpdate.Visible = false;
        }
        else
        {
            buttonUpdate.Visible = true;
        }

        toggleReadOnlyStatus();
    }


    private void updateRowDisplay()
    {
        DataGridViewRow row = datagridviewLocations.Rows[currentGridRowIndex];

        row.Cells["colShortName"].Value = textboxName.Text;
        row.Cells["tags"].Value = textboxHashtags.Text;
    }

    private async void buttonUpdate_Click(object sender, EventArgs e)
    {
        if (!validateInput()) return;

        // Update operation.
        if (buttonUpdate.Tag.ToString() == "update")
        {
            currentCatalog.Description = textboxDescription.Text;
            currentCatalog.Tags = textboxHashtags.Text;
            currentCatalog.ShortName = textboxName.Text;
            currentCatalog.Location = textboxLocation.Text;
            currentCatalog.Url = textboxUrl.Text;

            toggleReadOnlyStatus();

            updateRowDisplay();

            await updateLocation(currentCatalog);

            buttonUpdate.BackColor = Color.LightBlue;
            buttonUpdate.ForeColor = Color.Black;
            buttonUpdate.Visible = false;
        }
    }

    private async void ddddlinklabelCancelAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        linklabelUpdateMode.Tag = "disable";
        toggleReadOnlyStatus();

        toggleAddUpdatePanels();

        LinkLabel lbl = (LinkLabel)sender;

        if (lbl.Text.ToLower().Contains("cancel"))
        {
            buttonAdd.Visible = false;
        }
        else
        {
            buttonAdd.Visible = true;
        }


        await refreshDetailPanel();

        buttonUpdate.BackColor = Color.LightBlue;
        buttonUpdate.ForeColor = Color.Black;
    }

    private void textboxHashtags_Click(object sender, EventArgs e)
    {
        getTagsFromDialog();
    }

    private void getTagsFromDialog()
    {
        if (textboxHashtags.ReadOnly) return;

        GetHashTags();

        List<String> ht = hashTags;

        FormTags ft = new FormTags(this);
        ft.Top = this.Top + 240;
        ft.Left = this.Left + panel1.Width + 60;

        if (ft.ShowDialog() == DialogResult.OK)
        {
            textboxHashtags.Text = selectedTagsFromTagForm;
            textboxDescription.Focus();
        }
        else
        {
            //textboxHashtags.Text = "";
        }
    }

    public void selectRowWithLocation(string targetPath)
    {
        foreach (DataGridViewRow row in datagridviewLocations.Rows)
        {
            row.Selected = false;
        }

        foreach (DataGridViewRow row in datagridviewLocations.Rows)
        {
            string location = row.Cells["col_Location"].FormattedValue.ToString();
            if (location == targetPath)
            {
                row.Selected = true;
                // Bring selected row into view. 
                datagridviewLocations.FirstDisplayedScrollingRowIndex = datagridviewLocations.SelectedRows[0].Index;
                return;
            }
        }
    }

    private async Task processMarkdownFile(string filename)
    {

        if (!Path.Exists(filename))
        {
            showToast("Markdown file not found",
                $"This location can't be found: {filename}",
                Toast.ToastPosition.LOWER_LEFT,
                Toast.ToastDuration.SHORT,
                Toast.ToastStatus.ERROR,
                true);
            return;
        }

        string exePath = AppDomain.CurrentDomain.BaseDirectory;
        string htmlTemplateFile = Path.Join(exePath, "template.html");

        if (!Path.Exists(htmlTemplateFile))
        {
            showToast("HTML template file not found",
                $"This location can't be found: {htmlTemplateFile}",
                Toast.ToastPosition.LOWER_LEFT,
                Toast.ToastDuration.SHORT,
                Toast.ToastStatus.ERROR,
                true);
            return;
        }

        string htmlTemplate = File.ReadAllText(htmlTemplateFile);

        const string CHROME = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        string markdown = File.ReadAllText(filename);
        string htmlFromMarkdown = Markdown.ToHtml(markdown, pipeline);

        string fullHtml = htmlTemplate.Replace("{html}", htmlFromMarkdown).Replace("{title}", currentCatalog.ShortName);

        var tempFilePath = Path.Combine(Path.GetTempPath(), "text.html");
        File.WriteAllText(tempFilePath, fullHtml);

        await launcher(CHROME, tempFilePath);
    }

    private async Task launchProcess(string location)
    {
        const string CHROME = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        const string NOTEPAD = @"C:\Program Files\Notepad++\notepad++.exe";
        const string VISUAL_STUDIO = @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe";
        const string EXPLORER = "explorer";

        string[] notePadExtensions = new string[] { ".txt", ".cs" };

        bool found = false;

        string extension = Path.GetExtension(location.ToLower());
        if (notePadExtensions.Contains(extension))
        {
            if (File.Exists(location))
            {
                await launcher(NOTEPAD, location);
                return;
            }
        }

        string target;

        switch (extension.ToLower())
        {
            case ".sln":
                if (File.Exists(location))
                {
                    target = "\"" + location + "\"";
                    await launcher(VISUAL_STUDIO, target);
                    found = true;
                }
                break;

            case ".exe":
                target = "\"" + location + "\"";
                await launcher(target);
                found = true;
                return;

            case ".pdf":
                target = "\"" + location + "\"";
                await launcher(CHROME, target);
                found = true;
                break;

            case ".md":
                target = "\"" + location + "\"";
                await processMarkdownFile(target);
                found = true;
                break;
        }
        if (found) return;

        if (location.ToLower().StartsWith("http") || location.ToLower().EndsWith(".html"))
        {
            await launcher(CHROME, location);
            found = true;
            return;
        }
        if (found) return;

        if (Path.Exists(location))
        {
            // Launch PowerShell terminal and run PowerShell script.
            string ext = Path.GetExtension(location.ToLower());
            if (ext == ".ps1")
            {
                string dir = Path.GetDirectoryName(location);
                string cmdline = @"& {Start-Process powershell -WorkingDirectory '[dir]' -ArgumentList  '-NoExit -File """"[location]""""'}";
                cmdline = cmdline.Replace("[location]", location).Replace("[dir]", dir);

                List<string> args = new();
                args.Add("-Command");
                args.Add(cmdline);
                await launcher("powershell.exe", args);
            }
            // Launch PowerShell terminal.
            else
            {
                string args = @" -ExecutionPolicy Bypass -Command ""Start-Process PowerShell.exe -WorkingDirectory '[location]'""";
                args = args.Replace("[location]", location);
            }
        }
        else
        {
            showToast("Search failed",
                      $"This location can't be processed: {location}",
                      Toast.ToastPosition.LOWER_LEFT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.ERROR,
                      true);
        }
    }

    private async Task launcher(string command, List<string> arguments)
    {
        var result = await CliWrap.Cli.Wrap(command)
            .WithArguments(arguments)
            .WithValidation(CliWrap.CommandResultValidation.None)
            .ExecuteAsync();
    }


    private async Task launcher(string command, string argument = "")
    {
        var result = await CliWrap.Cli.Wrap(command)
            .WithArguments(argument)
            .WithValidation(CliWrap.CommandResultValidation.None)
            .ExecuteAsync();
    }




    private async void linklabelOpenLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        await LaunchLocationOrReference(currentCatalog.Location);

        //FileAttributes attr = File.GetAttributes(currentCatalog.Location);

        //if (Control.ModifierKeys == Keys.Control)
        //{
        //    string folder = Path.GetDirectoryName(currentCatalog.Location);

        //    attr = File.GetAttributes(folder);

        //    if (attr.HasFlag(FileAttributes.Directory))
        //    {
        //        await launcher("explorer", folder);
        //        return;
        //    }
        //}

        //attr = File.GetAttributes(currentCatalog.Location);


        //if (attr.HasFlag(FileAttributes.Directory))
        //{
        //    await launcher("explorer", currentCatalog.Location);
        //}
        //else
        //{
        //    await launchProcess(currentCatalog.Location);
        //}
    }


    private async Task LaunchLocationOrReference(string commandLine)
    {
        FileAttributes attr;

        if (Control.ModifierKeys == Keys.Control)
        {
            string folder = Path.GetDirectoryName(commandLine);

            attr = File.GetAttributes(folder);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                await launcher("explorer", folder);
                return;
            }
        }

        try
        {
            attr = File.GetAttributes(commandLine);
            if (attr.HasFlag(FileAttributes.Directory))
            {
                await launcher("explorer", commandLine);
            }
            else
            {
                //await launchProcess(commandLine);
            }
        }
        catch (Exception ex)
        {
        }

        await launchProcess(commandLine);
    }



    private void linklabelFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        toggleFilter();
    }

    private async void toggleFilter()
    {
        if (linklabelFilter.Text == "Filter")
        {
            if (string.IsNullOrEmpty(textboxFilter.Text)) return;

            setFilter(textboxFilter.Text);
            linklabelFilter.Text = "Clear filter";
            linklabelFilter.Left = linklabelFilter.Left - 50;
        }
        else
        {
            await clearFilter();
        }
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized)
        {
            Hide();
            notifyIcon1.Visible = true;
        }
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        Show();
        this.WindowState = FormWindowState.Normal;
        notifyIcon1.Visible = false;
    }

    private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        //await launchProcess(textboxUrl.Text);
        await LaunchLocationOrReference(textboxUrl.Text);
    }

    private void validateLocations()
    {
        foreach (DataGridViewRow row in datagridviewLocations.Rows)
        {
            string location = row.Cells["col_Location"].FormattedValue.ToString();
            if (!Directory.Exists(location) && !File.Exists(location))
            {
                row.Cells["col_flagged"].Value = "*";
            }
        }
    }

    private void validateLocationsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        validateLocations();
    }


    private void textboxHashtags_KeyDown(object sender, KeyEventArgs e)
    {
        getTagsFromDialog();
    }

    private async void manageFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // getItemsText();
        List<string> itemsText;

        itemsText = favoritesManager.GetItemsText();

        FormFavorites f = new FormFavorites(itemsText);

        var result = f.ShowDialog();
        if (result == DialogResult.OK)
        {
            Dictionary<string, string> itemsDict = favoritesManager.GetItemsDictionary();

            foreach (KeyValuePair<string, string> entry in itemsDict)
            {
                favoritesManager.DeleteFavoriteFromMenu(entry.Key);
            }

            foreach (var item in itemsText)
            {
                favoritesManager.AddFavoriteToMenu(item, itemsDict[item]);
            }
        }

        int counter = 1;
        foreach (var itemText in itemsText)
        {
            Catalog loc = catalogList.SingleOrDefault(loc => loc.ShortName == itemText);
            loc.FavoriteRank = counter++;
            await updateLocation(loc);
        }
    }

    private async void makeLocationAFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Catalog loc = catalogList.SingleOrDefault(loc => loc.ShortName == currentCatalog.ShortName);
        if ((bool)loc.Favorite)
        {
            favoritesManager.DeleteFavoriteFromMenu(loc.ShortName);
            loc.Favorite = false;
            loc.FavoriteRank = 0;
        }
        else
        {
            favoritesManager.AddFavoriteToMenu(loc.ShortName, loc.Location);
            loc.Favorite = true;
            loc.FavoriteRank = menuItemFavorites.DropDownItems.Count - 3;
        }
        await updateLocation(loc);
    }

    private void textboxFilter_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar.Equals((char)13))
        {
            toggleFilter();
            e.Handled = true;
            return;
        }

        if (e.KeyChar.Equals((char)27))
        {
            toggleFilter();
            e.Handled = true;
            return;
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!textboxName.ReadOnly)
        {
            showToast("Can't exit yet! ",
                      $"Please finish the update or add pending",
                      Toast.ToastPosition.LOWER_LEFT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.INFO,
                      true);
            e.Cancel = true;
        }

    }

    private void textboxName_Leave(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(textboxDescription.Text))
        {
            textboxDescription.Text = textboxName.Text;
        }
    }

    private void datagridviewLocations_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop) ||
                 e.Data.GetDataPresent(DataFormats.Text) ||
                 e.Data.GetDataPresent(DataFormats.UnicodeText))
        {
            e.Effect = DragDropEffects.Copy;
        }

        //if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
    }

    private void datagridviewLocations_DragDrop(object sender, DragEventArgs e)
    {
        ItemDroppedForAdd(e);
    }

    private void textboxLocation_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
    }

    private async void textboxLocation_DragDrop(object sender, DragEventArgs e)
    {
        if (textboxLocation.ReadOnly) return;

        if (linklabelFilter.Text != "Filter")
        {
            await clearFilter();
            //showToast("A filter is active",
            //        $"Please clear the filter before adding a item",
            //        Toast.ToastPosition.LOWER_LEFT,
            //        Toast.ToastDuration.SHORT,
            //        Toast.ToastStatus.INFO,
            //        true);
            //return;
        }

        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        string file = files[0];

        textboxLocation.Text = file;
    }

    private async void refeshListToolStripMenuItem_Click(object sender, EventArgs e)
    {
        await readSavedLocations();
    }

    private async void datagridviewLocations_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex == 0) await readSavedLocations(true);
        else await readSavedLocations(false);
    }

    private void datagridviewLocations_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1 && e.ColumnIndex > -1)
        {
            datagridviewLocations.Cursor = Cursors.Hand;
        }
        else
        {
            datagridviewLocations.Cursor = Cursors.Default;
        }
    }

    private void textboxUrl_DragDrop(object sender, DragEventArgs e)
    {
        if (textboxUrl.ReadOnly) return;

        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        string file = files[0];

        textboxUrl.Text = file;
    }

    private void textboxUrl_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
    }

    //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    //    {
    //        // Check if Alt + A is pressed
    //        if (keyData == (Keys.Alt | Keys.A))
    //        {
    //            MessageBox.Show("Alt + A was pressed!");
    //            return true; // Indicate that the key event was handled
    //        }

    //        // Call the base method for other key presses
    //        return base.ProcessCmdKey(ref msg, keyData);
    //    }

    private async void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            // Handle Escape key press
            // MessageBox.Show("Escape key pressed!");
            e.Handled = true; // Indicate that the key press has been handled
            await clearFilter();
        }

        //if (e.Control && e.KeyCode == Keys.A)
        //{
        //    MessageBox.Show("You pressed Control + A!");
        //}
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        //if (e.KeyCode == Keys.ControlKey)
        //{
        //    //isControlPressed = false;
        //}
    }

    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
        //if (isControlPressed && e.KeyChar == 'a')
        //{
        //    MessageBox.Show("You pressed Control + a!");
        //}
    }

    private void setAddModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        setAddItemMode();
        //MessageBox.Show("A");
    }

    private async void deleteCurrentRowToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        //MessageBox.Show("Delete current row");
        DialogResult dr = MessageBox.Show("Are sure you want to the selected row?",
                     "Confirm row deletion", MessageBoxButtons.YesNo);

        if (dr == DialogResult.Yes)
        {
            await deleteCatalog(currentCatalog);

            DataGridViewRow row = datagridviewLocations.Rows[currentGridRowIndex];

            string removedShortName = row.Cells["colShortName"].Value.ToString();

            datagridviewLocations.Rows.RemoveAt(currentGridRowIndex);

            showToast("This row was removed:",
                      $"{removedShortName}",
                      Toast.ToastPosition.LOWER_LEFT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.INFO);
        }
    }

    private async void linklabelCancelAdd_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
    {
        linklabelUpdateMode.Tag = "disable";
        toggleReadOnlyStatus();

        toggleAddUpdatePanels();

        LinkLabel lbl = (LinkLabel)sender;

        if (lbl.Text.ToLower().Contains("cancel"))
        {
            buttonAdd.Visible = false;
        }
        else
        {
            buttonAdd.Visible = true;
        }


        await refreshDetailPanel();

        buttonUpdate.BackColor = Color.LightBlue;
        buttonUpdate.ForeColor = Color.Black;
    }

    private bool validateInput()
    {
        if (textboxName.Text.Trim() == "")
        {
            showToast("Input error:",
                      "The 'Name' field is required",
                      Toast.ToastPosition.LOWER_LEFT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.ERROR);
            textboxName.Focus();
            return false;
        }

        if (textboxDescription.Text.Trim() == "")
        {
            showToast("Input error:",
                      "The 'Description' field is required",
                      Toast.ToastPosition.LOWER_LEFT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.ERROR);
            textboxDescription.Focus();
            return false;
        }

        if (textboxLocation.Text.Trim() == "")
        {
            showToast("Input error:",
                      "The 'Location' field is required",
                      Toast.ToastPosition.LOWER_LEFT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.ERROR);
            textboxLocation.Focus();
            return false;
        }


        if (textboxHashtags.Text.Trim() == "")
        {
            showToast("Input error:",
                      "At least one tag is required",
                      Toast.ToastPosition.LOWER_LEFT,
                      Toast.ToastDuration.SHORT,
                      Toast.ToastStatus.ERROR);
            textboxHashtags.Focus();
            return false;
        }


        return true;
    }

    private async void buttonAdd_Click_1(object sender, EventArgs e)
    {
        if (!validateInput()) return;

        // Add operation.
        Catalog catalog = new Catalog();
        catalog.id = 0;
        catalog.Description = textboxDescription.Text;
        catalog.Tags = textboxHashtags.Text;
        catalog.ShortName = textboxName.Text;
        catalog.Location = textboxLocation.Text;
        catalog.Favorite = false;
        catalog.FavoriteRank = 0;

        catalog.Url = textboxUrl.Text;
        catalog.Dateadded = DateTime.Now;

        var catalogJustAdded = await repo.Upsert<Catalog>(catalog);
        catalogList.Add(catalogJustAdded);


        catalogList = catalogList.OrderBy(o => o.ShortName).ToList();
        bindingList = new BindingList<Catalog>(catalogList);
        datagridviewLocations.DataSource = bindingList;


        toggleReadOnlyStatus();
        toggleAddUpdatePanels();
        //selectRowWithLocation(catalog.Location);
        //currentCatalog = catalog;
        //refreshDetailPanel();
        // Scroll selected row into view.
        //datagridviewLocations.FirstDisplayedScrollingRowIndex = datagridviewLocations.SelectedRows[0].Index;

        showToast("Add successful",
                    $"{catalog.ShortName} added",
                    Toast.ToastPosition.LOWER_LEFT,
                    Toast.ToastDuration.SHORT,
                    Toast.ToastStatus.SUCCESS,
                    true);

        selectRowWithLocation(catalog.Location);
        currentCatalog = catalogJustAdded;
        await refreshDetailPanel();

    }
}
