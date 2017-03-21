   // Create an instance of the 'BackgroundColorChanged' EventHandler.
private:
   void CallBackgroundColorChanged()
   {
      myDataGrid->BackgroundColorChanged += gcnew EventHandler( this, &MyDataGrid::Grid_ColChange );
   }

   // Set the 'BackgroundColor' property on click of button.
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->BackgroundColor == Color::Yellow )
      {
         myDataGrid->BackgroundColor = Color::Red;
      }
      else
      {
         myDataGrid->BackgroundColor = Color::Yellow;
      }
   }

   // Raise the event when 'Background' color of DataGrid changes.
   void Grid_ColChange( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "BackgroundColorChanged event raised, changed to ";

      // Get the background color of DataGrid.
      Color myColor = myDataGrid->BackgroundColor;
      myString = String::Concat( myString, myColor );

      // Show information about background color setting.
      MessageBox::Show( myString, "Background color information" );
   }