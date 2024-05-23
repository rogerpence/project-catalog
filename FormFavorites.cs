using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDiary
{
    public partial class FormFavorites : Form
    {
        public List<String> itemList;

        public FormFavorites(List<String> itemList)
        {
            InitializeComponent();

            this.itemList = itemList;
            this.listboxItems.AllowDrop = true;
        }

        private void FormFavorites_Load(object sender, EventArgs e)
        {
            foreach (var item in itemList)
            {
                listboxItems.Items.Add(item);
            }
        }

        private void listboxItems_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listboxItems.SelectedItem == null) return;
            this.listboxItems.DoDragDrop(this.listboxItems.SelectedItem, DragDropEffects.Move);
        }

        private void listboxItems_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listboxItems_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listboxItems.PointToClient(new Point(e.X, e.Y));
            int index = this.listboxItems.IndexFromPoint(point);
            if (index < 0)
            {
                index = this.listboxItems.Items.Count - 1;
            }
            string data = e.Data.GetData(typeof(String)).ToString();
            this.listboxItems.Items.Remove(data);
            this.listboxItems.Items.Insert(index, data);
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            itemList.Clear();

            foreach (string item in listboxItems.Items)
            {
                itemList.Add(item);
            }
            this.Close();
        }

    }
}
