using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetChildRowsFromDataRelation(DataTable table) 
    {
        DataRow[] arrRows;  
        foreach(DataRelation relation in table.ChildRelations)
        {
            foreach(DataRow row in table.Rows)
            {
                arrRows = row.GetChildRows(relation);
                // Print values of rows.
                for(int i = 0; i < arrRows.Length; i++)
                {
                    foreach(DataColumn column in table.Columns)
                    {
                        Console.WriteLine(arrRows[i][column]);
                    }
                }
            }
        }
    }
    // </Snippet1>

}
