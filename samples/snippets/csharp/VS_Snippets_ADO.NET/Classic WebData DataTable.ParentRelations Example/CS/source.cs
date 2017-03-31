using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void GetChildRowsFromDataRelation(DataTable table)
    {
        DataRow[] rowArray;
        foreach(DataRelation relation in table.ParentRelations)
        {
            foreach(DataRow row in table.Rows)
            {
                rowArray = row.GetParentRows(relation);
                // Print values of rows.
                for(int i = 0; i < rowArray.Length; i++)
                {
                    foreach(DataColumn column in table.Columns)
                    {
                        Console.WriteLine(rowArray[i][column]);
                    }
                }
            }
        }
    }
    // </Snippet1>

}
