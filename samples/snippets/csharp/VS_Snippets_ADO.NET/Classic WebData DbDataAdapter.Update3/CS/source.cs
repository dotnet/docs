using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace AdapterUpdateCS
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        // <Snippet1>
        public DataSet CreateCmdsAndUpdate(string connectionString,
            string queryString, string tableName) 
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand(queryString, connection);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                connection.Open();

                DataSet customers = new DataSet();
                adapter.Fill(customers);

                //code to modify data in dataset here

                adapter.Update(customers, tableName);

                return customers;
            }
        }
        // </Snippet1>    
    }
}
