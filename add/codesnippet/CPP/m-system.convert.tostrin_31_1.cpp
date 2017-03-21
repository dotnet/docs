public:
   void ConvertDoubleString( double doubleVal )
   {
      String^ stringVal;
      
      // A conversion from Double to String cannot overflow.
      stringVal = System::Convert::ToString( doubleVal );
      System::Console::WriteLine( " {0} as a String is: {1}",
         doubleVal, stringVal );
      try
      {
         doubleVal = System::Convert::ToDouble( stringVal );
         System::Console::WriteLine( " {0} as a double is: {1}",
         stringVal, doubleVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Conversion from String-to-double overflowed." );
      }
      catch ( System::FormatException^ ) 
      {
         System::Console::WriteLine( "The String was not formatted as a double." );
      }
      catch ( System::ArgumentException^ ) 
      {
         System::Console::WriteLine( "The String pointed to null." );
      }
   }