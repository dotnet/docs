using System;
using System.Data;
// <Snippet1>
using System.Data.SqlClient;
using System.Xml;

class Class1
{
    static void Main()
    {
        // This example is not terribly effective, but it proves a point.
        // The WAITFOR statement simply adds enough time to prove the 
        // asynchronous nature of the command.
        string commandText =
            "WAITFOR DELAY '00:00:03';" +
            "SELECT Name, ListPrice FROM Production.Product " +
            "WHERE ListPrice < 100 " +
            "FOR XML AUTO, XMLDATA";

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
            SqlCommand command = new SqlCommand(commandText, connection);

            connection.Open();
            IAsyncResult result = command.BeginExecuteXmlReader();

            // Although it is not necessary, the following procedure
            // displays a counter in the console window, indicating that 
            // the main thread is not blocked while awaiting the command 
            // results.
            int count = 0;
            while (!result.IsCompleted)
            {
                Console.WriteLine("Waiting ({0})", count++);
                // Wait for 1/10 second, so the counter
                // does not consume all available resources 
                // on the main thread.
                System.Threading.Thread.Sleep(100);
            }

            XmlReader reader = command.EndExecuteXmlReader(result);
            DisplayProductInfo(reader);
        }
    }

    private static void DisplayProductInfo(XmlReader reader)
    {
        // Display the data within the reader.
        while (reader.Read())
        {
            // Skip past items that are not from the correct table.
            if (reader.LocalName.ToString() == "Production.Product")
            {
                Console.WriteLine("{0}: {1:C}",
                    reader["Name"], Convert.ToSingle(reader["ListPrice"]));
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
        return "Data Source=(local);Integrated Security=true;" +
            "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
    }
}
// </Snippet1>
