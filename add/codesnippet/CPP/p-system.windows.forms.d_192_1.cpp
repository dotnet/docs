   // Change the text in the column header.
   void Button9_Click( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      IEnumerator^ myEnum2 = dataGridView->Columns->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         DataGridViewColumn^ column = safe_cast<DataGridViewColumn^>(myEnum2->Current);
         column->HeaderText = String::Concat( L"Column ", column->Index.ToString() );
      }
   }

