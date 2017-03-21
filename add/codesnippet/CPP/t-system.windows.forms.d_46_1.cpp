    void VirtualConnector::dataGridView1_CellValidating
        (Object^ sender, DataGridViewCellValidatingEventArgs^ e)
    {
        int newInteger;

        // Don't try to validate the 'new row' until finished 
        // editing since there
        // is not any point in validating its initial value.
        if (dataGridView1->Rows[e->RowIndex]->IsNewRow) 
        {
            return; 
        }
        if (!Int32::TryParse(e->FormattedValue->ToString(), 
            newInteger) || (newInteger < 0))
        {
            e->Cancel = true;
        }
    }