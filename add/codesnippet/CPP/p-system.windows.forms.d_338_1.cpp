private:
    void AddOutOfOfficeColumn()
    {
        DataGridViewCheckBoxColumn^ column = gcnew DataGridViewCheckBoxColumn();
        {
            column->HeaderText = ColumnName::OutOfOffice.ToString();
            column->Name = ColumnName::OutOfOffice.ToString();
            column->AutoSizeMode = 
                DataGridViewAutoSizeColumnMode::DisplayedCells;
            column->FlatStyle = FlatStyle::Standard;
            column->ThreeState = true;
            column->CellTemplate = gcnew DataGridViewCheckBoxCell();
            column->CellTemplate->Style->BackColor = Color::Beige;
        }

        DataGridView1->Columns->Insert(0, column);
    }