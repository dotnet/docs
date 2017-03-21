public:
   void Complement_Path_Example( PaintEventArgs^ e )
   {
      // Create the first rectangle and draw it to the screen in black.
      Rectangle regionRect = Rectangle(20,20,100,100);
      e->Graphics->DrawRectangle( Pens::Black, regionRect );

      // Create the second rectangle and draw it to the screen in red.
      Rectangle complementRect = Rectangle(90,30,100,100);
      e->Graphics->DrawRectangle( Pens::Red, complementRect );

      // Create a graphics path and add the second rectangle to it.
      GraphicsPath^ complementPath = gcnew GraphicsPath;
      complementPath->AddRectangle( complementRect );

      // Create a region using the first rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( regionRect );

      // Get the complement of myRegion when combined with
      // complementPath.
      myRegion->Complement( complementPath );

      // Fill the complement area with blue.
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Blue );
      e->Graphics->FillRegion( myBrush, myRegion );
   }