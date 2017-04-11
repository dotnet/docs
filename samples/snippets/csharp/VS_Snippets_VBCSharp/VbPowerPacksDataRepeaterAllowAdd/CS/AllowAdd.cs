using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterAllowAddCS
{
    public partial class AllowAdd : Form
    {
        public AllowAdd()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void AllowAdd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        // <Snippet1>
        private void dataRepeater1_AllowUserToAddItemsChanged(object sender, System.EventArgs e)
        {
            // If this event occurs during form initialization, exit.
            if (this.IsHandleCreated == false) { return; }
            // If AllowUserToAddItems is False.
            if (dataRepeater1.AllowUserToAddItems == false)
            // Disable the Add button.
            {
                bindingNavigatorAddNewItem.Enabled = false;
                // Disable the BindingSource property.
                productsBindingSource.AllowNew = false;
            }
            else
            {
                // Otherwise, enable the Add button.
                bindingNavigatorAddNewItem.Enabled = true;
            }
        }
        // </Snippet1>

        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            if (dataRepeater1.AllowUserToAddItems == false)
            {
                dataRepeater1.AllowUserToAddItems = true;
            }
            else
            {
                dataRepeater1.AllowUserToAddItems = false;
            }

        }
    }
}
