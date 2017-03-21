   void GetSetTabStopsExample2( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Tools used for drawing, painting.
      Pen^ redPen = gcnew Pen( Color::FromArgb( 255, 255, 0, 0 ) );
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::FromArgb( 255, 0, 0, 255 ) );

      // Layout and format for text.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Times New Roman",12 );
      StringFormat^ myStringFormat = gcnew StringFormat;
      Rectangle enclosingRectangle = Rectangle(20,20,500,100);
      array<Single>^tabStops = {150.0f,100.0f,100.0f};

      // Text with tabbed columns.
      String^ myString = "Name\tTab 1\tTab 2\tTab 3\nGeorge Brown\tOne\tTwo\tThree";

      // Set the tab stops, paint the text specified by myString, draw the
      // rectangle that encloses the text.
      myStringFormat->SetTabStops( 0.0f, tabStops );
      g->DrawString( myString, myFont, blueBrush, enclosingRectangle, myStringFormat );
      g->DrawRectangle( redPen, enclosingRectangle );

      // Get the tab stops.
      float firstTabOffset;
      array<Single>^tabStopsObtained = myStringFormat->GetTabStops( firstTabOffset );
      for ( int j = 0; j < tabStopsObtained->Length; j++ )
      {
         // Inspect or use the value in tabStopsObtained[j].
         Console::WriteLine( "\n  Tab stop {0} = {1}", j, tabStopsObtained[ j ] );
      }
   }