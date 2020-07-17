using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

class Program
{
    static void Main()
    {
        BuildConnectionString("(local)", "Nate", "somepassword");
        Console.ReadLine();
    }

    // <Snippet1>
    private static void BuildConnectionString(string dataSource,
        string userName, string userPassword)
    {
        // Retrieve the partial connection string named databaseConnection
        // from the application's app.config or web.config file.
        ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["partialConnectString"];

        if (null != settings)
        {
            // Retrieve the partial connection string.
            string connectString = settings.ConnectionString;
            Console.WriteLine("Original: {0}", connectString);

            // Create a new SqlConnectionStringBuilder based on the
            // partial connection string retrieved from the config file.
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(connectString);

            // Supply the additional values.
            builder.DataSource = dataSource;
            builder.UserID = userName;
            builder.Password = userPassword;
            Console.WriteLine("Modified: {0}", builder.ConnectionString);
        }
    }
    // </Snippet1>
}
