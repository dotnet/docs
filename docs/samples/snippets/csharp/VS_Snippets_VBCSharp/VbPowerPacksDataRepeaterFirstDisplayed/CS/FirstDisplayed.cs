using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirstDisplayedCS
{
    public partial class FirstDisplayed : Form
    {
        public FirstDisplayed()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void FirstDisplayed_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwndDataSet.Customers);

        }

        // <Snippet1>
        private void synchButton_Click(System.Object sender, System.EventArgs e)
        {
            // If the first displayed item is not the current item.
            if (dataRepeater1.FirstDisplayedItemIndex != dataRepeater1.CurrentItemIndex)
            // Make it the current item.
            {
                dataRepeater1.CurrentItemIndex = dataRepeater1.FirstDisplayedItemIndex;
            }
        }
        // </Snippet1>
    }
}
