   // This example demonstrates how to use the KeyUp event with the Help class to display
   // pop-up style help to the user of the application. When the user presses F1, the Help
   // class displays a pop-up window, similar to a ToolTip, near the control. This example assumes
   // that a TextBox control, named textBox1, has been added to the form and its KeyUp
   // event has been connected to this event handler method.
private:
   void textBox1_KeyUp( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      
      // Determine whether the key entered is the F1 key. Display help if it is.
      if ( e->KeyCode == Keys::F1 )
      {
         
         // Display a pop-up help topic to assist the user.
         Help::ShowPopup( textBox1, "Enter your first name", Point(textBox1->Right,this->textBox1->Bottom) );
      }
   }