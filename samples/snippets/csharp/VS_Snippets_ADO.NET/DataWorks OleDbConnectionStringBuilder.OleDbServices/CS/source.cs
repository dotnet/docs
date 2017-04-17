using System;
using System.Data;
// <Snippet1>
using System.Data.OleDb;

class Program
{
    // These constants correspond to values in the 
    // OLE DB SDK. You can use these values to 
    // turn features on and off.
    private const int DBPROPVAL_OS_AGR_AFTERSESSION = 8;
    private const int DBPROPVAL_OS_AGR_RESOURCEPOOLING = 1;
    private const int DBPROPVAL_OS_AGR_TXNENLISTMENT = 2;
    private const int DBPROPVAL_OS_AGR_CLIENTCURSOR = 4;
    private const int DBPROPVAL_OS_ENABLEALL = -1;
    private const int DBPROPVAL_OS_DISABLEALL = 0;


    static void Main()
    {
        OleDbConnectionStringBuilder builder =
            new OleDbConnectionStringBuilder();
        // Turn on all services except resource pooling.
        builder.OleDbServices =
            DBPROPVAL_OS_ENABLEALL &
            ~DBPROPVAL_OS_AGR_RESOURCEPOOLING;

        builder.Provider = "sqloledb";
        builder.DataSource = "(local)";
        builder["Initial Catalog"] = "AdventureWorks";
        builder["Integrated Security"] = "SSPI";

        // Store the connection string.
        string savedConnectionString = builder.ConnectionString;
        Console.WriteLine(savedConnectionString);

        // Reset the object. This resets all the properties to their
        // default values.
        builder.Clear();

        // Investigate the OleDbServices property before
        // and after assigning a connection string value.
        Console.WriteLine("Default : " + builder.OleDbServices);
        builder.ConnectionString = savedConnectionString;
        Console.WriteLine("Modified: " + builder.OleDbServices);

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }
}
// </Snippet1>

