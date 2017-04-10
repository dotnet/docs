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
        OracleConnectionStringBuilder builder = 
            new OracleConnectionStringBuilder(
            "Server=OracleDemo;Integrated Security=True");

        // Display the connection string, which should now 
        // contains the "Data Source" key, as opposed to the 
        // supplied "Server".
        Console.WriteLine(builder.ConnectionString);

        // Retrieve the DataSource property.
        Console.WriteLine("DataSource = " + builder.DataSource);

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }
}
// </Snippet1>

