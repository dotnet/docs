using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataRepeaterSearchCS
{
    public partial class DataRepeaterSearch : Form
    {
        public DataRepeaterSearch()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void DataRepeaterSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        // <Snippet1>
        private void searchButton_Click(System.Object sender, System.EventArgs e)
        {
            int foundIndex;
            string searchString;
            searchString = searchTextBox.Text;
            foundIndex = productsBindingSource.Find("ProductID", searchString);
            if (foundIndex > -1)
            {
                dataRepeater1.CurrentItemIndex = foundIndex;
            }
            else
            {
                MessageBox.Show("Item " + searchString + " not found.");
            }
        }
        // </Snippet1>
    }
}
