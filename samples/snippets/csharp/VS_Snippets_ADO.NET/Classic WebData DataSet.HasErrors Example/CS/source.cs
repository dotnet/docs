using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataSet DataSet2;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void CheckForErrors()
    {
        if(!DataSet1.HasErrors)
        {
            DataSet1.Merge(DataSet2);
        }
        else
        {
            PrintRowErrs(DataSet1);
        }
    }
 
    private void PrintRowErrs(DataSet dataSet)
    {
        foreach(DataTable table in dataSet.Tables)
        {
            foreach(DataRow row in table.Rows)
            {
                if(row.HasErrors)
                {
                    Console.WriteLine(row.RowError);
                }
            }
        }
    }
    // </Snippet1>

}
