using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDiary;

public partial class FormTags : Form
{
    Form1 form1;

    public FormTags(Form1 f)
    {
        InitializeComponent();

        this.form1 = f;

        listboxTags.DataSource = f.hashTags;
        listboxTags.Focus();
    }
    private string getSelectedItems()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in listboxTags.SelectedItems)
        {
            sb.Append(item + " ");
        }

        return sb.ToString().Trim();
    }

    private void FormTags_Load(object sender, EventArgs e)
    {
        textboxTag.Focus();
        if (listboxTags.Items.Count > 0)
        {
            listboxTags.SetSelected(0, false);
        }
        setSelectedFromOtherForm();
    }

    private void setSelectedFromOtherForm()
    {
        string selectedFromOTher = form1.textboxHashtags.Text;
        string[] selectedTags = selectedFromOTher.Split(" ", StringSplitOptions.TrimEntries);
        assignSelectedTags(selectedTags);
    }

    private void assignSelectedTags(IEnumerable<string> selectedTags)
    {
        List<int> selectedIndexes = new List<int>();

        foreach (var selectedTag in selectedTags)
        {
            for (int i = 0; i < listboxTags.Items.Count; i++)
            {
                string currentTag = listboxTags.Items[i].ToString();
                if (currentTag == selectedTag)
                {
                    selectedIndexes.Add(i);
                    break;
                }
            }
        }

        listboxTags.ClearSelected();

        foreach (var index in selectedIndexes)
        {
            listboxTags.SetSelected(index, true);
        }
    }

    private void linklabelAddTag_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
    {
        addNewTag();
    }

    private void addNewTag()
    {
        string newTag = (textboxTag.Text.Trim().StartsWith("#")) ? textboxTag.Text.Trim().ToLower() : "#" + textboxTag.Text.Trim().ToLower();
        //string newTag = textboxTag.Text.Trim();

        List<String> tags = (List<String>)listboxTags.DataSource;

        string foundTag = tags.SingleOrDefault(t => t == newTag);
        if (foundTag == null)
        {
            List<string> selectedTags = new List<string>();

            foreach (var item in listboxTags.SelectedItems)
            {
                selectedTags.Add(item.ToString());
            }
            selectedTags.Add(newTag);

            tags.Add(newTag);

            listboxTags.DataSource = null;
            tags.Sort(StringComparer.CurrentCulture);
            listboxTags.DataSource = tags;
            textboxTag.Text = "";

            assignSelectedTags(selectedTags);
        }
        else
        {
            MessageBox.Show($"{newTag} is already in the list");
            textboxTag.Text = "";
            return;
        }
    }

    private void buttonClose_Click_1(object sender, EventArgs e)
    {
        string tags = getSelectedItems();
        form1.selectedTagsFromTagForm = tags;
        this.Close();
    }

    private void linklabelCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
    }

    private void textboxTag_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar.Equals((char)13))
        {
            addNewTag();
            e.Handled = true;
            return;
        }

    }
}


