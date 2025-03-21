using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
    static void Main()
    {
        var connectionString = GetConnectionString();
        AdapterUpdate(connectionString);
        Console.ReadLine();
    }
    // <Snippet1>
    static void AdapterUpdate(string connectionString)
    {
        using (SqlConnection connection =
                   new(connectionString))
        {
            SqlDataAdapter dataAdapter = new(
              "SELECT CategoryID, CategoryName FROM Categories",
              connection)
            {
                UpdateCommand = new SqlCommand(
               "UPDATE Categories SET CategoryName = @CategoryName " +
               "WHERE CategoryID = @CategoryID", connection)
            };

            dataAdapter.UpdateCommand.Parameters.Add(
               "@CategoryName", SqlDbType.NVarChar, 15, "CategoryName");

            SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add(
              "@CategoryID", SqlDbType.Int);
            parameter.SourceColumn = "CategoryID";
            parameter.SourceVersion = DataRowVersion.Original;

            DataTable categoryTable = new();
            dataAdapter.Fill(categoryTable);

            DataRow categoryRow = categoryTable.Rows[0];
            categoryRow["CategoryName"] = "New Beverages";

            dataAdapter.Update(categoryTable);

            Console.WriteLine("Rows after update.");
            foreach (DataRow row in categoryTable.Rows)
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
