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
            string connectString =
                "Data Source=OracleSample;User ID=Mary;Password=*****;";

            OracleConnectionStringBuilder builder =
                new OracleConnectionStringBuilder(connectString);
            Console.WriteLine("Original: " + builder.ConnectionString);

            // Use the Remove method
            // in order to reset the user ID and password back to their
            // default (empty string) values. Simply setting the 
            // associated property values to an empty string will not
            // remove them from the connection string; you must
            // call the Remove method.
            builder.Remove("User ID");
            builder.Remove("Password");

            // Turn on integrated security.
            builder.IntegratedSecurity = true;

            Console.WriteLine("Modified: " + builder.ConnectionString);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Press any key to finish.");
        Console.ReadLine();
    }
}
// </Snippet1>

