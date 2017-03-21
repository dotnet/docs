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

    void dataGridView1_CellToolTipTextNeeded( Object^ /*sender*/,
        DataGridViewCellToolTipTextNeededEventArgs^ e )
    {
        if ( theCellImHoveringOver->ColumnIndex == dataGridView1->Columns[ L"ReportsTo" ]->Index && theCellImHoveringOver->RowIndex > -1 )
        {
            String^ reportsTo = dataGridView1->Rows[ theCellImHoveringOver->RowIndex ]->Cells[ theCellImHoveringOver->ColumnIndex ]->Value->ToString();
            if ( reportsTo->Equals( L"" ) )
            {
                e->ToolTipText = L"The buck stops here!";
            }
            else
            {
                DataTable^ table = Populate( String::Format( L"select firstname, lastname from employees where employeeid = '{0}'",
                    dataGridView1->Rows[ theCellImHoveringOver->RowIndex ]->Cells[ theCellImHoveringOver->ColumnIndex ]->Value ), false );
                e->ToolTipText = String::Format( L"Reports to {0} {1}", table->Rows[ 0 ]->ItemArray[ 0 ], table->Rows[ 0 ]->ItemArray[ 1 ] );
            }
        }
    }

