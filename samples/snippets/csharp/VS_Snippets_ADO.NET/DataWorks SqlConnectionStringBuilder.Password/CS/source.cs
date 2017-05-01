using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        try
        {
            string connectString = 
                "Server=(local);Database=AdventureWorks;UID=ab;Pwd= a!Pass@@";
            Console.WriteLine("Original: " + connectString);
            SqlConnectionStringBuilder builder = 
                new SqlConnectionStringBuilder(connectString);
            Console.WriteLine("Modified: " + builder.ConnectionString);
            foreach (string key in builder.Keys)
                Console.WriteLine(key + "=" + builder[key].ToString());
            Console.WriteLine("Press any key to finish.");
            Console.ReadLine();

        }
        catch (System.Collections.Generic.KeyNotFoundException ex)
        {
            Console.WriteLine("KeyNotFoundException: " + ex.Message);
        }
        catch (System.FormatException ex)
        {
            Console.WriteLine("Format exception: " + ex.Message);
        }
    }
}
// </Snippet1>

