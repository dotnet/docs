using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace HeaderVisibleChangedCS
{
    public partial class HeaderVisibleChanged : Form
    {
        public HeaderVisibleChanged()
        {
            InitializeComponent();
        }

        private void categoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void HeaderVisibleChanged_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.northwndDataSet.Categories);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataRepeater1.ItemHeaderVisible == false)
            {
                dataRepeater1.ItemHeaderVisible = true;
            }
            else
            {
                dataRepeater1.ItemHeaderVisible = false;
            }
        }

        // <Snippet1>
        private void DataRepeater1_ItemHeaderVisibleChanged(object sender, System.EventArgs e)
        {
            // Display the selection mode in the label.
            if (dataRepeater1.ItemHeaderVisible == false)
            {
                selectionModeLabel.Text = "Selected item marked by selection " +
                 "rectangle.";
            }
            else
            {
                selectionModeLabel.Text = "Selected item marked by item " +
                 "header.";
            }
        }
        // </Snippet1>

    }
}
