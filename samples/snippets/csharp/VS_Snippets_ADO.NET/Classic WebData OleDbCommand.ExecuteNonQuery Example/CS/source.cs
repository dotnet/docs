using System;
using System.Data;
using System.Data.OleDb;


namespace OleDbCommandExecuteNonQueryCS
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Provider=sqloledb;Data Source=(local);Initial Catalog=Northwind;"
                + "Integrated Security=SSPI";
            string queryString = "UPDATE Shippers SET CompanyName = 'Speedy Expresss' WHERE ShipperID = 1";
            CreateOleDbCommand(queryString, connectionString);
            Console.ReadLine();
        }

        // <Snippet1>
        static private void CreateOleDbCommand(
            string queryString, string connectionString)
        {
            using (OleDbConnection connection = new 
                       OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = new 
                    OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
        }
        // </Snippet1>
    }
}
