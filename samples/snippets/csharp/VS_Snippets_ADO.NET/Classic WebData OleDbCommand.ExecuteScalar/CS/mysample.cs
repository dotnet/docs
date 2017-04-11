using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;
    // <Snippet1>
    public void CreateMyOleDbCommand(string queryString, 
        OleDbConnection connection) 
    {
        OleDbCommand command = new OleDbCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteScalar();
        connection.Close();
    }
    // </Snippet1>
}