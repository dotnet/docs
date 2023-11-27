using System;
using System.Configuration;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        BuildConnectionString("(local)", "Nate", "somepassword");
        Console.ReadLine();
    }

    // <Snippet1>
    static void BuildConnectionString(string dataSource,
        string userName, string userPassword)
    {
        // Retrieve the partial connection string named databaseConnection
        // from the application's app.config or web.config file.
        ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["partialConnectString"];

        if (settings != null)
        {
            // Retrieve the partial connection string.
            var connectString = settings.ConnectionString;
            Console.WriteLine("Original: {0}", connectString);

            // Create a new SqlConnectionStringBuilder based on the
            // partial connection string retrieved from the config file.
            SqlConnectionStringBuilder builder =
                new(connectString)
                {
                    // Supply the additional values.
                    DataSource = dataSource,
                    UserID = userName,
                    Password = userPassword
                };
            Console.WriteLine("Modified: {0}", builder.ConnectionString);
        }
    }
    // </Snippet1>
}
