using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterAllowDeleteCS
{
    public partial class AllowDelete : Form
    {
        public AllowDelete()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void AllowDelete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        // <Snippet1>
        private void dataRepeater1_AllowUserToDeleteItemsChanged(object sender, System.EventArgs e)
        {
            // If this event occurs during form initialization, exit.
            if (this.IsHandleCreated == false) { return; }
            // If AllowUserToDeleteItems is False.
            if (dataRepeater1.AllowUserToDeleteItems == false)
            // Disable the Delete button.
            {
                bindingNavigatorDeleteItem.Enabled = false;
            }
            else
            {
                // Otherwise, enable the Delete button.
                bindingNavigatorDeleteItem.Enabled = true;
            }
        }
        private void bindingNavigatorDeleteItem_EnabledChanged(object sender, System.EventArgs e)
        {
            if (dataRepeater1.AllowUserToDeleteItems == false)
            // The BindingSource resets this property when a 
            // new record is selected, so override it.
            {
                if (bindingNavigatorDeleteItem.Enabled == true)
                {
                    bindingNavigatorDeleteItem.Enabled = false;
                }
            }
        }
        // </Snippet1>

        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            if (dataRepeater1.AllowUserToDeleteItems == false)
            {
                dataRepeater1.AllowUserToDeleteItems = true;
            }
            else
            {
                dataRepeater1.AllowUserToDeleteItems = false;
            }
        }
    }
}
