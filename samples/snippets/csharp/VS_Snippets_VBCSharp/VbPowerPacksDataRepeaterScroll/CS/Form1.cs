using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterScrollCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void synchButton_Click(System.Object sender, System.EventArgs e)
        {
            // If the first displayed item is not the current item.
            if (dataRepeater1.FirstDisplayedItemIndex != dataRepeater1.CurrentItemIndex)
            // Make it the current item.
            {
                dataRepeater1.CurrentItemIndex = dataRepeater1.FirstDisplayedItemIndex;
                // Align it with the top of the control.
                dataRepeater1.ScrollItemIntoView(dataRepeater1.FirstDisplayedItemIndex, true);
            }
        }
        // </Snippet1>

        private void categoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.northwndDataSet.Categories);

        }
    }
}
