public:
   void ConvertStringDecimal( String^ stringVal )
   {
      Decimal decimalVal = 0;

      try
      {
         decimalVal = System::Convert::ToDecimal( stringVal );
         System::Console::WriteLine( "The String as a decimal is {0}.",
         decimalVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine(
            "The conversion from String to decimal overflowed." );
      }
      catch ( System::FormatException^ ) 
      {
         System::Console::WriteLine(
            "The String is not formatted as a decimal." );
      }
      catch ( System::ArgumentNullException^ ) 
      {
         System::Console::WriteLine( "The String is 0." );
      }
      
      // Decimal to String conversion will not overflow.
      stringVal = System::Convert::ToString( decimalVal );
      System::Console::WriteLine(
         "The decimal as a String is {0}.", stringVal );
   }