using System;
using System.Data;
using System.Text;
using System.Data.OleDb;

namespace DataAdapterIDataAdapterUpdateCS
{
    class Program
    {
        static void Main()
        {
            string connectionString = GetConnectionString();
            string queryString = "SELECT CompanyName FROM dbo.Shippers;";
            DataSet dataSet = CreateCommandAndUpdate(
                connectionString, queryString);
            Console.ReadLine();
        }

        // <Snippet1>
        static private DataSet CreateCommandAndUpdate(
            string connectionString,
            string queryString)
        {
            DataSet dataSet = new DataSet();

            using (OleDbConnection connection =
                       new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbDataAdapter adapter =
                    new OleDbDataAdapter();
                adapter.SelectCommand =
                    new OleDbCommand(queryString, connection);
                OleDbCommandBuilder builder =
                    new OleDbCommandBuilder(adapter);

                adapter.Fill(dataSet);

                // Code to modify data in the DataSet here.

                // Without the OleDbCommandBuilder, this line would fail.
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(dataSet);
            }
            return dataSet;
        }
        // </Snippet1>

        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.
            return "Provider=sqloledb;Data Source=(local);Initial Catalog=Northwind;"
                + "Integrated Security=SSPI";
        }

    }
}
