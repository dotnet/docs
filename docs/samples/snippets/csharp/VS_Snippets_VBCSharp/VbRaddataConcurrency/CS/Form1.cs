using System;
using System.Data;
using System.Windows.Forms;

namespace ConcurrencyWalkthroughCS
{
    public partial class Form1 : Form
    {
        //---------------------------------------------------------------------
        void Test()
        {
            //<Snippet5>
            try
            {
                customersTableAdapter.Update(northwindDataSet);
            }
            catch (DBConcurrencyException ex)
            {
                string customErrorMessage;
                customErrorMessage = "Concurrency violation\n";
                customErrorMessage += ex.Row[0].ToString();

                // Add business logic code to resolve the concurrency violation...
            }
            //</Snippet5>
        }
        

        //---------------------------------------------------------------------
        //<Snippet2>
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            UpdateDatabase();
        }
        //</Snippet2>
        

        //---------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }


        //---------------------------------------------------------------------
        //<Snippet1>
        private void UpdateDatabase()
        {
            try
            {
                this.customersTableAdapter.Update(this.northwindDataSet.Customers);
                MessageBox.Show("Update successful");
            }
            catch (DBConcurrencyException dbcx)
            {
                DialogResult response = MessageBox.Show(CreateMessage((NorthwindDataSet.CustomersRow)
                    (dbcx.Row)), "Concurrency Exception", MessageBoxButtons.YesNo);

                ProcessDialogResult(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was thrown while attempting to update the database.");
            }
        }
        //</Snippet1>


        //---------------------------------------------------------------------
        //<Snippet4>
        private string CreateMessage(NorthwindDataSet.CustomersRow cr)
        {
            return
                "Database: " + GetRowData(GetCurrentRowInDB(cr), DataRowVersion.Default) + "\n" +
                "Original: " + GetRowData(cr, DataRowVersion.Original) + "\n" +
                "Proposed: " + GetRowData(cr, DataRowVersion.Current) + "\n" +
                "Do you still want to update the database with the proposed value?";
        }


        //--------------------------------------------------------------------------
        // This method loads a temporary table with current records from the database
        // and returns the current values from the row that caused the exception.
        //--------------------------------------------------------------------------
        private NorthwindDataSet.CustomersDataTable tempCustomersDataTable = 
            new NorthwindDataSet.CustomersDataTable();

        private NorthwindDataSet.CustomersRow GetCurrentRowInDB(NorthwindDataSet.CustomersRow RowWithError)
        {
            this.customersTableAdapter.Fill(tempCustomersDataTable);

            NorthwindDataSet.CustomersRow currentRowInDb = 
                tempCustomersDataTable.FindByCustomerID(RowWithError.CustomerID);

            return currentRowInDb;
        }


        //--------------------------------------------------------------------------
        // This method takes a CustomersRow and RowVersion 
        // and returns a string of column values to display to the user.
        //--------------------------------------------------------------------------
        private string GetRowData(NorthwindDataSet.CustomersRow custRow, DataRowVersion RowVersion)
        {
            string rowData = "";

            for (int i = 0; i < custRow.ItemArray.Length ; i++ )
            {
                rowData = rowData + custRow[i, RowVersion].ToString() + " ";
            }
            return rowData;
        }
        //</Snippet4>
                

        //---------------------------------------------------------------------
        //<Snippet3>
        // This method takes the DialogResult selected by the user and updates the database 
        // with the new values or cancels the update and resets the Customers table 
        // (in the dataset) with the values currently in the database.

        private void ProcessDialogResult(DialogResult response)
        {
            switch (response)
            {
                case DialogResult.Yes:
                    northwindDataSet.Merge(tempCustomersDataTable, true, MissingSchemaAction.Ignore);
                    UpdateDatabase();
                    break;

                case DialogResult.No:
                    northwindDataSet.Merge(tempCustomersDataTable);
                    MessageBox.Show("Update cancelled");
                    break;
            }
        }
        //</Snippet3>


        //---------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }
    }
}