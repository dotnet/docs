using System;
using System.Data;
using System.Data.SqlTypes;

static class Program
{
    static void Main()
    {
        WorkWithSqlNulls();
        Console.ReadLine();
    }
    // <Snippet1>
    static void WorkWithSqlNulls()
    {
        DataTable table = new();

        // Specify the SqlType for each column.
        DataColumn idColumn =
            table.Columns.Add("ID", typeof(SqlInt32));
        DataColumn descColumn =
            table.Columns.Add("Description", typeof(SqlString));

        // Add some data.
        DataRow nRow = table.NewRow();
        nRow["ID"] = 123;
        nRow["Description"] = "Side Mirror";
        table.Rows.Add(nRow);

        // Add null values.
        nRow = table.NewRow();
        nRow["ID"] = SqlInt32.Null;
        nRow["Description"] = SqlString.Null;
        table.Rows.Add(nRow);

        // Initialize variables to use when
        // extracting the data.
        SqlBoolean isColumnNull = false;
        SqlInt32 idValue = SqlInt32.Zero;
        SqlString descriptionValue = SqlString.Null;

        // Iterate through the DataTable and display the values.
        foreach (DataRow row in table.Rows)
        {
            // Assign values to variables. Note that you
            // do not have to test for null values.
            idValue = (SqlInt32)row["ID"];
            descriptionValue = (SqlString)row["Description"];

            // Test for null value in ID column.
            isColumnNull = idValue.IsNull;

            // Display variable values in console window.
            Console.Write("isColumnNull={0}, ID={1}, Description={2}",
                isColumnNull, idValue, descriptionValue);
            Console.WriteLine();
        }
        // </Snippet1>
    }
}
