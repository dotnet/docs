   // The DrawItem event handler.
private:
   void menuItem1_DrawItem( Object^ /*sender*/, System::Windows::Forms::DrawItemEventArgs^ e )
   {
      String^ myCaption = "Owner Draw Item1";

      // Create a Brush and a Font with which to draw the item.
      Brush^ myBrush = System::Drawing::Brushes::AliceBlue;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( FontFamily::GenericSerif,14,FontStyle::Underline,GraphicsUnit::Pixel );
      SizeF mySizeF = e->Graphics->MeasureString( myCaption, myFont );

      // Draw the item, and then draw a Rectangle around it.
      e->Graphics->DrawString( myCaption, myFont, myBrush, (float)e->Bounds.X, (float)e->Bounds.Y );
      e->Graphics->DrawRectangle( Pens::Black, Rectangle(e->Bounds.X,e->Bounds.Y,Convert::ToInt32( mySizeF.Width ),Convert::ToInt32( mySizeF.Height )) );
   }