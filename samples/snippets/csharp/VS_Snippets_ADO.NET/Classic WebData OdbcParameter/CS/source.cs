using System;
using System.Data;
using System.Data.Odbc;

class Program
{
    static void Main()
    {
        //string connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Samples\\Northwind.mdb";
        //string x = "DRIVER={SQL Server};SERVER=MyServer;Trusted_connection=yes;DATABASE=Northwind;"
    }

    // <Snippet1>
    public DataSet GetDataSetFromAdapter(
        DataSet dataSet, string connectionString, string queryString)
    {
        using (OdbcConnection connection =
            new OdbcConnection(connectionString))
        {
            OdbcDataAdapter adapter =
                new OdbcDataAdapter(queryString, connection);

            // Set the parameters.
            adapter.SelectCommand.Parameters.Add(
                "@CategoryName", OdbcType.VarChar, 80).Value = "toasters";
            adapter.SelectCommand.Parameters.Add(
                "@SerialNum", OdbcType.Int).Value = 239;

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
