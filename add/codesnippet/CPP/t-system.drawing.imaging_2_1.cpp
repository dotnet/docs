private:
   void ExtractMetaData( PaintEventArgs^ e )
   {
      try
      {
         
         // Create an Image object. 
         Image^ theImage = gcnew Bitmap( "c:\\fakePhoto.jpg" );
         
         // Get the PropertyItems property from image.
         array<PropertyItem^>^propItems = theImage->PropertyItems;
         
         // Set up the display.
         System::Drawing::Font^ font1 = gcnew System::Drawing::Font( "Arial",10 );
         SolidBrush^ blackBrush = gcnew SolidBrush( Color::Black );
         int X = 0;
         int Y = 0;
         
         // For each PropertyItem in the array, display the id, 
         // type, and length.
         int count = 0;
         System::Collections::IEnumerator^ myEnum = propItems->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            PropertyItem^ propItem = safe_cast<PropertyItem^>(myEnum->Current);
            e->Graphics->DrawString( String::Format( "Property Item {0}", count ), font1, blackBrush, (float)X, (float)Y );
            Y += font1->Height;
            e->Graphics->DrawString( String::Format( "   ID: 0x{0}", propItem->Id.ToString( "x" ) ), font1, blackBrush, (float)X, (float)Y );
            Y += font1->Height;
            e->Graphics->DrawString( String::Format( "   type: {0}", propItem->Type ), font1, blackBrush, (float)X, (float)Y );
            Y += font1->Height;
            e->Graphics->DrawString( String::Format( "   length: {0} bytes", propItem->Len ), font1, blackBrush, (float)X, (float)Y );
            Y += font1->Height;
            count += 1;
         }
         delete font1;
      }
      catch ( Exception^ ) 
      {
         MessageBox::Show( "There was an error."
         "Make sure the path to the image file is valid." );
      }

   }