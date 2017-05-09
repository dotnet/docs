using System;
using System.Data;
using System.Data.SqlClient;
class Program
{
    static void Main()
    {
        // Supply any valid Document ID value.
        // The value 7 is supplied for demonstration purposes.
        string summaryString = GetDocumentSummary(7);
        Console.ReadLine();
    }
    // <Snippet1>
    static private string GetDocumentSummary(int documentID)
    {
        //Assumes GetConnectionString returns a valid connection string.
        using (SqlConnection connection =
                   new SqlConnection(GetConnectionString()))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            try
            {
                // Setup the command to execute the stored procedure.
                command.CommandText = "GetDocumentSummary";
                command.CommandType = CommandType.StoredProcedure;

                // Set up the input parameter for the DocumentID.
                SqlParameter paramID =
                    new SqlParameter("@DocumentID", SqlDbType.Int);
                paramID.Value = documentID;
                command.Parameters.Add(paramID);

                // Set up the output parameter to retrieve the summary.
                SqlParameter paramSummary =
                    new SqlParameter("@DocumentSummary",
                    SqlDbType.NVarChar, -1);
                paramSummary.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramSummary);

                // Execute the stored procedure.
                command.ExecuteNonQuery();
                Console.WriteLine((String)(paramSummary.Value));
                return (String)(paramSummary.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
    // </Snippet1>
    static private string GetConnectionString()
    {
        // To avoid storing the connectionection string in your code, 
        // you can retrieve it from a configuration file, using the 
        // System.Configuration.ConfigurationSettings.AppSettings property
        return "Data Source=(local);Initial Catalog=AdventureWorks;" +
            "Integrated Security=SSPI";
    }
}
