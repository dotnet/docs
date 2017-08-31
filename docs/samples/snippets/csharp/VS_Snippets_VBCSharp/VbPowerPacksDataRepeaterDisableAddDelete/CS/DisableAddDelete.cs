using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisableAddDeleteCS
{
    public partial class DisableAddDelete : Form
    {
        public DisableAddDelete()
        {
            InitializeComponent();
        }

        private void ordersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ordersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void DisableAddDelete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.northwndDataSet.Orders);
            // <Snippet2>
            dataRepeater1.AllowUserToAddItems = false;
            dataRepeater1.AllowUserToDeleteItems = false;
            bindingNavigatorAddNewItem.Enabled = false;
            ordersBindingSource.AllowNew = false;
            bindingNavigatorDeleteItem.Enabled = false;
            // </Snippet2>
        }

        private void BindingNavigatorDeleteItem_EnabledChanged(object sender, System.EventArgs e)
        {
            // <Snippet1>
            if (bindingNavigatorDeleteItem.Enabled == true)
            {
                bindingNavigatorDeleteItem.Enabled = false;
            }
            // </Snippet1>
        }
    }
}
