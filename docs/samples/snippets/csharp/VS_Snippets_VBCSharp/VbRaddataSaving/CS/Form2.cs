using System;
using System.Data;
using System.Windows.Forms;

namespace CS
{
    public partial class Form2 : Form
    {
        //---------------------------------------------------------------------
        void Test()
        {
            //<Snippet11>
            using (System.Transactions.TransactionScope updateTransaction = 
                new System.Transactions.TransactionScope())
            {
                // Add code to save your data here.
                // Throw an exception to roll back the transaction.

                // Call the Complete method to commit the transaction
                updateTransaction.Complete();
            }
            //</Snippet11>
        }


        //---------------------------------------------------------------------
        //<Snippet4>
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.ordersBindingSource.EndEdit();

            using (System.Transactions.TransactionScope updateTransaction = 
                new System.Transactions.TransactionScope())
            {
                DeleteOrders();
                DeleteCustomers();
                AddNewCustomers();
                AddNewOrders();

                updateTransaction.Complete();
                northwindDataSet.AcceptChanges();
            }
        }
        //</Snippet4>


        //---------------------------------------------------------------------
        //<Snippet5>
        private void DeleteOrders()
        {
            NorthwindDataSet.OrdersDataTable deletedOrders;
            deletedOrders = (NorthwindDataSet.OrdersDataTable)
                northwindDataSet.Orders.GetChanges(DataRowState.Deleted);

            if (deletedOrders != null)
            {
                try
                {
                    ordersTableAdapter.Update(deletedOrders);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("DeleteOrders Failed");
                }
            }
        }
        //</Snippet5>


        //---------------------------------------------------------------------
        //<Snippet6>
        private void DeleteCustomers()
        {
            NorthwindDataSet.CustomersDataTable deletedCustomers;
            deletedCustomers = (NorthwindDataSet.CustomersDataTable)
                northwindDataSet.Customers.GetChanges(DataRowState.Deleted);

            if (deletedCustomers != null)
            {
                try
                {
                    customersTableAdapter.Update(deletedCustomers);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("DeleteCustomers Failed");
                }
            }
        }
        //</Snippet6>


        //---------------------------------------------------------------------
        //<Snippet7>
        private void AddNewCustomers()
        {
            NorthwindDataSet.CustomersDataTable newCustomers;
            newCustomers = (NorthwindDataSet.CustomersDataTable)
                northwindDataSet.Customers.GetChanges(DataRowState.Added);

            if (newCustomers != null)
            {
                try
                {
                    customersTableAdapter.Update(newCustomers);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("AddNewCustomers Failed");
                }
            }
        }
        //</Snippet7>


        //---------------------------------------------------------------------
        //<Snippet8>
        private void AddNewOrders()
        {
            NorthwindDataSet.OrdersDataTable newOrders;
            newOrders = (NorthwindDataSet.OrdersDataTable)
                northwindDataSet.Orders.GetChanges(DataRowState.Added);

            if (newOrders != null)
            {
                try
                {
                    ordersTableAdapter.Update(newOrders);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("AddNewOrders Failed");
                }
            }
        }
        //</Snippet8>


        //---------------------------------------------------------------------
        public Form2()
        {
            InitializeComponent();
        }


        //---------------------------------------------------------------------
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
 
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }


        //---------------------------------------------------------------------
        //<Snippet27>
        void UpdateDB()
        {
            NorthwindDataSet.OrdersDataTable deletedChildRecords = 
                (NorthwindDataSet.OrdersDataTable)northwindDataSet.Orders.GetChanges(DataRowState.Deleted);

            NorthwindDataSet.OrdersDataTable newChildRecords = 
                (NorthwindDataSet.OrdersDataTable)northwindDataSet.Orders.GetChanges(DataRowState.Added);

            NorthwindDataSet.OrdersDataTable modifiedChildRecords = 
                (NorthwindDataSet.OrdersDataTable)northwindDataSet.Orders.GetChanges(DataRowState.Modified);

            try
            {
                if (deletedChildRecords != null)
                {
                    ordersTableAdapter.Update(deletedChildRecords);
                }

                customersTableAdapter.Update(northwindDataSet.Customers);

                if (newChildRecords != null)
                {
                    ordersTableAdapter.Update(newChildRecords);
                }

                if (modifiedChildRecords != null)
                {
                    ordersTableAdapter.Update(modifiedChildRecords);
                }

                northwindDataSet.AcceptChanges();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during the update process");
                // Add code to handle error here.
            }

            finally
            {
                if (deletedChildRecords != null)
                {
                    deletedChildRecords.Dispose();
                }
                if (newChildRecords != null)
                {
                    newChildRecords.Dispose();
                }
                if (modifiedChildRecords != null)
                {
                    modifiedChildRecords.Dispose();
                }
            }
        }
        //</Snippet27>


    }
}