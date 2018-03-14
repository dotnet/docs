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
public void CreateMyOleDbDataReader(string queryString,string connectionString) 
{
   OleDbConnection connection = new OleDbConnection(connectionString);
   OleDbCommand command = new OleDbCommand(queryString, connection);
   connection.Open();
   OleDbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
   while(reader.Read()) 
   {
      Console.WriteLine(reader.GetString(0));
   }
   reader.Close();
   //Implicitly closes the connection because CommandBehavior.CloseConnection was specified.
}

// </Snippet1>
}