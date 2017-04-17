using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
        string x = "Provider=SQLOLEDB;Data Source=(local);Initial Catalog=AdventureWorks;"
            + "Integrated Security=SSPI";
        GetSchemaTable(x);
        Console.ReadLine();
    }

    // <Snippet1>
    static DataTable GetSchemaTable(string connectionString)
    {
        using (OleDbConnection connection = new 
                   OleDbConnection(connectionString))
        {
            connection.Open();
            DataTable schemaTable = connection.GetOleDbSchemaTable(
                OleDbSchemaGuid.Tables,
                new object[] { null, null, null, "TABLE" });
            return schemaTable;
        }
    }
    // </Snippet1>
}

