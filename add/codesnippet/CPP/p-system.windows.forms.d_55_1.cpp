   // Set the width.
   void Button5_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewColumn^ column = dataGridView->Columns[ 0 ];
      column->Width = 60;
   }

