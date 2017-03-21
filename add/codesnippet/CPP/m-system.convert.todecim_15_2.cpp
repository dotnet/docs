public:
   void ConvertDoubleDecimal( double doubleVal )
   {
      Decimal decimalVal;
      
      // Conversion from double to decimal cannot overflow.
      decimalVal = System::Convert::ToDecimal( doubleVal );
      System::Console::WriteLine( " {0} as a decimal is: {1}",
         doubleVal, decimalVal );
      
      // Decimal to double conversion can overflow.
      try
      {
         doubleVal = System::Convert::ToDouble( decimalVal );
         System::Console::WriteLine( " {0} as a double is: {1}",
         decimalVal, doubleVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Overflow in decimal-to-double conversion." );
      }
   }