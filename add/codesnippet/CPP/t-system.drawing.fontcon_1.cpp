   void ShowFontStringConversion( PaintEventArgs^ e )
   {
      // Create the FontConverter.
      System::ComponentModel::TypeConverter^ converter =
            System::ComponentModel::TypeDescriptor::GetConverter( System::Drawing::Font::typeid );
      System::Drawing::Font^ font1 = dynamic_cast<System::Drawing::Font^>(converter->ConvertFromString( "Arial, 12pt" ));
      String^ fontName1 = converter->ConvertToInvariantString( font1 );
      String^ fontName2 = converter->ConvertToString( font1 );
      e->Graphics->DrawString( fontName1, font1, Brushes::Red, 10, 10 );
      e->Graphics->DrawString( fontName2, font1, Brushes::Blue, 10, 30 );
   }