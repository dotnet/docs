using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        // Supply any valid Document ID value.
        // The value 7 is supplied for demonstration purposes.
        var summaryString = GetDocumentSummary(7);
        Console.ReadLine();
    }
    // <Snippet1>
    static string? GetDocumentSummary(int documentID)
    {
        // Assumes GetConnectionString returns a valid connection string.
        using (SqlConnection connection =
                   new(GetConnectionString()))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            try
            {
                // Set up the command to execute the stored procedure.
                command.CommandText = "GetDocumentSummary";
                command.CommandType = CommandType.StoredProcedure;

                // Set up the input parameter for the DocumentID.
                SqlParameter paramID =
                    new("@DocumentID", SqlDbType.Int)
                    {
                        Value = documentID
                    };
                command.Parameters.Add(paramID);

                // Set up the output parameter to retrieve the summary.
                SqlParameter paramSummary =
                    new("@DocumentSummary",
                    SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                command.Parameters.Add(paramSummary);

                // Execute the stored procedure.
                command.ExecuteNonQuery();
                Console.WriteLine((string)paramSummary.Value);
                return (string)paramSummary.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
    // </Snippet1>

    static string GetConnectionString() =>
        throw new NotImplementedException();
}
