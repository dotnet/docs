// <Snippet1>
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // List all SQL Server instances:
        ListServers(SqlClientFactory.Instance);

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private static void ListServers(DbProviderFactory factory)
    {
        // This procedure is provider-agnostic, and can list
        // instances of any provider's servers. Of course, 
        // not all providers can create a data source enumerator,
        // so it's best to check the CanCreateDataSourceEnumerator 
        // property before attempting to list the data sources.
        if (factory.CanCreateDataSourceEnumerator)
        {
            DbDataSourceEnumerator instance =
                factory.CreateDataSourceEnumerator();
            DataTable table = instance.GetDataSources();

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("{0}\\{1}",
                    row["ServerName"], row["InstanceName"]);
            }
        }
    }
}
// </Snippet1>
