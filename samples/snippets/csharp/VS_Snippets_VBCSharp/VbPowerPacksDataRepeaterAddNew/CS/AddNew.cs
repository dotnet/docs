using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterAddNewCS
{
    public partial class AddNew : Form
    {
        public AddNew()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void AddNew_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        // <Snippet1>
        private void addNewButton_Click(object sender, System.EventArgs e)
        {
            // Add a new repeater item.
            dataRepeater1.AddNew();
            // Set the default text.
            dataRepeater1.CurrentItem.Controls["productNameTextBox"].Text = "New Product";
        }
        // </Snippet1>
    }
}
