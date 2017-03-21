   // Set row labels.
   void Button6_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {

      int rowNumber = 1;
      System::Collections::IEnumerator^ myEnum = safe_cast<System::Collections::IEnumerable^>(dataGridView->Rows)->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridViewRow^ row = safe_cast<DataGridViewRow^>(myEnum->Current);
         if ( row->IsNewRow )
                  continue;
         row->HeaderCell->Value = String::Format( L"Row {0}", rowNumber );

         rowNumber = rowNumber + 1;
      }

      dataGridView->AutoResizeRowHeadersWidth( DataGridViewRowHeadersWidthSizeMode::AutoSizeToAllHeaders );
   }

