private:
   // Clicking Button1 causes a message box to appear.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "Click here!" );
   }

   // Use the SendKeys.Send method to raise the Button1 click event 
   // and display the message box.
   void Form1_DoubleClick( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Send the enter key; since the tab stop of Button1 is 0, this
      // will trigger the click event.
      SendKeys::Send( "{ENTER}" );
   }