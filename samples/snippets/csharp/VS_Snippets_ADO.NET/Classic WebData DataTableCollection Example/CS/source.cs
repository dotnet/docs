using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{
    // <Snippet1>
    private void GetTables(DataSet dataSet)
    {
        // Get Each DataTable in the DataTableCollection and 
        // print each row value.
        foreach (DataTable table in dataSet.Tables)
            foreach (DataRow row in table.Rows)
                foreach (DataColumn column in table.Columns)
                    if (row[column] != null)
                        Console.WriteLine(row[column]);
    }

    private void CreateTable(DataSet dataSet)
    {
        DataTable newTable = new DataTable("table");
        newTable.Columns.Add("ID", typeof(int));
        newTable.Columns.Add("Name", typeof(string));
        dataSet.Tables.Add(newTable);
    }
    // </Snippet1>
}