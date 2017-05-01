using System;
using System.Data;


public class Sample
{

    //<Snippet1>
    private void RemoveColumn(string columnName, DataTable table)
    {
        DataColumnCollection columns = table.Columns;
        if (columns.Contains(columnName))
            if (columns.CanRemove(columns[columnName]))
                columns.Remove(columnName);
    }
    //</Snippet1>
}
