   // Set a thick horizontal edge.
   void Button7_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      int secondRow = 1;
      int edgeThickness = 3;
      DataGridViewRow^ row = dataGridView->Rows[ secondRow ];
      row->DividerHeight = 10;
   }

