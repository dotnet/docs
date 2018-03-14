using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetAllErrs(DataRow row)
    {
        // Declare an array variable for DataColumn objects.
        DataColumn[] colArr; 
        // If the Row has errors, check use GetColumnsInError.
        if(row.HasErrors)
        {
            // Get the array of columns in error.
            colArr = row.GetColumnsInError();
            for(int i = 0; i < colArr.Length; i++)
            {
                // Insert code to fix errors on each column.
                Console.WriteLine(colArr[i].ColumnName);
            }
            // Clear errors after reconciling.
            row.ClearErrors();
        }
    }
    // </Snippet1>

}
