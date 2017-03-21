public:
   void ConvertStringChar( String^ stringVal )
   {
      Char charVal = 'a';
      
      // A String must be one character long to convert to char.
      try
      {
         charVal = System::Convert::ToChar( stringVal );
         System::Console::WriteLine( " {0} as a char is {1}",
            stringVal, charVal );
      }
      catch ( System::FormatException^ ) 
      {
         System::Console::WriteLine(
            "The String is longer than one character." );
      }
      catch ( System::ArgumentNullException^ ) 
      {
         System::Console::WriteLine( "The String is 0." );
      }
      
      // A char to String conversion will always succeed.
      stringVal = System::Convert::ToString( charVal );
      System::Console::WriteLine( "The character as a String is {0}",
         stringVal );
   }