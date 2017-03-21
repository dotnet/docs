private:
   [UIPermission(SecurityAction::Demand, Window=UIPermissionWindow::AllWindows)]
   void DrawFirstRectangle()
   {
      Rectangle rectangle1 = Rectangle(70,70,100,150);
      ControlPaint::DrawReversibleFrame( rectangle1, SystemColors::Highlight, FrameStyle::Thick );
   }

   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Rectangle rectangle1 = Rectangle(70,70,100,150);

      // Get the bounds of the screen.
      Rectangle screenRectangle = Screen::PrimaryScreen->Bounds;

      // Check to see if the rectangle is within the bounds of the screen.
      if ( screenRectangle.Contains( rectangle1 ) )
      {
         ControlPaint::DrawReversibleFrame( rectangle1, SystemColors::Highlight, FrameStyle::Thick );

         // Call the Offset method to move the rectangle.
         rectangle1.Offset( 20, 20 );

         // Draw the new, offset rectangle.
         ControlPaint::DrawReversibleFrame( rectangle1, SystemColors::Highlight, FrameStyle::Thick );
      }
   }