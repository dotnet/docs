private:
   void myButton_Click( Object^ sender, EventArgs^ e )
   {
      FontDialog^ myFontDialog = gcnew FontDialog;
      if ( myFontDialog->ShowDialog() == ::DialogResult::OK )
      {
         // Set the control's font.
         myDateTimePicker->Font = myFontDialog->Font;
      }
   }