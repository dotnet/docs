using System;
using System.Data;
using System.Data.OleDb;

class Class1
{
    static void Main()
    {
        //string x = "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind";
        //ReadData(x);
    }

    //<Snippet1>
    public static void ReadData(string connectionString, string queryString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString());
            }
            reader.Close();
        }
    }
    //</Snippet1>
}


