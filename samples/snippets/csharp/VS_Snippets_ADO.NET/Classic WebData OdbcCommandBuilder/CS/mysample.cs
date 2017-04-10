using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

class Program
{
    static void Main()
    {
    }
    // <Snippet1>
    public static DataSet SelectOdbcSrvRows(string connectionString,
        string queryString, string tableName)
    {
        DataSet dataSet = new DataSet();
        using (OdbcConnection connection = new OdbcConnection(connectionString))
        {
            OdbcDataAdapter adapter = new OdbcDataAdapter();
            adapter.SelectCommand =
                new OdbcCommand(queryString, connection);
            OdbcCommandBuilder builder =
                new OdbcCommandBuilder(adapter);

            connection.Open();

            adapter.Fill(dataSet, tableName);

            //code to modify data in DataSet here

            //Without the OdbcCommandBuilder this line would fail
            adapter.Update(dataSet, tableName);
        }
        return dataSet;
    }
    // </Snippet1>
}
