using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataRepeaterAppCS
{
    public partial class DataRepeaterWalkthrough : Form
    {
        public DataRepeaterWalkthrough()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void DataRepeaterWalkthrough_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwndDataSet.Customers);
            // <Snippet3>
            dataRepeater1.AllowUserToAddItems = false;
            dataRepeater1.AllowUserToDeleteItems = false;
            bindingNavigatorAddNewItem.Enabled = false;
            customersBindingSource.AllowNew = false;
            bindingNavigatorDeleteItem.Enabled = false;
            // </Snippet3>
        }
        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            // <Snippet1>
            // Alternate the back color.
            if ((e.DataRepeaterItem.ItemIndex % 2) != 0)
            // Apply the secondary back color.
            {
                e.DataRepeaterItem.BackColor = Color.AliceBlue;
            }
            else
            {
                // Apply the default back color.
                e.DataRepeaterItem.BackColor = dataRepeater1.BackColor;
            }
            // </Snippet1>
            // <Snippet2>
            if (e.DataRepeaterItem.Controls[regionTextBox.Name].Text == "")
            {
                e.DataRepeaterItem.Controls["regionLabel"].ForeColor = Color.Red;
            }
            else
            {
                e.DataRepeaterItem.Controls["regionLabel"].ForeColor = Color.Black;
            }
            // </Snippet2>
        }
        private void bindingNavigatorDeleteItem_EnabledChanged(object sender, System.EventArgs e)
        {
            // <Snippet4>
            if (bindingNavigatorDeleteItem.Enabled == true)
            {
                bindingNavigatorDeleteItem.Enabled = false;
            }
            // </Snippet4>
        }
        private void searchButton_Click(System.Object sender, System.EventArgs e)
        {
            // <Snippet5>
            int foundIndex;
            string searchString;
            searchString = searchTextBox.Text;
            // Search for the string in the CustomerID field.
            foundIndex = customersBindingSource.Find("CustomerID", searchString);
            if (foundIndex > -1)
            {
                dataRepeater1.CurrentItemIndex = foundIndex;
            }
            else
            {
                MessageBox.Show("Item " + searchString + " not found.");
            }
            // </Snippet5>
        }
    }
}
