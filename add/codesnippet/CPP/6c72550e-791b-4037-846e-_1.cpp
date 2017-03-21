private:
   void AddStringExample( PaintEventArgs^ e )
   {
      // Create a GraphicsPath object.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up all the string parameters.
      String^ stringText = "Sample Text";
      FontFamily^ family = gcnew FontFamily( "Arial" );
      int fontStyle = (int)FontStyle::Italic;
      int emSize = 26;
      Point origin = Point(20,20);
      StringFormat^ format = StringFormat::GenericDefault;

      // Add the string to the path.
      myPath->AddString( stringText, family, fontStyle, (float)emSize, origin, format );

      //Draw the path to the screen.
      e->Graphics->FillPath( Brushes::Black, myPath );
   }