using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Class1
{
    static void Main()
    {
        // This is a simple example that demonstrates the usage of the 
        // BeginExecuteNonQuery functionality.
        // The WAITFOR statement simply adds enough time to prove the 
        // asynchronous nature of the command.
      
        string commandText = 
            "UPDATE Production.Product SET ReorderPoint = ReorderPoint + 1 " + 
            "WHERE ReorderPoint Is Not Null;" + 
            "WAITFOR DELAY '0:0:3';" + 
            "UPDATE Production.Product SET ReorderPoint = ReorderPoint - 1 " + 
            "WHERE ReorderPoint Is Not Null";

        RunCommandAsynchronously(commandText, GetConnectionString());

        Console.WriteLine("Press ENTER to continue.");
        Console.ReadLine();
    }

    private static void RunCommandAsynchronously(
        string commandText, string connectionString)
    {
        // Given command text and connection string, asynchronously execute
        // the specified command against the connection. For this example,
        // the code displays an indicator as it is working, verifying the 
        // asynchronous behavior. 
        using (SqlConnection connection = 
                   new SqlConnection(connectionString))
        {
            try
            {
                int count = 0;
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();

                IAsyncResult result = command.BeginExecuteNonQuery();
                while (!result.IsCompleted)
                {
                    Console.WriteLine("Waiting ({0})", count++);
                    // Wait for 1/10 second, so the counter
                    // does not consume all available resources 
                    // on the main thread.
                    System.Threading.Thread.Sleep(100);
                }
                Console.WriteLine("Command complete. Affected {0} rows.", 
                    command.EndExecuteNonQuery(result));
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error ({0}): {1}", ex.Number, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                // You might want to pass these errors
                // back out to the caller.
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,            
        // you can retrieve it from a configuration file. 

        // If you have not included "Asynchronous Processing=true" in the
        // connection string, the command is not able
        // to execute asynchronously.
        return "Data Source=(local);Integrated Security=SSPI;" +
            "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
    } 
}
// </Snippet1>
