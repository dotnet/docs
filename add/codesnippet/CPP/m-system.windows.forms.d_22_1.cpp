   // Give cheescake excellent rating.
   void Button8_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      UpdateStars( dataGridView->Rows[ 4 ], L"******************" );
   }

   int ratingColumn;
   void UpdateStars( DataGridViewRow^ row, String^ stars )
   {
      row->Cells[ ratingColumn ]->Value = stars;
      
      // Resize the column width to account for the new value.
      row->DataGridView->AutoResizeColumn( ratingColumn, DataGridViewAutoSizeColumnMode::DisplayedCells );
   }

