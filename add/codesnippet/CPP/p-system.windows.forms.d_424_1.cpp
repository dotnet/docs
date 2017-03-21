   // Set minimum height.
   void Button4_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      int secondRow = 1;
      DataGridViewRow^ row = dataGridView->Rows[ secondRow ];
      row->MinimumHeight = 40;
   }

