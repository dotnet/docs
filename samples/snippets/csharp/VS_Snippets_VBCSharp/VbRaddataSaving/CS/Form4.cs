using System;
using System.Data;
using System.Windows.Forms;

namespace CS
{
    public partial class Form4 : Form
    {
        //---------------------------------------------------------------------
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //<Snippet10>
            this.Validate();
            this.ordersBindingSource.EndEdit();
            this.customersBindingSource.EndEdit();

            NorthwindDataSet.OrdersDataTable deletedOrders = (NorthwindDataSet.OrdersDataTable)
                northwindDataSet.Orders.GetChanges(DataRowState.Deleted);

            NorthwindDataSet.OrdersDataTable newOrders = (NorthwindDataSet.OrdersDataTable)
                northwindDataSet.Orders.GetChanges(DataRowState.Added);

            NorthwindDataSet.OrdersDataTable modifiedOrders = (NorthwindDataSet.OrdersDataTable)
                northwindDataSet.Orders.GetChanges(DataRowState.Modified);

            try
            {
                // Remove all deleted orders from the Orders table.
                if (deletedOrders != null)
                {
                    ordersTableAdapter.Update(deletedOrders);
                }

                // Update the Customers table.
                customersTableAdapter.Update(northwindDataSet.Customers);

                // Add new orders to the Orders table.
                if (newOrders != null)
                {
                    ordersTableAdapter.Update(newOrders);
                }

                // Update all modified Orders.
                if (modifiedOrders != null)
                {
                    ordersTableAdapter.Update(modifiedOrders);
                }

                northwindDataSet.AcceptChanges();
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Update failed");
            }

            finally
            {
                if (deletedOrders != null)
                {
                    deletedOrders.Dispose();
                }
                if (newOrders != null)
                {
                    newOrders.Dispose();
                }
                if (modifiedOrders != null)
                {
                    modifiedOrders.Dispose();
                }
            }
            //</Snippet10>
        }


        //---------------------------------------------------------------------
        public Form4()
        {
            InitializeComponent();
        }


        //---------------------------------------------------------------------
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }
    }
}