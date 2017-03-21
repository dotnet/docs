   // AutoSize the third column.
   void Button6_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewColumn^ column = dataGridView->Columns[ 2 ];
      column->AutoSizeMode = DataGridViewAutoSizeColumnMode::DisplayedCells;
   }

