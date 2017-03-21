public:
   void ConvertCharDecimal( Char charVal )
   {
      Decimal decimalVal = 0;
      
      // Char to decimal conversion is not supported and will always
      // throw an InvalidCastException.
      try
      {
         decimalVal = System::Convert::ToDecimal( charVal );
      }
      catch ( System::InvalidCastException^ ) 
      {
         System::Console::WriteLine(
            "Char-to-Decimal conversion is not supported by the .NET Framework." );
      }
      
      //Decimal to char conversion is also not supported.
      try
      {
         charVal = System::Convert::ToChar( decimalVal );
      }
      catch ( System::InvalidCastException^ ) 
      {
         System::Console::WriteLine(
            "Decimal-to-Char conversion is not supported by the .NET Framework." );
      }
   }