using System;
using System.Data;
using System.Windows.Forms;

namespace CS
{
    public partial class Form1 : Form
    {
        //---------------------------------------------------------------------
        void Test1Typed()
        {
            //<Snippet1>
            NorthwindDataSet.CustomersRow newCustomersRow = 
                northwindDataSet1.Customers.NewCustomersRow();

            newCustomersRow.CustomerID = "ALFKI";
            newCustomersRow.CompanyName = "Alfreds Futterkiste";

            northwindDataSet1.Customers.Rows.Add(newCustomersRow);
            //</Snippet1>
        

            //<Snippet3>
            //<Snippet18>
            NorthwindDataSet.CustomersRow customersRow = 
                northwindDataSet1.Customers.FindByCustomerID("ALFKI");
            //</Snippet18>

            customersRow.CompanyName = "Updated Company Name";
            customersRow.City = "Seattle";;
            //</Snippet3>


            //<Snippet5>
            northwindDataSet1.Customers[4].CompanyName = "Updated Company Name";
            northwindDataSet1.Customers[4].City = "Seattle";
            //</Snippet5>


            //<Snippet8>
            northwindDataSet1.Customers.Rows[0].Delete();
            //</Snippet8>


            //<Snippet11>
            northwindDataSet1.Customers.AcceptChanges();
            //</Snippet11>


            //<Snippet12>
            if (northwindDataSet1.HasChanges()) 
            {
                // Changed rows were detected, add appropriate code.
            }
            else
            {
                // No changed rows were detected, add appropriate code.
            }
            //</Snippet12>


            //<Snippet13>
            if (northwindDataSet1.HasChanges(DataRowState.Added)) 
            {
                // New rows have been added to the dataset, add appropriate code.
            }
            else
            {
                // No new rows have been added to the dataset, add appropriate code.
            }
            //</Snippet13>


            //<Snippet21>
            string originalCompanyName;
            originalCompanyName = northwindDataSet1.Customers[0]
                ["CompanyName", DataRowVersion.Original].ToString();
            //</Snippet21>


            //<Snippet22>
            string currentCompanyName;
            currentCompanyName = northwindDataSet1.Customers[0]
                ["CompanyName", DataRowVersion.Current].ToString();
            //</Snippet22>
        }


        //---------------------------------------------------------------------
        void Test2Untyped()
        {
            //<Snippet2>
            DataRow newCustomersRow = dataSet1.Tables["Customers"].NewRow();

            newCustomersRow["CustomerID"] = "ALFKI";
            newCustomersRow["CompanyName"] = "Alfreds Futterkiste";

            dataSet1.Tables["Customers"].Rows.Add(newCustomersRow);
            //</Snippet2>
        

            //<Snippet4>
            DataRow[] customerRow = 
                dataSet1.Tables["Customers"].Select("CustomerID = 'ALFKI'");

            customerRow[0]["CompanyName"] = "Updated Company Name";
            customerRow[0]["City"] = "Seattle";
            //</Snippet4>


            //<Snippet6>
            dataSet1.Tables[0].Rows[4][0] = "Updated Company Name";
            dataSet1.Tables[0].Rows[4][1] = "Seattle";
            //</Snippet6>


            //<Snippet7>
            dataSet1.Tables["Customers"].Rows[4]["CompanyName"] = "Updated Company Name";
            dataSet1.Tables["Customers"].Rows[4]["City"] = "Seattle";
            //</Snippet7>


            //<Snippet9>
            dataSet1.Tables["Customers"].Rows[0].Delete();
            //</Snippet9>


            //<Snippet10>
            dataSet1.EnforceConstraints = false;
            // Perform some operations on the dataset
            dataSet1.EnforceConstraints = true;
            //</Snippet10>


            //<Snippet19>
            string s = "primaryKeyValue";
            DataRow foundRow = dataSet1.Tables["AnyTable"].Rows.Find(s);

            if (foundRow != null) 
            {
                MessageBox.Show(foundRow[0].ToString());
            }
            else
            {
                MessageBox.Show("A row with the primary key of " + s + " could not be found");
            }
            //</Snippet19>


            //<Snippet20>
            DataRow[] foundRows;
            foundRows = dataSet1.Tables["Customers"].Select("CompanyName Like 'A%'");
            //</Snippet20>
        }


        //---------------------------------------------------------------------
        void Test3Changed()
        {
            DataTable dataTable1 = dataSet1.Tables[0];


            //<Snippet14>
            DataSet changedRecords = dataSet1.GetChanges();
            //</Snippet14>
 

            //<Snippet15>
            DataTable changedRecordsTable = dataTable1.GetChanges();
            //</Snippet15>


            //<Snippet16>
            DataSet addedRecords = dataSet1.GetChanges(DataRowState.Added);
            //</Snippet16>

        }


        //---------------------------------------------------------------------
        //<Snippet17>
        private NorthwindDataSet.CustomersDataTable GetNewRecords()
        {
            return (NorthwindDataSet.CustomersDataTable)
                northwindDataSet1.Customers.GetChanges(DataRowState.Added);
        }
        //</Snippet17>


        //---------------------------------------------------------------------
        //<Snippet23>
        private void FindErrors() 
        {
            if (dataSet1.HasErrors)
            {
                foreach (DataTable table in dataSet1.Tables)
                {
                    if (table.HasErrors)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (row.HasErrors)
                            {
                                // Process error here.
                            }
                        }
                    }
                }
            }
        }
        //</Snippet23>


        //---------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }
    }
}