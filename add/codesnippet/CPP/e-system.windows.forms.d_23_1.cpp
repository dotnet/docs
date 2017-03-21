private:
    void DataGridView1_CellContentClick(Object^ /*sender*/, DataGridViewCellEventArgs^ e)
    {

        if (IsANonHeaderLinkCell(e))
        {
            MoveToLinked(e);
        }
        else if (IsANonHeaderButtonCell(e))
        {
            PopulateSales(e);
        }
    }

private:
    void MoveToLinked(DataGridViewCellEventArgs^ e)
    {
        String^ employeeId;
        Object^ value = DataGridView1->Rows[e->RowIndex]->Cells[e->ColumnIndex]->Value;
        if (dynamic_cast<DBNull^>(value) != nullptr) { return; }

        employeeId = value->ToString();
        DataGridViewCell^ boss = RetrieveSuperiorsLastNameCell(employeeId);
        if (boss != nullptr)
        {
            DataGridView1->CurrentCell = boss;
        }
    }

private:
    bool IsANonHeaderLinkCell(DataGridViewCellEventArgs^ cellEvent)
    {
        if (dynamic_cast<DataGridViewLinkColumn^>(DataGridView1->Columns[cellEvent->ColumnIndex]) != nullptr
             &&
            cellEvent->RowIndex != -1)
        { return true; }
        else { return false; }
    }

private:
    bool IsANonHeaderButtonCell(DataGridViewCellEventArgs^ cellEvent)
    {
        if (dynamic_cast<DataGridViewButtonColumn^>(DataGridView1->Columns[cellEvent->ColumnIndex]) != nullptr
             &&
            cellEvent->RowIndex != -1)
        { return true; }
        else { return (false); }
    }

private:
    DataGridViewCell^ RetrieveSuperiorsLastNameCell(String^ employeeId)
    {

        for each (DataGridViewRow^ row in DataGridView1->Rows)
        {
            if (row->IsNewRow) { return nullptr; }
            if (row->Cells[ColumnName::EmployeeID.ToString()]->Value->ToString()->Equals(employeeId))
            {
                return row->Cells[ColumnName::LastName.ToString()];
            }
        }
        return nullptr;
    }