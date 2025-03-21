using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

static class Program
{
    // <Snippet1>
    // Takes a DbConnection, creates and executes a DbCommand.
    // Assumes SQL INSERT syntax is supported by provider.
    static void ExecuteDbCommand(DbConnection connection)
    {
        // Check for valid DbConnection object.
        if (connection != null)
        {
            using (connection)
            {
                try
                {
                    // Open the connection.
                    connection.Open();

                    // Create and execute the DbCommand.
                    DbCommand command = connection.CreateCommand();
                    command.CommandText =
                        "INSERT INTO Categories (CategoryName) VALUES ('Low Carb')";
                    var rows = command.ExecuteNonQuery();

                    // Display number of rows inserted.
                    Console.WriteLine($"Inserted {rows} rows.");
                }
                // Handle data errors.
                catch (DbException exDb)
                {
                    Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                    Console.WriteLine($"DbException.Source: {exDb.Source}");
                    Console.WriteLine($"DbException.ErrorCode: {exDb.ErrorCode}");
                    Console.WriteLine($"DbException.Message: {exDb.Message}");
                }
                // Handle all other exceptions.
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception.Message: {ex.Message}");
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
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("sqlx: " + ex);
                }
            }

            Console.WriteLine((connection?.State.ToString()) ?? "invalid Connection!");

            // Return the open connection.
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
