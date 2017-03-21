private:
   void Clear_Clicked( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // TablesAlreadyAdded set to false so that table styles can be added again.
      TablesAlreadyAdded = false;
      myLabel->Text = "All Table Styles Cleared.";

      // Clear all the column styles and also table style for the grid.
      IEnumerator^ myEnum = myDataGrid->TableStyles->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridTableStyle^ myTableStyle = safe_cast<DataGridTableStyle^>(myEnum->Current);
         GridColumnStylesCollection^ myColumns = myTableStyle->GridColumnStyles;
         myColumns->Clear();
      }

      myDataGrid->TableStyles->Clear();
   }