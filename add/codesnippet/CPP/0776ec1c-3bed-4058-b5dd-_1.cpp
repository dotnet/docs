   // Swap the last column with the first.
   void Button10_Click( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      DataGridViewColumnCollection^ columnCollection = dataGridView->Columns;
      DataGridViewColumn^ firstDisplayedColumn = columnCollection->GetFirstColumn( DataGridViewElementStates::Visible );
      DataGridViewColumn^ lastDisplayedColumn = columnCollection->GetLastColumn( DataGridViewElementStates::Visible, DataGridViewElementStates::None );
      int firstColumn_sIndex = firstDisplayedColumn->DisplayIndex;
      firstDisplayedColumn->DisplayIndex = lastDisplayedColumn->DisplayIndex;
      lastDisplayedColumn->DisplayIndex = firstColumn_sIndex;
   }

