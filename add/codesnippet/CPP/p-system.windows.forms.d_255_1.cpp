private:
    void DataGridView1_DataError(Object^ sender, DataGridViewDataErrorEventArgs^ anError)
    {

        MessageBox::Show("Error happened " + anError->Context.ToString());

        if (anError->Context == DataGridViewDataErrorContexts::Commit)
        {
            MessageBox::Show("Commit error");
        }
        if (anError->Context == DataGridViewDataErrorContexts::CurrentCellChange)
        {
            MessageBox::Show("Cell change");
        }
        if (anError->Context == DataGridViewDataErrorContexts::Parsing)
        {
            MessageBox::Show("parsing error");
        }
        if (anError->Context == DataGridViewDataErrorContexts::LeaveControl)
        {
            MessageBox::Show("leave control error");
        }

        if (dynamic_cast<ConstraintException^>(anError->Exception) != nullptr)
        {
            DataGridView^ view = (DataGridView^)sender;
            view->Rows[anError->RowIndex]->ErrorText = "an error";
            view->Rows[anError->RowIndex]->Cells[anError->ColumnIndex]->ErrorText = "an error";

            anError->ThrowException = false;
        }
    }