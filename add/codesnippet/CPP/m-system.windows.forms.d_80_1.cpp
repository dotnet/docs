private:
   void SetHeaderText( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Set the HeaderText property.
      myDataGridColumnStyle->HeaderText = "Emp ID";
      myDataGrid->Invalidate();
   }

   void ResetHeaderText( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Reset the HeaderText property to its default value.
      myDataGridColumnStyle->ResetHeaderText();
      myDataGrid->Invalidate();
   }