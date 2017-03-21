public:
   void ConvertLongDecimal( Int64 longVal )
   {
      Decimal decimalVal;
      
      // Long to decimal conversion cannot overflow.
      decimalVal = System::Convert::ToDecimal( longVal );
      System::Console::WriteLine( " {0} as a decimal is {1}",
         longVal, decimalVal );
      
      // Decimal to long conversion can overflow.
      try
      {
         longVal = System::Convert::ToInt64( decimalVal );
         System::Console::WriteLine( " {0} as a long is {1}",
         decimalVal, longVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Overflow in decimal-to-long conversion." );
      }
   }