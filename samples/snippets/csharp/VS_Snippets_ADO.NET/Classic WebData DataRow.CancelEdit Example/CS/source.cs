using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AcceptOrReject(DataRow row)
    {
        // Use a function to validate the row's values.
        // If the function returns true, end the edit;
        // otherwise cancel it.
        if(ValidateRow(row))
            row.EndEdit();
        else
            row.CancelEdit();
    }
 
    private bool ValidateRow(DataRow thisRow)
    {
        bool isValid = true; 
        // Insert code to validate the row values. 
        // Set the isValid variable.
        return isValid;
    }
    // </Snippet1>

}
