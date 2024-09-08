using System;
using System.Data.Common;

static class Program
{
    // <Snippet1>
    // Given a provider name and connection string,
    // create the DbProviderFactory and DbConnection.
    // Returns a DbConnection on success; null on failure.
    static DbConnection CreateDbConnection(
        string providerName, string connectionString)
    {
        // Assume failure.
        DbConnection connection = null;

        // Create the DbProviderFactory and DbConnection.
        if (connectionString != null)
        {
            try
            {
                DbProviderFactory factory =
                    DbProviderFactories.GetFactory(providerName);

                connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;
            }
            catch (Exception ex)
            {
                // Set the connection to null if it was created.
                if (connection != null)
                {
                    connection = null;
                }
                Console.WriteLine(ex.Message);
            }
        }
        // Return the connection.
        return connection;
    }
    // </Snippet1>
}
