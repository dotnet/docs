private:
   void DrawIconInt( PaintEventArgs^ e )
   {

      // Create icon.
      System::Drawing::Icon^ newIcon = gcnew System::Drawing::Icon( "SampIcon.ico" );

      // Create coordinates for upper-left corner of icon.
      int x = 100;
      int y = 100;

      // Draw icon to screen.
      e->Graphics->DrawIcon( newIcon, x, y );
   }