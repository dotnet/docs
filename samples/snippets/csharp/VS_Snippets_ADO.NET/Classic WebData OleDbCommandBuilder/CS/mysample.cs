using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

public class Form1 
{
    static void Main()
    {
    }
    // <Snippet1>
    public static DataSet UpdateRows(string connectionString,
        string queryString, string tableName)
    {
        DataSet dataSet = new DataSet();
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand(queryString, connection);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(adapter);

            connection.Open();

            adapter.Fill(dataSet, tableName);

            //code to modify data in DataSet here

            cb.GetDeleteCommand();
            //Without the OleDbCommandBuilder this line would fail
            adapter.Update(dataSet, tableName);

            connection.Close();
        }
        return dataSet;
    }
    // </Snippet1>
}