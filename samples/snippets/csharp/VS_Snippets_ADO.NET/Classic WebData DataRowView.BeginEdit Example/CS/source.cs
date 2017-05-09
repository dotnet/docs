using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected TextBox textBox1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    private void EditDataRowView(DataRowView rowView, 
        string columnToEdit) 
    {
        rowView.BeginEdit();
        rowView[columnToEdit] = textBox1.Text;

        // Validate the input with a function.
        if (ValidateCompanyName(rowView[columnToEdit]))
            rowView.EndEdit();   
        else
            rowView.CancelEdit();
    }
 
    private bool ValidateCompanyName(object valuetoCheck) 
    {
        // Insert code to validate the value.
        return true;
    }
    // </Snippet1>

}
