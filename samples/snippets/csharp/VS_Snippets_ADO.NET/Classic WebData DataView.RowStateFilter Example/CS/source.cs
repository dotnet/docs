#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

#endregion

namespace DataViewRowStateFilterCS
{
    class Program
    {
        static void Main()
        {
            DemonstrateRowState();
            Console.ReadLine();

        }
        // <Snippet1>
        static private void DemonstrateRowState()
        {
            // Create a DataTable with one column.
            DataTable dataTable = new DataTable("dataTable");
            DataColumn dataColumn = new DataColumn("dataColumn");
            dataTable.Columns.Add(dataColumn);

            // Add ten rows.
            DataRow dataRow;
            for (int i = 0; i < 10; i++)
            {
                dataRow = dataTable.NewRow();
                dataRow["dataColumn"] = "item " + i;
                dataTable.Rows.Add(dataRow);
            }
            dataTable.AcceptChanges();

            // Create a DataView with the table.
            DataView dataView = new DataView(dataTable);

            // Change one row's value:
            dataTable.Rows[1]["dataColumn"] = "Hello";

            // Add one row:
            dataRow = dataTable.NewRow();
            dataRow["dataColumn"] = "World";
            dataTable.Rows.Add(dataRow);

            // Set the RowStateFilter to display only added and modified rows.
            dataView.RowStateFilter = DataViewRowState.Added
                | DataViewRowState.ModifiedCurrent;

            // Print those rows. Output = "Hello" "World";
            PrintView(dataView, "ModifiedCurrent and Added");

            // Set filter to display on originals of modified rows.
            dataView.RowStateFilter = DataViewRowState.ModifiedOriginal;
            PrintView(dataView, "ModifiedOriginal");

            // Delete three rows.
            dataTable.Rows[1].Delete();
            dataTable.Rows[2].Delete();
            dataTable.Rows[3].Delete();

            // Set the RowStateFilter to display only Added and modified rows.
            dataView.RowStateFilter = DataViewRowState.Deleted;
            PrintView(dataView, "Deleted");

            //Set filter to display only current.
            dataView.RowStateFilter = DataViewRowState.CurrentRows;
            PrintView(dataView, "Current");

            // Set filter to display only unchanged rows.
            dataView.RowStateFilter = DataViewRowState.Unchanged;
            PrintView(dataView, "Unchanged");

            // Set filter to display only original rows.
            dataView.RowStateFilter = DataViewRowState.OriginalRows;
            PrintView(dataView, "OriginalRows");
        }


        static private void PrintView(DataView dataView, string label)
        {
            Console.WriteLine("\n" + label);
            for (int i = 0; i < dataView.Count; i++)
            {
                Console.WriteLine(dataView[i]["dataColumn"]);
            }
        }
        // </Snippet1>


    }
}
