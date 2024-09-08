using System;
using System.Data;
using System.Data.SqlClient;

namespace NextResultCS;

static class Program
{
    static void Main()
    {
        var s = GetConnectionString();
        SqlConnection c = new(s);
        GetSchemaInfo(c);
        Console.ReadLine();
    }
    // <Snippet1>
    static void GetSchemaInfo(SqlConnection connection)
    {
        using (connection)
        {
            SqlCommand command = new(
              "SELECT CategoryID, CategoryName FROM Categories;",
              connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            foreach (DataRow row in schemaTable.Rows)
            {
                foreach (DataColumn column in schemaTable.Columns)
                {
                    Console.WriteLine(string.Format("{0} = {1}",
                       column.ColumnName, row[column]));
                }
            }
        }
    }
    // </Snippet1>

    static string GetConnectionString() =>
        throw new NotImplementedException();
}
