    void VirtualConnector::dataGridView1_NewRowNeeded
        (Object^ sender, DataGridViewRowEventArgs^ e)
    {
        newRowNeeded = true;
    }

    void VirtualConnector::dataGridView1_RowsAdded
        (Object^ sender, DataGridViewRowsAddedEventArgs^ e)
    {
        if (newRowNeeded)
        {
            newRowNeeded = false;
            numberOfRows = numberOfRows + 1;
        }
    }

#pragma region Data store maintance

    void VirtualConnector::dataGridView1_CellValueNeeded
        (Object^ sender, DataGridViewCellValueEventArgs^ e)
    {
        if (store->ContainsKey(e->RowIndex))
        {
            // Use the store if the e value has been modified 
            // and stored.            
            e->Value = gcnew Int32(store->default[e->RowIndex]); 
        }
        else if (newRowNeeded && e->RowIndex == numberOfRows)
        {
            if (dataGridView1->IsCurrentCellInEditMode)
            {
                e->Value = initialValue;
            }
            else
            {
                // Show a blank e if the cursor is just loitering
                // over(the) last row.
                e->Value = String::Empty;
            }
        }
        else
        {
            e->Value = e->RowIndex;
        }
    }

    void VirtualConnector::dataGridView1_CellValuePushed
        (Object^ sender, DataGridViewCellValueEventArgs^ e)
    {
        String^ value = e->Value->ToString();
        store[e->RowIndex] = Int32::Parse(value, 
            CultureInfo::CurrentCulture);
    }
#pragma endregion