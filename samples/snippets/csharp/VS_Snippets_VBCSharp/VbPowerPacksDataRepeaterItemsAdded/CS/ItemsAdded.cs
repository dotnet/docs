using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDataRepeaterItemsAddedCS
{
    public partial class ItemsAdded : Form
    {
        public ItemsAdded()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void ItemsAdded_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwndDataSet.Customers);

        }
        // <Snippet1>
        private void dataRepeater1_ItemsAdded(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterAddRemoveItemsEventArgs e)
        {
            string itemNumber;
            itemNumber = e.ItemIndex.ToString();
            MessageBox.Show("New item: " + itemNumber);
        }
        // </Snippet1>
    }
}
