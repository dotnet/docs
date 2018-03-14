using System;
using System.Data;

namespace UniqueConstraintUniqueConstraint2CS
{
    class Program
    {
        static void Main()
        {
            MakeTableWithUniqueConstraint();
            Console.ReadLine();
        }

        // <Snippet1>
        static private void MakeTableWithUniqueConstraint()
        {
            // Create a DataTable with 2 DataColumns.
            DataTable dataTable = new DataTable("dataTable");
            DataColumn idColumn = new DataColumn(
                "id", System.Type.GetType("System.Int32"));
            DataColumn nameColumn = new DataColumn(
                "Name", System.Type.GetType("System.String"));
            dataTable.Columns.Add(idColumn);
            dataTable.Columns.Add(nameColumn);

            // Run procedure to create a constraint.
            AddUniqueConstraint(dataTable);

            // Add one row to the table.
            DataRow dataRow;
            dataRow = dataTable.NewRow();
            dataRow["id"] = 1;
            dataRow["Name"] = "John";
            dataTable.Rows.Add(dataRow);

            // Display the constraint name. 
            Console.WriteLine(
                dataTable.Constraints[0].ConstraintName);

            // Try to add an identical row, 
            // which throws an exception.
            try
            {
                dataRow = dataTable.NewRow();
                dataRow["id"] = 1;
                dataRow["Name"] = "John";
                dataTable.Rows.Add(dataRow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Exception Type: {0}", ex.GetType());
                Console.WriteLine(
                    "Exception Message: {0}", ex.Message);
            }
        }
        static private void AddUniqueConstraint(
            DataTable dataTable)
        {
            // Create the DataColumn array.
            DataColumn[] dataColumns = new DataColumn[2];
            dataColumns[0] = dataTable.Columns["id"];
            dataColumns[1] = dataTable.Columns["Name"];

            // Create the constraint on both columns.
            UniqueConstraint uniqueConstraint =
                new UniqueConstraint("idNameConstraint", dataColumns);
            dataTable.Constraints.Add(uniqueConstraint);
        }
        // </Snippet1>
    }
}
