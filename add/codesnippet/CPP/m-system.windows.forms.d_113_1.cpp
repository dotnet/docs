   // On Click of Button "Unselect Row" this event is raised.
private:
   void UnselectRow_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Unselect the current row from the Datagrid
      myDataGrid->UnSelect( myDataGrid->CurrentRowIndex );
   }