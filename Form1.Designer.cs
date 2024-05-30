namespace ProjectDiary
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            datagridviewLocations = new DataGridView();
            col_dateAdded = new DataGridViewTextBoxColumn();
            colShortName = new DataGridViewTextBoxColumn();
            col_location = new DataGridViewTextBoxColumn();
            tags = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            textboxUrl = new TextBox();
            linkLabel1 = new LinkLabel();
            linklabelOpenLocation = new LinkLabel();
            textboxLocation = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textboxDescription = new TextBox();
            textboxHashtags = new TextBox();
            textboxName = new TextBox();
            panelUpdateButtons = new Panel();
            buttonUpdate = new Button();
            linklabelUpdateMode = new LinkLabel();
            panelAddButtons = new Panel();
            linklabelCancelAdd = new LinkLabel();
            buttonAdd = new Button();
            textboxFilter = new TextBox();
            linklabelFilter = new LinkLabel();
            notifyIcon1 = new NotifyIcon(components);
            menuStrip1 = new MenuStrip();
            mainToolStripMenuItem = new ToolStripMenuItem();
            validateLocationsToolStripMenuItem = new ToolStripMenuItem();
            refeshListToolStripMenuItem = new ToolStripMenuItem();
            menuItemFavorites = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            makeLocationAFavoriteToolStripMenuItem = new ToolStripMenuItem();
            manageFavoritesToolStripMenuItem = new ToolStripMenuItem();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            setAddModeToolStripMenuItem = new ToolStripMenuItem();
            deleteCurrentRowToolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)datagridviewLocations).BeginInit();
            panel1.SuspendLayout();
            panelUpdateButtons.SuspendLayout();
            panelAddButtons.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // datagridviewLocations
            // 
            datagridviewLocations.AllowDrop = true;
            datagridviewLocations.AllowUserToAddRows = false;
            datagridviewLocations.AllowUserToDeleteRows = false;
            datagridviewLocations.AllowUserToResizeColumns = false;
            datagridviewLocations.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLight;
            datagridviewLocations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            datagridviewLocations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            datagridviewLocations.CellBorderStyle = DataGridViewCellBorderStyle.None;
            datagridviewLocations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            datagridviewLocations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            datagridviewLocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridviewLocations.Columns.AddRange(new DataGridViewColumn[] { col_dateAdded, colShortName, col_location, tags });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = Color.Navy;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            datagridviewLocations.DefaultCellStyle = dataGridViewCellStyle5;
            datagridviewLocations.EnableHeadersVisualStyles = false;
            datagridviewLocations.Location = new Point(1183, 144);
            datagridviewLocations.MultiSelect = false;
            datagridviewLocations.Name = "datagridviewLocations";
            datagridviewLocations.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            datagridviewLocations.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            datagridviewLocations.RowHeadersVisible = false;
            datagridviewLocations.RowHeadersWidth = 62;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle7.Padding = new Padding(5);
            datagridviewLocations.RowsDefaultCellStyle = dataGridViewCellStyle7;
            datagridviewLocations.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            datagridviewLocations.RowTemplate.DefaultCellStyle.Padding = new Padding(5);
            datagridviewLocations.RowTemplate.Height = 50;
            datagridviewLocations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridviewLocations.Size = new Size(1276, 1125);
            datagridviewLocations.TabIndex = 0;
            datagridviewLocations.TabStop = false;
            datagridviewLocations.CellMouseEnter += datagridviewLocations_CellMouseEnter;
            datagridviewLocations.ColumnHeaderMouseClick += datagridviewLocations_ColumnHeaderMouseClick;
            datagridviewLocations.RowEnter += datagridviewLocations_RowEnter;
            datagridviewLocations.DragDrop += datagridviewLocations_DragDrop;
            datagridviewLocations.DragEnter += datagridviewLocations_DragEnter;
            // 
            // col_dateAdded
            // 
            col_dateAdded.DataPropertyName = "DateAdded";
            dataGridViewCellStyle3.Format = "yyyy-MMM-dd";
            col_dateAdded.DefaultCellStyle = dataGridViewCellStyle3;
            col_dateAdded.HeaderText = "Added";
            col_dateAdded.MinimumWidth = 9;
            col_dateAdded.Name = "col_dateAdded";
            col_dateAdded.ReadOnly = true;
            col_dateAdded.Width = 225;
            // 
            // colShortName
            // 
            colShortName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colShortName.DataPropertyName = "ShortName";
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.Padding = new Padding(5);
            colShortName.DefaultCellStyle = dataGridViewCellStyle4;
            colShortName.HeaderText = "Name";
            colShortName.MinimumWidth = 8;
            colShortName.Name = "colShortName";
            colShortName.ReadOnly = true;
            // 
            // col_location
            // 
            col_location.DataPropertyName = "location";
            col_location.HeaderText = "Location";
            col_location.MinimumWidth = 8;
            col_location.Name = "col_location";
            col_location.ReadOnly = true;
            col_location.Visible = false;
            col_location.Width = 150;
            // 
            // tags
            // 
            tags.DataPropertyName = "tags";
            tags.HeaderText = "Tags";
            tags.MinimumWidth = 8;
            tags.Name = "tags";
            tags.ReadOnly = true;
            tags.Width = 400;
            // 
            // panel1
            // 
            panel1.Controls.Add(textboxUrl);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(linklabelOpenLocation);
            panel1.Controls.Add(textboxLocation);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textboxDescription);
            panel1.Controls.Add(textboxHashtags);
            panel1.Controls.Add(textboxName);
            panel1.Location = new Point(25, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(1142, 1135);
            panel1.TabIndex = 1;
            // 
            // textboxUrl
            // 
            textboxUrl.AllowDrop = true;
            textboxUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textboxUrl.BackColor = Color.Cornsilk;
            textboxUrl.Font = new Font("Microsoft Sans Serif", 13.875F);
            textboxUrl.ForeColor = Color.DarkSlateBlue;
            textboxUrl.Location = new Point(0, 216);
            textboxUrl.Name = "textboxUrl";
            textboxUrl.ReadOnly = true;
            textboxUrl.Size = new Size(1142, 39);
            textboxUrl.TabIndex = 18;
            textboxUrl.TabStop = false;
            textboxUrl.DragDrop += textboxUrl_DragDrop;
            textboxUrl.DragEnter += textboxUrl_DragEnter;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.WhiteSmoke;
            linkLabel1.Location = new Point(113, 183);
            linkLabel1.Margin = new Padding(2, 0, 2, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 25);
            linkLabel1.TabIndex = 18;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Open action";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linklabelOpenLocation
            // 
            linklabelOpenLocation.AutoSize = true;
            linklabelOpenLocation.LinkColor = Color.WhiteSmoke;
            linklabelOpenLocation.Location = new Point(103, 94);
            linklabelOpenLocation.Margin = new Padding(2, 0, 2, 0);
            linklabelOpenLocation.Name = "linklabelOpenLocation";
            linklabelOpenLocation.Size = new Size(124, 25);
            linklabelOpenLocation.TabIndex = 15;
            linklabelOpenLocation.TabStop = true;
            linklabelOpenLocation.Text = "Open location";
            linklabelOpenLocation.LinkClicked += linklabelOpenLocation_LinkClicked;
            // 
            // textboxLocation
            // 
            textboxLocation.AllowDrop = true;
            textboxLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textboxLocation.BackColor = Color.Cornsilk;
            textboxLocation.BorderStyle = BorderStyle.None;
            textboxLocation.Font = new Font("Microsoft Sans Serif", 13.875F);
            textboxLocation.ForeColor = Color.DarkSlateBlue;
            textboxLocation.Location = new Point(0, 126);
            textboxLocation.Name = "textboxLocation";
            textboxLocation.ReadOnly = true;
            textboxLocation.Size = new Size(1142, 32);
            textboxLocation.TabIndex = 14;
            textboxLocation.TabStop = false;
            textboxLocation.DragDrop += textboxLocation_DragDrop;
            textboxLocation.DragEnter += textboxLocation_DragEnter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.14286F);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(-2, 182);
            label5.Name = "label5";
            label5.Size = new Size(114, 31);
            label5.TabIndex = 16;
            label5.Text = "Reference";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.14286F);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(3, 92);
            label4.Name = "label4";
            label4.Size = new Size(101, 31);
            label4.TabIndex = 13;
            label4.Text = "Location";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.14286F);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(3, 357);
            label3.Name = "label3";
            label3.Size = new Size(131, 31);
            label3.TabIndex = 12;
            label3.Text = "Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.14286F);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(3, 270);
            label2.Name = "label2";
            label2.Size = new Size(59, 31);
            label2.TabIndex = 11;
            label2.Text = "Tags";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.14286F);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(75, 31);
            label1.TabIndex = 10;
            label1.Text = "Name";
            // 
            // textboxDescription
            // 
            textboxDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textboxDescription.BackColor = Color.Cornsilk;
            textboxDescription.Font = new Font("Consolas", 11.5F);
            textboxDescription.ForeColor = Color.DarkSlateBlue;
            textboxDescription.Location = new Point(0, 392);
            textboxDescription.Multiline = true;
            textboxDescription.Name = "textboxDescription";
            textboxDescription.ReadOnly = true;
            textboxDescription.ScrollBars = ScrollBars.Both;
            textboxDescription.Size = new Size(1139, 615);
            textboxDescription.TabIndex = 9;
            textboxDescription.TabStop = false;
            // 
            // textboxHashtags
            // 
            textboxHashtags.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textboxHashtags.BackColor = Color.Cornsilk;
            textboxHashtags.Font = new Font("Microsoft Sans Serif", 13.875F);
            textboxHashtags.ForeColor = Color.DarkSlateBlue;
            textboxHashtags.Location = new Point(3, 304);
            textboxHashtags.Name = "textboxHashtags";
            textboxHashtags.ReadOnly = true;
            textboxHashtags.Size = new Size(1136, 39);
            textboxHashtags.TabIndex = 8;
            textboxHashtags.TabStop = false;
            textboxHashtags.Click += textboxHashtags_Click;
            textboxHashtags.KeyDown += textboxHashtags_KeyDown;
            // 
            // textboxName
            // 
            textboxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textboxName.BackColor = Color.Cornsilk;
            textboxName.Font = new Font("Microsoft Sans Serif", 13.875F);
            textboxName.ForeColor = Color.DarkSlateBlue;
            textboxName.Location = new Point(3, 36);
            textboxName.Name = "textboxName";
            textboxName.ReadOnly = true;
            textboxName.Size = new Size(1139, 39);
            textboxName.TabIndex = 7;
            textboxName.TabStop = false;
            textboxName.Leave += textboxName_Leave;
            // 
            // panelUpdateButtons
            // 
            panelUpdateButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelUpdateButtons.Controls.Add(buttonUpdate);
            panelUpdateButtons.Controls.Add(linklabelUpdateMode);
            panelUpdateButtons.Location = new Point(24, 47);
            panelUpdateButtons.Name = "panelUpdateButtons";
            panelUpdateButtons.Size = new Size(376, 63);
            panelUpdateButtons.TabIndex = 4;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonUpdate.Enabled = false;
            buttonUpdate.Font = new Font("Segoe UI", 12F);
            buttonUpdate.Location = new Point(190, 3);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(179, 53);
            buttonUpdate.TabIndex = 5;
            buttonUpdate.Tag = "update";
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Visible = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // linklabelUpdateMode
            // 
            linklabelUpdateMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linklabelUpdateMode.AutoSize = true;
            linklabelUpdateMode.Font = new Font("Segoe UI", 12F);
            linklabelUpdateMode.LinkColor = Color.WhiteSmoke;
            linklabelUpdateMode.Location = new Point(5, 16);
            linklabelUpdateMode.Name = "linklabelUpdateMode";
            linklabelUpdateMode.Size = new Size(167, 32);
            linklabelUpdateMode.TabIndex = 4;
            linklabelUpdateMode.TabStop = true;
            linklabelUpdateMode.Tag = "enable";
            linklabelUpdateMode.Text = "Enable update";
            linklabelUpdateMode.LinkClicked += linklabelUpdateMode_LinkClicked_1;
            // 
            // panelAddButtons
            // 
            panelAddButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelAddButtons.Controls.Add(linklabelCancelAdd);
            panelAddButtons.Controls.Add(buttonAdd);
            panelAddButtons.Location = new Point(406, 47);
            panelAddButtons.Name = "panelAddButtons";
            panelAddButtons.Size = new Size(376, 63);
            panelAddButtons.TabIndex = 5;
            panelAddButtons.Visible = false;
            // 
            // linklabelCancelAdd
            // 
            linklabelCancelAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linklabelCancelAdd.AutoSize = true;
            linklabelCancelAdd.Font = new Font("Segoe UI", 12F);
            linklabelCancelAdd.LinkColor = Color.WhiteSmoke;
            linklabelCancelAdd.Location = new Point(49, 21);
            linklabelCancelAdd.Name = "linklabelCancelAdd";
            linklabelCancelAdd.Size = new Size(132, 32);
            linklabelCancelAdd.TabIndex = 7;
            linklabelCancelAdd.TabStop = true;
            linklabelCancelAdd.Tag = "enable";
            linklabelCancelAdd.Text = "Cancel add";
            linklabelCancelAdd.LinkClicked += linklabelCancelAdd_LinkClicked;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAdd.BackColor = Color.ForestGreen;
            buttonAdd.Font = new Font("Segoe UI", 12F);
            buttonAdd.ForeColor = Color.WhiteSmoke;
            buttonAdd.Location = new Point(193, 7);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(180, 53);
            buttonAdd.TabIndex = 6;
            buttonAdd.Tag = "Add";
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // textboxFilter
            // 
            textboxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textboxFilter.BackColor = Color.Cornsilk;
            textboxFilter.Font = new Font("Microsoft Sans Serif", 13.875F);
            textboxFilter.ForeColor = Color.DarkSlateBlue;
            textboxFilter.Location = new Point(2099, 64);
            textboxFilter.Margin = new Padding(2);
            textboxFilter.Name = "textboxFilter";
            textboxFilter.Size = new Size(361, 39);
            textboxFilter.TabIndex = 10;
            textboxFilter.KeyPress += textboxFilter_KeyPress;
            // 
            // linklabelFilter
            // 
            linklabelFilter.ActiveLinkColor = Color.WhiteSmoke;
            linklabelFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linklabelFilter.AutoSize = true;
            linklabelFilter.DisabledLinkColor = Color.FromArgb(224, 224, 224);
            linklabelFilter.Font = new Font("Segoe UI", 12F);
            linklabelFilter.LinkBehavior = LinkBehavior.AlwaysUnderline;
            linklabelFilter.LinkColor = Color.WhiteSmoke;
            linklabelFilter.Location = new Point(2007, 68);
            linklabelFilter.Margin = new Padding(2, 0, 2, 0);
            linklabelFilter.Name = "linklabelFilter";
            linklabelFilter.Size = new Size(67, 32);
            linklabelFilter.TabIndex = 9;
            linklabelFilter.TabStop = true;
            linklabelFilter.Text = "Filter";
            linklabelFilter.TextAlign = ContentAlignment.TopRight;
            linklabelFilter.VisitedLinkColor = Color.WhiteSmoke;
            linklabelFilter.LinkClicked += linklabelFilter_LinkClicked;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipText = "Show project diary";
            notifyIcon1.BalloonTipTitle = "Project Diary";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Project diary";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mainToolStripMenuItem, menuItemFavorites, actionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(2482, 33);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            mainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { validateLocationsToolStripMenuItem, refeshListToolStripMenuItem });
            mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            mainToolStripMenuItem.Size = new Size(67, 29);
            mainToolStripMenuItem.Text = "Main";
            // 
            // validateLocationsToolStripMenuItem
            // 
            validateLocationsToolStripMenuItem.Name = "validateLocationsToolStripMenuItem";
            validateLocationsToolStripMenuItem.Size = new Size(252, 34);
            validateLocationsToolStripMenuItem.Text = "Validate locations";
            validateLocationsToolStripMenuItem.Click += validateLocationsToolStripMenuItem_Click;
            // 
            // refeshListToolStripMenuItem
            // 
            refeshListToolStripMenuItem.Name = "refeshListToolStripMenuItem";
            refeshListToolStripMenuItem.Size = new Size(252, 34);
            refeshListToolStripMenuItem.Text = "Refesh list";
            refeshListToolStripMenuItem.Click += refeshListToolStripMenuItem_Click;
            // 
            // menuItemFavorites
            // 
            menuItemFavorites.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, makeLocationAFavoriteToolStripMenuItem, manageFavoritesToolStripMenuItem });
            menuItemFavorites.Name = "menuItemFavorites";
            menuItemFavorites.Size = new Size(98, 29);
            menuItemFavorites.Text = "Favorites";
            menuItemFavorites.Visible = false;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(346, 6);
            toolStripSeparator1.Tag = "END-OF-FAVORITES";
            // 
            // makeLocationAFavoriteToolStripMenuItem
            // 
            makeLocationAFavoriteToolStripMenuItem.Name = "makeLocationAFavoriteToolStripMenuItem";
            makeLocationAFavoriteToolStripMenuItem.Size = new Size(349, 34);
            makeLocationAFavoriteToolStripMenuItem.Text = "Toggle current row as favorite";
            makeLocationAFavoriteToolStripMenuItem.Click += makeLocationAFavoriteToolStripMenuItem_Click;
            // 
            // manageFavoritesToolStripMenuItem
            // 
            manageFavoritesToolStripMenuItem.Name = "manageFavoritesToolStripMenuItem";
            manageFavoritesToolStripMenuItem.Size = new Size(349, 34);
            manageFavoritesToolStripMenuItem.Tag = "";
            manageFavoritesToolStripMenuItem.Text = "Manage favorites";
            manageFavoritesToolStripMenuItem.Click += manageFavoritesToolStripMenuItem_Click;
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setAddModeToolStripMenuItem, deleteCurrentRowToolStripMenuItem1 });
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(87, 29);
            actionsToolStripMenuItem.Text = "Actions";
            // 
            // setAddModeToolStripMenuItem
            // 
            setAddModeToolStripMenuItem.Name = "setAddModeToolStripMenuItem";
            setAddModeToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.A;
            setAddModeToolStripMenuItem.Size = new Size(285, 34);
            setAddModeToolStripMenuItem.Text = "Set add mode";
            setAddModeToolStripMenuItem.Click += setAddModeToolStripMenuItem_Click;
            // 
            // deleteCurrentRowToolStripMenuItem1
            // 
            deleteCurrentRowToolStripMenuItem1.Name = "deleteCurrentRowToolStripMenuItem1";
            deleteCurrentRowToolStripMenuItem1.Size = new Size(285, 34);
            deleteCurrentRowToolStripMenuItem1.Text = "Delete current row";
            deleteCurrentRowToolStripMenuItem1.Click += deleteCurrentRowToolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(2482, 1290);
            Controls.Add(textboxFilter);
            Controls.Add(linklabelFilter);
            Controls.Add(panel1);
            Controls.Add(panelUpdateButtons);
            Controls.Add(datagridviewLocations);
            Controls.Add(panelAddButtons);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Project Catalog v10.0.10";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyPress += Form1_KeyPress;
            KeyUp += Form1_KeyUp;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)datagridviewLocations).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelUpdateButtons.ResumeLayout(false);
            panelUpdateButtons.PerformLayout();
            panelAddButtons.ResumeLayout(false);
            panelAddButtons.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView datagridviewLocations;
        private Panel panel1;
        private TextBox textboxName;
        private TextBox textboxDescription;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textboxLocation;
        private Label label4;
        private Panel panelUpdateButtons;
        private Button buttonUpdate;
        private LinkLabel linklabelUpdateMode;
        private Panel panelAddButtons;
        private LinkLabel linklabelCancelAdd;
        private Button buttonAdd;
        public TextBox textboxHashtags;
        private LinkLabel linklabelOpenLocation;
        private TextBox textboxFilter;
        private LinkLabel linklabelFilter;
        private NotifyIcon notifyIcon1;
        private LinkLabel linkLabel1;
        private Label label5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripMenuItem validateLocationsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem manageFavoritesToolStripMenuItem;
        public ToolStripMenuItem menuItemFavorites;
        private ToolStripMenuItem makeLocationAFavoriteToolStripMenuItem;
        private ToolStripMenuItem refeshListToolStripMenuItem;
        private TextBox textboxUrl;
        private DataGridViewTextBoxColumn col_dateAdded;
        private DataGridViewTextBoxColumn colShortName;
        private DataGridViewTextBoxColumn col_location;
        private DataGridViewTextBoxColumn tags;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem setAddModeToolStripMenuItem;
        private ToolStripMenuItem deleteCurrentRowToolStripMenuItem1;
    }
}