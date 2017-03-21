   // This example demonstrates how to use the KeyDown event with the Help class to display
   // pop-up style help to the user of the application. The example filters for all variations
   // of pressing the F1 key with a modifier key by using the KeyEventArgs properties passed
   // to the event handling method.
   // When the user presses any variation of F1 that includes any keyboard modifier, the Help
   // class displays a pop-up window, similar to a ToolTip, near the control. If the user presses
   // ALT + F2, a different Help pop-up is displayed with additional information. This example assumes
   // that a tTextBox control, named textBox1, has been added to the form and its KeyDown
   // event has been contected to this event handling method.
private:
   void textBox1_KeyDown( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      // Determine whether the key entered is the F1 key. If it is, display Help.
      if ( e->KeyCode == Keys::F1 && (e->Alt || e->Control || e->Shift) )
      {
         
         // Display a pop-up Help topic to assist the user.
         Help::ShowPopup( textBox1, "Enter your name.", Point(textBox1->Bottom,textBox1->Right) );
      }
      else
      if ( e->KeyCode == Keys::F2 && e->Modifiers == Keys::Alt )
      {
         // Display a pop-up Help topic to provide additional assistance to the user.
         Help::ShowPopup( textBox1, "Enter your first name followed by your last name. Middle name is optional.",
            Point(textBox1->Top,this->textBox1->Left) );
      }
   }