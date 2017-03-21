   // Set the vertical edge.
   void Button7_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      int thirdColumn = 2;
      
      //        int edgeThickness = 5;
      DataGridViewColumn^ column = dataGridView->Columns[ thirdColumn ];
      column->DividerWidth = 10;
   }

