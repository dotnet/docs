using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VirtualPropertyCS
{
    public partial class VirtualProperty : Form
    {
        public VirtualProperty()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void VirtualProperty_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);
            // <Snippet1>
            // If the DataRepeater is in virtual mode, 
            // do not allow adds or deletes.
            if (dataRepeater1.VirtualMode == true)
            {
                dataRepeater1.AllowUserToAddItems = false;
                dataRepeater1.AllowUserToDeleteItems = false;
                // Disable the Add button.
                productsBindingNavigator.AddNewItem.Enabled = false;
                // Disable the Delete button.
                productsBindingNavigator.DeleteItem.Enabled = false;
            }
            // </Snippet1>
        }
    }
}
