using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.ClientServices
;

namespace DeletingItemsCS
{
    public partial class DeletingItems : Form
    {
        public DeletingItems()
        {
            InitializeComponent();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwndDataSet);

        }

        private void DeletingItems_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwndDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.northwndDataSet.Employees);

        }
        // <Snippet1>
        private void DataRepeater1_DeletingItems(object sender, 
            Microsoft.VisualBasic.PowerPacks.DataRepeaterAddRemoveItemsCancelEventArgs e)
        {
            // Check whether the user is a supervisor.

            ClientRolePrincipal rolePrincipal =
                System.Threading.Thread.CurrentPrincipal
                as ClientRolePrincipal;

            if (rolePrincipal.IsInRole("supervisor") == false)
            {
                e.Cancel = true;
                MessageBox.Show("You are not authorized to delete.");
            }
        }   
        // </Snippet1>
    }
}
