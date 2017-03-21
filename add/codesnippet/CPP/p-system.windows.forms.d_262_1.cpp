   // Hide a band of cells.
   void Button6_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewBand^ band = dataGridView->Rows[ 3 ];
      band->Visible = false;
   }

