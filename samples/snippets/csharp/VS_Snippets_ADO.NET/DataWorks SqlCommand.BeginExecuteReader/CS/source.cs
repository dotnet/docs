using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;

class Class1
{
    static void Main()
    {
        // This is a simple example that demonstrates the usage of the 
        // BeginExecuteReader functionality
        // The WAITFOR statement simply adds enough time to prove the 
        // asynchronous nature of the command.
        string commandText =
            "WAITFOR DELAY '00:00:03';" +
            "SELECT LastName, FirstName FROM Person.Contact " +
            "WHERE LastName LIKE 'M%'";

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
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                SqlCommand command = new SqlCommand(commandText, connection);

                connection.Open();
                IAsyncResult result = command.BeginExecuteReader();

                // Although it is not necessary, the following code
                // displays a counter in the console window, indicating that 
                // the main thread is not blocked while awaiting the command 
                // results.
                int count = 0;
                while (!result.IsCompleted)
                {
                    count += 1;
                    Console.WriteLine("Waiting ({0})", count);
                    // Wait for 1/10 second, so the counter
                    // does not consume all available resources 
                    // on the main thread.
                    System.Threading.Thread.Sleep(100);
                }

                using (SqlDataReader reader = command.EndExecuteReader(result))
                {
                    DisplayResults(reader);
                }
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

    private static void DisplayResults(SqlDataReader reader)
    {
        // Display the data within the reader.
        while (reader.Read())
        {
            // Display all the columns. 
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write("{0} ", reader.GetValue(i));
            Console.WriteLine();
        }
    }

    private static string GetConnectionString()
    {
        // To avoid storing the connection string in your code,            
        // you can retrieve it from a configuration file. 

        // If you have not included "Asynchronous Processing=true" in the
        // connection string, the command is not able
        // to execute asynchronously.
        return "Data Source=(local);Integrated Security=true;" +
            "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
    }
}
// </Snippet1>
