    ToolStripMenuItem^ wholeTable;
    ToolStripMenuItem^ lookUp;
    System::Windows::Forms::ContextMenuStrip^ strip;
    String^ cellErrorText;

    void dataGridView1_CellContextMenuStripNeeded( Object^ /*sender*/,
        DataGridViewCellContextMenuStripNeededEventArgs^ e )
    {
        cellErrorText = String::Empty;
        if ( strip == nullptr )
        {
            strip = gcnew System::Windows::Forms::ContextMenuStrip;
            lookUp->Text = L"Look Up";
            wholeTable->Text = L"See Whole Table";
            strip->Items->Add( lookUp );
            strip->Items->Add( wholeTable );
        }

        e->ContextMenuStrip = strip;
    }

    void wholeTable_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
    {
        dataGridView1->DataSource = Populate( L"Select * from employees", true );
    }

    DataGridViewCellEventArgs^ theCellImHoveringOver;
    void dataGridView1_CellMouseEnter( Object^ /*sender*/, DataGridViewCellEventArgs^ e )
    {
        theCellImHoveringOver = e;
    }

    DataGridViewCellEventArgs^ cellErrorLocation;
    void lookUp_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
    {
        try
        {
            dataGridView1->DataSource = Populate( String::Format( L"Select * from employees where {0} = '{1}'", dataGridView1->Columns[ theCellImHoveringOver->ColumnIndex ]->Name, dataGridView1->Rows[ theCellImHoveringOver->RowIndex ]->Cells[ theCellImHoveringOver->ColumnIndex ]->Value ), true );
        }
        catch ( ... ) 
        {
            cellErrorText = L"Can't look this cell up";
            cellErrorLocation = theCellImHoveringOver;
        }

    }

    void dataGridView1_CellErrorTextNeeded( Object^ /*sender*/, DataGridViewCellErrorTextNeededEventArgs^ e )
    {
        if ( cellErrorLocation != nullptr )
        {
            if ( e->ColumnIndex == cellErrorLocation->ColumnIndex && e->RowIndex == cellErrorLocation->RowIndex )
            {
                e->ErrorText = cellErrorText;
            }
        }
    }

    DataTable^ Populate( String^ query, bool resetUnsharedCounter )
    {
        if ( resetUnsharedCounter )
        {
            ResetCounter();
        }


        // Alter the data source as necessary
        SqlDataAdapter^ adapter = gcnew SqlDataAdapter( query,
            gcnew SqlConnection( L"Integrated Security=SSPI;Persist Security Info=False;"
            L"Initial Catalog=Northwind;Data Source= localhost" ) );
        DataTable^ table = gcnew DataTable;
        adapter->Fill( table );
        return table;
    }

    Label^ count;
    int unsharedRowCounter;
    void ResetCounter()
    {
        unsharedRowCounter = 0;
        count->Text = unsharedRowCounter.ToString();
    }