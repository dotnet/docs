using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterCurrentItemCS
{
    public partial class CurrentItem : Form
    {
        public CurrentItem()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void CurrentItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwndDataSet.Products);

        }

        // <Snippet1>
        private void dataRepeater1_CurrentItemIndexChanged(object sender, System.EventArgs e)
        {
            // Exit if the control is first loading.
            if (dataRepeater1.CurrentItem == null) { return; }
            // Check for zero quantity.
            if (dataRepeater1.CurrentItem.Controls["unitsInStockTextBox"].Text == "0") 
            // Display a the warning label on the form.
            {
                this.lowStockWarningLabel.Visible = true;
            }
            else
            {
                this.lowStockWarningLabel.Visible = false;
            }
        }
        // </Snippet1>
    }
}
