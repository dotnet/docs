   ToolStripMenuItem^ toolStripItem1;
   void AddContextMenu()
   {
      toolStripItem1->Text = L"Redden";
      toolStripItem1->Click += gcnew EventHandler( this, &DataGridViewColumnDemo::toolStripItem1_Click );
      System::Windows::Forms::ContextMenuStrip^ strip = gcnew System::Windows::Forms::ContextMenuStrip;
      IEnumerator^ myEnum = dataGridView->Columns->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridViewColumn^ column = safe_cast<DataGridViewColumn^>(myEnum->Current);
         column->ContextMenuStrip = strip;
         column->ContextMenuStrip->Items->Add( toolStripItem1 );
      }
   }

   DataGridViewCellEventArgs^ mouseLocation;

   // Change the cell's color.
   void toolStripItem1_Click( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      dataGridView->Rows[ mouseLocation->RowIndex ]->Cells[ mouseLocation->ColumnIndex ]->Style->BackColor = Color::Red;
   }


   // Deal with hovering over a cell.
   void dataGridView_CellMouseEnter( Object^ /*sender*/, DataGridViewCellEventArgs^ location )
   {
      mouseLocation = location;
   }

