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
        try
        {
            string connectString = "Server=OracleDemo;UID=Mary;Pwd=*****";
            Console.WriteLine("Original: " + connectString);
            OracleConnectionStringBuilder builder = 
                new OracleConnectionStringBuilder(connectString);
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

