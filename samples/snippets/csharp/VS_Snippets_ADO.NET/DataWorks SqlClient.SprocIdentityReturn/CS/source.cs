using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        var connectionString = GetConnectionString();
        ReturnIdentity(connectionString);
        // Console.ReadLine();
    }

    static void ReturnIdentity(string connectionString)
    {
        // <Snippet1>
        using (SqlConnection connection = new(connectionString))
        {
            // Create a SqlDataAdapter based on a SELECT query.
            SqlDataAdapter adapter = new("SELECT CategoryID, CategoryName FROM dbo.Categories", connection)
            {
                // Create a SqlCommand to execute the stored procedure.
                InsertCommand = new SqlCommand("InsertCategory", connection)
                {
                    CommandType = CommandType.StoredProcedure
                }
            };

            // Create a parameter for the ReturnValue.
            SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@RowCount", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;

            // Create an input parameter for the CategoryName.
            // You do not need to specify direction for input parameters.
            adapter.InsertCommand.Parameters.Add("@CategoryName", SqlDbType.NChar, 15, "CategoryName");

            // Create an output parameter for the new identity value.
            parameter = adapter.InsertCommand.Parameters.Add("@Identity", SqlDbType.Int, 0, "CategoryID");
            parameter.Direction = ParameterDirection.Output;

            // Create a DataTable and fill it.
            DataTable categories = new();
            adapter.Fill(categories);

            // Add a new row.
            DataRow categoryRow = categories.NewRow();
            categoryRow["CategoryName"] = "New Beverages";
            categories.Rows.Add(categoryRow);

            // Update the database.
            adapter.Update(categories);

            // Retrieve the ReturnValue.
            var rowCount = (int)adapter.InsertCommand.Parameters["@RowCount"].Value;

            Console.WriteLine($"ReturnValue: {rowCount.ToString()}");
            Console.WriteLine("All Rows:");
            foreach (DataRow row in categories.Rows)
            {
                Console.WriteLine($"  {row[0]}: {row[1]}");
            }
        }
        // </Snippet1>
    }

    static string GetConnectionString() =>
        throw new NotImplementedException();
}
