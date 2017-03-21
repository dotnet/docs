   //Set the minimum width.
   void Button4_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewColumn^ column = dataGridView->Columns[ 1 ];
      column->MinimumWidth = 40;
   }

