   void Button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Resize the height of the column headers. 
      dataGridView1->AutoResizeColumnHeadersHeight();

      // Resize all the row heights to fit the contents of all non-header cells.
      dataGridView1->AutoResizeRows(
            DataGridViewAutoSizeRowsMode::AllCellsExceptHeaders);
   }