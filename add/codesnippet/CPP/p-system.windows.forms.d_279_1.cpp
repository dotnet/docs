   // Freeze the first row.
   void Button4_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      FreezeBand( dataGridView->Rows[ 0 ] );
   }

   void Button5_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      FreezeBand( dataGridView->Columns[ 1 ] );
   }

   void FreezeBand( DataGridViewBand^ band )
   {
      band->Frozen = true;
      DataGridViewCellStyle^ style = gcnew DataGridViewCellStyle;
      style->BackColor = Color::WhiteSmoke;
      band->DefaultCellStyle = style;
   }

