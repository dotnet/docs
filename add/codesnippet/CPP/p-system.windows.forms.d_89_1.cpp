   void CreateColumns()
   {
      DataGridViewImageColumn^ imageColumn;
      int columnCount = 0;
      do
      {
         Bitmap^ unMarked = blank;
         imageColumn = gcnew DataGridViewImageColumn;
         
         //Add twice the padding for the left and 
         //right sides of the cell.
         imageColumn->Width = x->Width + 2 * bitmapPadding + 1;
         imageColumn->Image = unMarked;
         dataGridView1->Columns->Add( imageColumn );
         columnCount = columnCount + 1;
      }
      while ( columnCount < 3 );
   }

