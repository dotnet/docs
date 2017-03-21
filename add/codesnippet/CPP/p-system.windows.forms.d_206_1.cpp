   // Style and number columns.
   void Button8_Click( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      DataGridViewCellStyle^ style = gcnew DataGridViewCellStyle;
      style->Alignment = DataGridViewContentAlignment::MiddleCenter;
      style->ForeColor = Color::IndianRed;
      style->BackColor = Color::Ivory;
      IEnumerator^ myEnum1 = dataGridView->Columns->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         DataGridViewColumn^ column = safe_cast<DataGridViewColumn^>(myEnum1->Current);
         column->HeaderCell->Value = column->Index.ToString();
         column->HeaderCell->Style = style;
      }
   }

