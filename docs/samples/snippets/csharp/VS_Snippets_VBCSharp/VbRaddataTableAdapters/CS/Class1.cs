using System;

namespace CS
{
    class Class1
    {
        //---------------------------------------------------------------------
        void Test2()
        {
            //<Snippet7>
            NorthwindDataSet northwindDataSet = new NorthwindDataSet();

            NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter = 
                new NorthwindDataSetTableAdapters.CustomersTableAdapter();

            customersTableAdapter.Fill(northwindDataSet.Customers);
            //</Snippet7>
        }


        //---------------------------------------------------------------------
        void Test()
        {
            NorthwindDataSet northwindDataSet1 = new NorthwindDataSet();
            

            //<Snippet3>
            NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter1;
            customersTableAdapter1 = new NorthwindDataSetTableAdapters.CustomersTableAdapter();
            //</Snippet3>


            //<Snippet4>
            customersTableAdapter1.Fill(northwindDataSet1.Customers);
            //</Snippet4>


            //<Snippet5>
            NorthwindDataSet.CustomersDataTable newCustomersTable;
            newCustomersTable = customersTableAdapter1.GetData();
            //</Snippet5>


            //<Snippet6>
            NorthwindDataSetTableAdapters.QueriesTableAdapter scalarQueriesTableAdapter;
            scalarQueriesTableAdapter = new NorthwindDataSetTableAdapters.QueriesTableAdapter();

            int returnValue;
            returnValue = (int)scalarQueriesTableAdapter.CustomerCount();
            //</Snippet6>
        }
    }
}
