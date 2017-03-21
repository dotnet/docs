    void VirtualConnector::dataGridView1_RowsAdded
        (Object^ sender, DataGridViewRowsAddedEventArgs^ e)
    {
        if (newRowNeeded)
        {
            newRowNeeded = false;
            numberOfRows = numberOfRows + 1;
        }
    }