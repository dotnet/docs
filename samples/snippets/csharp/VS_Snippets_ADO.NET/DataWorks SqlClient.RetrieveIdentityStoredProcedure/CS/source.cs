using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        var connectionString = GetConnectionString();
        RetrieveIdentity(connectionString);
        Console.ReadLine();
    }
    // <Snippet1>
    static void RetrieveIdentity(string connectionString)
    {
        using (SqlConnection connection =
                   new(connectionString))
        {
            // Create a SqlDataAdapter based on a SELECT query.
            SqlDataAdapter adapter =
                new(
                "SELECT CategoryID, CategoryName FROM dbo.Categories",
                connection)
                {
                    //Create the SqlCommand to execute the stored procedure.
                    InsertCommand = new SqlCommand("dbo.InsertCategory",
                connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

            // Add the parameter for the CategoryName. Specifying the
            // ParameterDirection for an input parameter is not required.
            adapter.InsertCommand.Parameters.Add(
               new SqlParameter("@CategoryName", SqlDbType.NVarChar, 15,
               "CategoryName"));

            // Add the SqlParameter to retrieve the new identity value.
            // Specify the ParameterDirection as Output.
            SqlParameter parameter =
                adapter.InsertCommand.Parameters.Add(
                "@Identity", SqlDbType.Int, 0, "CategoryID");
            parameter.Direction = ParameterDirection.Output;

            // Create a DataTable and fill it.
            DataTable categories = new();
            adapter.Fill(categories);

            // Add a new row.
            DataRow newRow = categories.NewRow();
            newRow["CategoryName"] = "New Category";
            categories.Rows.Add(newRow);

            adapter.Update(categories);

            Console.WriteLine("List All Rows:");
            foreach (DataRow row in categories.Rows)
            {
                {
                    Console.WriteLine($"{row[0]}: {row[1]}");
                }
            }
        }
    }
    // </Snippet1>

    static string GetConnectionString() =>
        throw new NotImplementedException();
}
