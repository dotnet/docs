using System;
using System.Data;
// <Snippet1>
// You may need to set a reference to the System.Data.OracleClient
// assembly before you can run this sample.
using System.Data.OracleClient;

class Program
{
    static void Main()
    {
        // Create a new OracleConnectionStringBuilder and
        // initialize it with a few name/value pairs.
        OracleConnectionStringBuilder builder =
            new OracleConnectionStringBuilder(GetConnectionString());


        // Note that the input connection string used the 
        // Server key, but the new connection string uses
        // the well-known Data Source key instead.
        Console.WriteLine(builder.ConnectionString);

        // Pass the OracleConnectionStringBuilder an existing 
        // connection string, and you can retrieve and
        // modify any of the elements.
        builder.ConnectionString = "server=OracleDemo;user id=maryc;" +
            "password=pass@word1";

        // Now that the connection string has been parsed,
        // you can work with individual items.
        Console.WriteLine(builder.Password);
        builder.Password = "newPassword";
        builder.PersistSecurityInfo = true;

        // You can refer to connection keys using strings, 
        // as well. When you use this technique (the default
        // Item property in Visual Basic, or the indexer in C#),
        // you can specify any synonym for the connection string key
        // name.
        builder["Server"] = ".";
        builder["Load Balance Timeout"] = 1000;
        builder["Integrated Security"] = true;
        Console.WriteLine(builder.ConnectionString);

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file. 
        return "Server=OracleDemo;Integrated Security=true";
    }
}
// </Snippet1>

