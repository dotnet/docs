// <Snippet1>
using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        try
        {
            DemonstrateChangePassword();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }

    private static void DemonstrateChangePassword()
    {
        // Retrieve the connection string. In a production application,
        // this string should not be contained within the source code.
        string connectionString = GetConnectionString();

        using (SqlConnection cnn = new SqlConnection())
        {
            for (int i = 0; i <= 1; i++)
            {
                // Run this loop at most two times. If the first attempt fails, 
                // the code checks the Number property of the SqlException object.
                // If that contains the special values 18487 or 18488, the code 
                // attempts to set the user's password to a new value. 
                // Assuming this succeeds, the second pass through 
                // successfully opens the connection.
                // If not, the exception handler catches the exception.
                try
                {
                    cnn.ConnectionString = connectionString;
                    cnn.Open();
                    // Once this succeeds, just get out of the loop.
                    // No need to try again if the connection is already open.
                    break;
                }
                catch (SqlException ex)
                {
                    if (i == 0 && ((ex.Number == 18487) || (ex.Number == 18488)))
                    {
                        // You must reset the password. 
                        connectionString =
                            ModifyConnectionString(connectionString, 
                            GetNewPassword());

                    }
                    else
                        // Bubble all other SqlException occurrences
                        // back up to the caller.
                        throw;
                }
            }
            SqlCommand cmd = new SqlCommand(
                "SELECT ProductID, Name FROM Product", cnn);
            // Use the connection and command here...
        }
    }

    private static string ModifyConnectionString(
        string connectionString, string NewPassword)
    {

        // Use the SqlConnectionStringBuilder class to modify the
        // password portion of the connection string. 
        SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(connectionString);
        builder.Password = NewPassword;
        return builder.ConnectionString;
    }

    private static string GetNewPassword()
    {
        // In a real application, you might display a modal
        // dialog box to retrieve the new password. The concepts
        // are the same as for this simple console application, however.
        Console.Write("Your password must be reset. Enter a new password: ");
        return Console.ReadLine();
    }

    private static string GetConnectionString()
    {
        // For this demonstration, the connection string must
        // contain both user and password information. In your own
        // application, you might want to retrieve this setting
        // from a config file, or from some other source.

        // In a production application, you would want to 
        // display a modal form that could gather user and password
        // information.
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
            "Data Source=(local);Initial Catalog=AdventureWorks");

        Console.Write("Enter your user id: ");
        builder.UserID = Console.ReadLine();
        Console.Write("Enter your password: ");
        builder.Password = Console.ReadLine();

        return builder.ConnectionString;
    }
}
// </Snippet1>

