using System;
using System.Data;

public class Sample
{

    // <Snippet1>
    private static void WriteViewRows(DataView view)
    {
        int colCount = view.Table.Columns.Count;

        // Iterate through the rows of the DataView.
        foreach (DataRowView rowView in view)
        {
            // Display the value in each item of the DataRowView
            for (int i = 0; i < colCount; i++)
                Console.Write(rowView[i] + "\table");
            Console.WriteLine();
        }
    }
    // </Snippet1>

}
