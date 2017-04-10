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
    public void CreateMyOleDbCommand(OleDbConnection connection,
        string queryString, OleDbParameter[] parameters) 
    {
        OleDbCommand command = new OleDbCommand(queryString, connection);
        command.CommandText = 
            "SELECT CustomerID, CompanyName FROM Customers WHERE Country = ? AND City = ?";
        command.Parameters.Add(parameters);

        for (int j=0; j<parameters.Length; j++)
        {
            command.Parameters.Add(parameters[j]) ;
        }

        string message = "";
        for (int i = 0; i < command.Parameters.Count; i++) 
        {
            message += command.Parameters[i].ToString() + "\n";
        }
        Console.WriteLine(message);
    }
    // </Snippet1>

}
