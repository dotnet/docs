   // Handle event to show the state of 'IsInEditOrNavigateMode'.
private:
   void Button_ClickEvent( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGridTextBox->IsInEditOrNavigateMode )
      {
         // DataGridTextBox has not been edited.
         MessageBox::Show( "Editing of DataGridTextBox not begun, IsInEditOrNavigateMode = True" );
      }
      else
      {         
         // DataGridTextBox has been edited.
         MessageBox::Show( "Editing of DataGridTextBox begun, IsInEditOrNavigateMode = False" );
      }
   }