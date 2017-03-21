public:
   void ConvertByteSingle( Byte byteVal )
   {
      float floatVal;
      
      // Byte to float conversion will not overflow.
      floatVal = System::Convert::ToSingle( byteVal );
      System::Console::WriteLine( "The Byte as a float is {0}.",
         floatVal );
      
      // Float to Byte conversion can overflow.
      try
      {
         byteVal = System::Convert::ToByte( floatVal );
         System::Console::WriteLine( "The float as a Byte is {0}.",
         byteVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine(
            "The float value is too large for a Byte." );
      }
   }