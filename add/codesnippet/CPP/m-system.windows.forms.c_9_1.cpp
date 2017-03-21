   private:
      void myButton_MouseEnter( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Hide the cursor when the mouse pointer enters the button.
         ::Cursor::Hide();
      }

      void myButton_MouseLeave( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Show the cursor when the mouse pointer leaves the button.
         ::Cursor::Show();
      }