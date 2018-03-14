using System;
using System.Data;
// <Snippet1>
// You may need to set a reference to the System.Data.OracleClient
// assembly before running this example.
using System.Data.OracleClient;

class Program
{
    static void Main()
    {
        OracleConnectionStringBuilder builder =
            new OracleConnectionStringBuilder(GetConnectionString());

        // Loop through each of the values, displaying the contents.
        foreach (object value in builder.Values)
            Console.WriteLine(value);

        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file. 
        return "Data Source=OracleSample;Integrated Security=true;" +
            "Persist Security Info=True; Max Pool Size=100; Min Pool Size=1";
    }
}
// </Snippet1>

