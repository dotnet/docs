   // Make the the entire DataGridView read only.
   void Button8_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      System::Collections::IEnumerator^ myEnum = dataGridView->Columns->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridViewBand^ band = safe_cast<DataGridViewBand^>(myEnum->Current);
         band->ReadOnly = true;
      }
   }

