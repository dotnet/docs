using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
    }

    // <Snippet1>
    public void CreateCommand(string queryString, OleDbConnection connection)
    {
        OleDbCommand command = new OleDbCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteReader();
        command.Cancel();
    }
    // </Snippet1>
}

