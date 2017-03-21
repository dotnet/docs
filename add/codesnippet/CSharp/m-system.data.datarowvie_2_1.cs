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