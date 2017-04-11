using System;
using System.Data;

namespace DataRowViewRowVersionCS
{
    class Program
    {
        static void Main()
        {
            DemonstrateRowVersion();
            Console.ReadLine();
        }
        // <Snippet1>
        private static void DemonstrateRowVersion()
        {
            // Create a DataTable with one column.
            DataTable table = new DataTable("Table");
            DataColumn column = new DataColumn("Column");
            table.Columns.Add(column);

            // Add ten rows.
            DataRow row;
            for (int i = 0; i < 10; i++)
            {
                row = table.NewRow();
                row["Column"] = "item " + i;
                table.Rows.Add(row);
            }

            table.AcceptChanges();
            // Create a DataView with the table.
            DataView view = new DataView(table);

            // Change one row's value:
            table.Rows[1]["Column"] = "Hello";

            // Add one row:
            row = table.NewRow();
            row["Column"] = "World";
            table.Rows.Add(row);

            // Set the RowStateFilter to display only added 
            // and modified rows.
            view.RowStateFilter = DataViewRowState.Added | 
                DataViewRowState.ModifiedCurrent;

            // Print those rows. Output includes "Hello" and "World".
            PrintView(view, "ModifiedCurrent and Added");

            // Set filter to display only originals of modified rows.
            view.RowStateFilter = DataViewRowState.ModifiedOriginal;
            PrintView(view, "ModifiedOriginal");

            // Delete three rows.
            table.Rows[1].Delete();
            table.Rows[2].Delete();
            table.Rows[3].Delete();

            // Set the RowStateFilter to display only deleted rows.
            view.RowStateFilter = DataViewRowState.Deleted;
            PrintView(view, "Deleted");

            // Set filter to display only current rows.
            view.RowStateFilter = DataViewRowState.CurrentRows;
            PrintView(view, "Current");

            // Set filter to display only unchanged rows.
            view.RowStateFilter = DataViewRowState.Unchanged;
            PrintView(view, "Unchanged");

            // Set filter to display only original rows.
            // Current values of unmodified rows are also returned.
            view.RowStateFilter = DataViewRowState.OriginalRows;
            PrintView(view, "OriginalRows");
        }

        private static void PrintView(DataView view, string label)
        {
            Console.WriteLine("\n" + label);
            for (int i = 0; i < view.Count; i++)
            {
                Console.WriteLine(view[i]["Column"]);
                Console.WriteLine("DataViewRow.RowVersion: {0}", 
                    view[i].RowVersion);
            }
        }
        // </Snippet1>
    }
}
