namespace ProjectDiary
{
    partial class FormTags
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listboxTags = new ListBox();
            linklabelAddTag = new LinkLabel();
            textboxTag = new TextBox();
            buttonClose = new Button();
            linklabelCancel = new LinkLabel();
            SuspendLayout();
            // 
            // listboxTags
            // 
            listboxTags.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listboxTags.FormattingEnabled = true;
            listboxTags.ItemHeight = 32;
            listboxTags.Location = new Point(10, 21);
            listboxTags.Margin = new Padding(2, 2, 2, 2);
            listboxTags.Name = "listboxTags";
            listboxTags.SelectionMode = SelectionMode.MultiSimple;
            listboxTags.Size = new Size(345, 644);
            listboxTags.TabIndex = 10;
            // 
            // linklabelAddTag
            // 
            linklabelAddTag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            linklabelAddTag.AutoSize = true;
            linklabelAddTag.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linklabelAddTag.LinkColor = Color.WhiteSmoke;
            linklabelAddTag.Location = new Point(13, 759);
            linklabelAddTag.Margin = new Padding(2, 0, 2, 0);
            linklabelAddTag.Name = "linklabelAddTag";
            linklabelAddTag.Size = new Size(98, 32);
            linklabelAddTag.TabIndex = 12;
            linklabelAddTag.TabStop = true;
            linklabelAddTag.Text = "Add tag";
            linklabelAddTag.LinkClicked += linklabelAddTag_LinkClicked_1;
            // 
            // textboxTag
            // 
            textboxTag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textboxTag.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textboxTag.Location = new Point(11, 714);
            textboxTag.Margin = new Padding(2, 2, 2, 2);
            textboxTag.Name = "textboxTag";
            textboxTag.Size = new Size(345, 39);
            textboxTag.TabIndex = 8;
            textboxTag.KeyPress += textboxTag_KeyPress;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            buttonClose.DialogResult = DialogResult.OK;
            buttonClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClose.Location = new Point(213, 806);
            buttonClose.Margin = new Padding(2, 2, 2, 2);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(109, 57);
            buttonClose.TabIndex = 9;
            buttonClose.Text = "OK";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click_1;
            // 
            // linklabelCancel
            // 
            linklabelCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            linklabelCancel.AutoSize = true;
            linklabelCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linklabelCancel.LinkColor = Color.WhiteSmoke;
            linklabelCancel.Location = new Point(99, 817);
            linklabelCancel.Margin = new Padding(2, 0, 2, 0);
            linklabelCancel.Name = "linklabelCancel";
            linklabelCancel.Size = new Size(85, 32);
            linklabelCancel.TabIndex = 11;
            linklabelCancel.TabStop = true;
            linklabelCancel.Text = "Cancel";
            linklabelCancel.LinkClicked += linklabelCancel_LinkClicked;
            // 
            // FormTags
            // 
            AcceptButton = buttonClose;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            CancelButton = linklabelCancel;
            ClientSize = new Size(364, 892);
            Controls.Add(linklabelCancel);
            Controls.Add(listboxTags);
            Controls.Add(linklabelAddTag);
            Controls.Add(textboxTag);
            Controls.Add(buttonClose);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormTags";
            StartPosition = FormStartPosition.Manual;
            Text = "Tags";
            TopMost = true;
            Load += FormTags_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listboxTags;
        private LinkLabel linklabelAddTag;
        private TextBox textboxTag;
        private Button buttonClose;
        private LinkLabel linklabelCancel;
    }
}