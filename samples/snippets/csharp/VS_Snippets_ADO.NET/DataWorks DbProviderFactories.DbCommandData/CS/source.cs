using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

static class Program
{
    static void Main()
    {
        DbConnection? c = CreateFactoryConnection("System.Data.OleDb");
        //DbConnection? c = CreateFactoryConnection("System.Data.SqlClient");
        if (c != null)
        {
            DbCommandSelect(c);
        }
        Console.ReadLine();
    }

    // <Snippet1>
    // Takes a DbConnection and creates a DbCommand to retrieve data
    // from the Categories table by executing a DbDataReader.
    static void DbCommandSelect(DbConnection connection)
    {
        const string queryString =
            "SELECT CategoryID, CategoryName FROM Categories";

        // Check for valid DbConnection.
        if (connection != null)
        {
            using (connection)
            {
                try
                {
                    // Create the command.
                    DbCommand command = connection.CreateCommand();
                    command.CommandText = queryString;
                    command.CommandType = CommandType.Text;

                    // Open the connection.
                    connection.Open();

                    // Retrieve the data.
                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}. {1}", reader[0], reader[1]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception.Message: {0}", ex.Message);
                }
            }
        }
        else
        {
            Console.WriteLine("Failed: DbConnection is null.");
        }
    }
    // </Snippet1>
    // Given a provider, create the factory and connect to the data source.
    // The provider invariant name is in the format System.Data.ProviderName.
    static DbConnection? CreateFactoryConnection(string providerName)
    {
        // Retrieve the connection string from the configuration file
        // by supplying the provider name to a custom function.
        var connectionString = GetConnectionStringByProvider(providerName);

        // Create the factory if there's a valid connection string.
        if (connectionString != null)
        {
            DbProviderFactory factory =
                DbProviderFactories.GetFactory(providerName);

            // Create the connection.
            DbConnection? connection = factory.CreateConnection();
            if (connection != null)
            {
                connection.ConnectionString = connectionString;
            }

            // Return the connection.
            return connection;
        }
        return null;
    }

    // Return the connection string for the specified provider.
    // If there are multiple connection strings for the same
    // provider, the first one found is returned.
    // Returns null if the provider is not found.
    static string? GetConnectionStringByProvider(string providerName)
    {
        for (var i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
        {
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[i];

            if (settings.ProviderName == providerName)
            {
                return settings.ConnectionString;
            }
        }
        // Provider name not found.
        return null;
    }
}
