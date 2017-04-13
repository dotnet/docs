using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
        //        string x = "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind";
    }

    // <Snippet1>
    public DataSet GetDataSetFromAdapter(
        DataSet dataSet, string connectionString, string queryString)
    {
        using (OleDbConnection connection =
                   new OleDbConnection(connectionString))
        {
            OleDbDataAdapter adapter =
                new OleDbDataAdapter(queryString, connection);

            // Set the parameters.
            adapter.SelectCommand.Parameters.Add(
                "@CategoryName", OleDbType.VarChar, 80).Value = "toasters";
            adapter.SelectCommand.Parameters.Add(
                "@SerialNum", OleDbType.Integer).Value = 239;

            // Open the connection and fill the DataSet.
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // The connection is automatically closed when the
            // code exits the using block.
        }
        return dataSet;
    }
    // </Snippet1>
}


