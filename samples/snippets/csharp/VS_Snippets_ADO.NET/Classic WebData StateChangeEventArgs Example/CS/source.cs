
using System;
using System.Data;
using System.Data.SqlClient;

namespace StateChangeEventArgsCS
{
    class Program
    {
        // <Snippet1>
        // Handler for OnStateChange event.
        protected static void OnStateChange(object sender,
            StateChangeEventArgs e)
        {
            PrintEventArgs(e);
        }

        static void Main()
        {
            FillDataSet();
        }

        static private void FillDataSet()
        {
            string connectionString = GetConnectionString();
            string queryString =
                "SELECT ProductID, UnitPrice from dbo.Products;";

            // Create a DataAdapter.
            using (SqlDataAdapter dataAdapter =
                       new SqlDataAdapter(queryString, connectionString))
            {

                // Add the handlers.
                dataAdapter.SelectCommand.Connection.StateChange
                    += new StateChangeEventHandler(OnStateChange);

                // Create a DataSet.
                DataSet dataSet = new DataSet();

                // Fill the DataSet, which fires several StateChange events.
                dataAdapter.Fill(dataSet, 0, 5, "Table");
            }
        }

        protected static void PrintEventArgs(StateChangeEventArgs args)
        {
            Console.WriteLine("StateChangeEventArgs");
            Console.WriteLine("  OriginalState= {0} CurrentState= {1}",
                args.OriginalState, args.CurrentState);
        }

        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.
            return "Data Source=(local);Initial Catalog=Northwind;"
                + "Integrated Security=true";
        }
        // </Snippet1>
        // add Console.ReadLine(); to Main to test.
    }
}
