private:
   void DrawIconUnstretchedRectangle( PaintEventArgs^ e )
   {

      // Create icon.
      System::Drawing::Icon^ newIcon = gcnew System::Drawing::Icon( "SampIcon.ico" );

      // Create rectangle for icon.
      Rectangle rect = Rectangle(100,100,200,200);

      // Draw icon to screen.
      e->Graphics->DrawIconUnstretched( newIcon, rect );
   }