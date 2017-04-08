using namespace System;

public ref class ConvertSnippet
{
//<Snippet1>
public:
   void ConvertDoubleBool( double doubleVal )
   {
      bool boolVal;
      
      // Double to bool conversion cannot overflow.
      boolVal = System::Convert::ToBoolean( doubleVal );
      System::Console::WriteLine( " {0} as a Boolean is: {1}.",
         doubleVal, boolVal );
      
      // bool to double conversion cannot overflow.
      doubleVal = System::Convert::ToDouble( boolVal );
      System::Console::WriteLine( " {0} as a double is: {1}.",
         boolVal, doubleVal );
   }
   //</Snippet1>

   //<Snippet2>
public:
   void ConvertDoubleByte( double doubleVal )
   {
      Byte byteVal = 0;
      
      // Double to Byte conversion can overflow.
      try
      {
         byteVal = System::Convert::ToByte( doubleVal );
         System::Console::WriteLine( " {0} as a Byte is: {1}.",
         doubleVal, byteVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Overflow in double-to-Byte conversion." );
      }
      
      // Byte to double conversion cannot overflow.
      doubleVal = System::Convert::ToDouble( byteVal );
      System::Console::WriteLine( " {0} as a double is: {1}.",
         byteVal, doubleVal );
   }
   //</Snippet2>

   //<Snippet3>
public:
   void ConvertDoubleInt( double doubleVal )
   {
      int intVal = 0;
      
      // Double to int conversion can overflow.
      try
      {
         intVal = System::Convert::ToInt32( doubleVal );
         System::Console::WriteLine( " {0} as an int is: {1}",
         doubleVal, intVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Overflow in double-to-int conversion." );
      }
      
      // Int to double conversion cannot overflow.
      doubleVal = System::Convert::ToDouble( intVal );
      System::Console::WriteLine( " {0} as a double is: {1}",
         intVal, doubleVal );
   }
   //</Snippet3>

   //<Snippet5>
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
   //</Snippet5>

   //<Snippet6>
public:
   void CovertDoubleFloat( double doubleVal )
   {
      float floatVal = 0;
      
      // A conversion from Double to Single cannot overflow.
      floatVal = System::Convert::ToSingle( doubleVal );
      System::Console::WriteLine( " {0} as a float is {1}",
                                  doubleVal, floatVal );

      // A conversion from Single to Double cannot overflow.
      doubleVal = System::Convert::ToDouble( floatVal );
      System::Console::WriteLine( " {0} as a double is: {1}",
                                  floatVal, doubleVal );
   }
   //</Snippet6>

   //<Snippet7>
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
   //</Snippet7>

   //<Snippet8>
public:
   void ConvertLongChar( Int64 longVal )
   {
      Char charVal = 'a';

      try
      {
         charVal = System::Convert::ToChar( longVal );
         System::Console::WriteLine( " {0} as a char is {1}",
         longVal, charVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Overflow in long-to-char conversion." );
      }

      
      // A conversion from Char to long cannot overflow.
      longVal = System::Convert::ToInt64( charVal );
      System::Console::WriteLine( " {0} as an Int64 is {1}",
         charVal, longVal );
   }


   //</Snippet8>
   //<Snippet9>
   void ConvertLongByte( Int64 longVal )
   {
      Byte byteVal = 0;
      
      // A conversion from Long to Byte can overflow.
      try
      {
         byteVal = System::Convert::ToByte( longVal );
         System::Console::WriteLine( " {0} as a Byte is {1}",
         longVal, byteVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Overflow in long-to-Byte conversion." );
      }
      
      // A conversion from Byte to long cannot overflow.
      longVal = System::Convert::ToInt64( byteVal );
      System::Console::WriteLine( " {0} as an Int64 is {1}",
         byteVal, longVal );
   }
   //</Snippet9>

   //<Snippet10>
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
   //</Snippet10>

   //<Snippet11>
public:
   void ConvertLongFloat( Int64 longVal )
   {
      float floatVal;
      
      // A conversion from Long to float cannot overflow.
      floatVal = System::Convert::ToSingle( longVal );
      System::Console::WriteLine( " {0} as a float is {1}",
         longVal, floatVal );
      
      // A conversion from float to long can overflow.
      try
      {
         longVal = System::Convert::ToInt64( floatVal );
         System::Console::WriteLine( " {0} as a long is {1}",
         floatVal, longVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine( "Overflow in float-to-long conversion." );
      }
   }
   //</Snippet11>

   //<Snippet12>
public:
   void ConvertStringBoolean( String^ stringVal )
   {
      bool boolVal = false;

      try
      {
         boolVal = System::Convert::ToBoolean( stringVal );
         if ( boolVal )
         {
            System::Console::WriteLine(
               "String was equal to System::Boolean::TrueString." );
         }
         else
         {
            System::Console::WriteLine(
               "String was equal to System::Boolean::FalseString." );
         }
      }
      catch ( System::FormatException^ ) 
      {
         System::Console::WriteLine( "The String must equal System::Boolean::TrueString " +
            "or System::Boolean::FalseString." );
      }
      
      // A conversion from bool to String will always succeed.
      stringVal = System::Convert::ToString( boolVal );
      System::Console::WriteLine( " {0} as a String is {1}",
         boolVal, stringVal );
   }
   //</Snippet12>

   //<Snippet13>
public:
   void ConvertStringByte( String^ stringVal )
   {
      Byte byteVal = 0;

      try
      {
         byteVal = System::Convert::ToByte( stringVal );
         System::Console::WriteLine( " {0} as a Byte is: {1}",
            stringVal, byteVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine(
            "Conversion from String to Byte overflowed." );
      }
      catch ( System::FormatException^ ) 
      {
         System::Console::WriteLine(
            "The String is not formatted as a Byte." );
      }
      catch ( System::ArgumentNullException^ ) 
      {
         System::Console::WriteLine( "The String is 0." );
      }
      
      //The conversion from Byte to String is always valid.
      stringVal = System::Convert::ToString( byteVal );
      System::Console::WriteLine( " {0} as a String is {1}",
         byteVal, stringVal );
   }
   //</Snippet13>

   //<Snippet14>
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
   //</Snippet14>

   //<Snippet15>
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
   //</Snippet15>

   //<Snippet16>
public:
   void ConvertStringFloat( String^ stringVal )
   {
      float floatVal = 0;

      try
      {
         floatVal = System::Convert::ToSingle( stringVal );
         System::Console::WriteLine(
            "The String as a float is {0}.", floatVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine(
            "The conversion from String-to-float overflowed." );
      }
      catch ( System::FormatException^ ) 
      {
         System::Console::WriteLine(
            "The String is not formatted as a float." );
      }
      catch ( System::ArgumentNullException^ ) 
      {
         System::Console::WriteLine(
            "The String is 0." );
      }
      
      // Float to String conversion will not overflow.
      stringVal = System::Convert::ToString( floatVal );
      System::Console::WriteLine(
         "The float as a String is {0}.", stringVal );
   }
   //</Snippet16>

   //<Snippet17>
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
   //</Snippet17>

   //<Snippet18>
public:
   void ConvertByteDecimal( Byte byteVal )
   {
      Decimal decimalVal;
      
      // Byte to decimal conversion will not overflow.
      decimalVal = System::Convert::ToDecimal( byteVal );
      System::Console::WriteLine( "The Byte as a decimal is {0}.",
         decimalVal );
      
      // Decimal to Byte conversion can overflow.
      try
      {
         byteVal = System::Convert::ToByte( decimalVal );
         System::Console::WriteLine( "The Decimal as a Byte is {0}.",
         byteVal );
      }
      catch ( System::OverflowException^ ) 
      {
         System::Console::WriteLine(
            "The decimal value is too large for a Byte." );
      }
   }
   //</Snippet18>

   //<Snippet19>
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
   //</Snippet19>

   //<Snippet20>
public:
   void ConvertBoolean()
   {
      const int year = 1979;
      const int month = 7;
      const int day = 28;
      const int hour = 13;
      const int minute = 26;
      const int second = 15;
      const int millisecond = 53;
      DateTime dateTime( year, month, day, hour,
         minute, second, millisecond );
      bool boolVal;
      
      // System::InvalidCastException is always thrown.
      try
      {
         boolVal = System::Convert::ToBoolean( dateTime );
      }
      catch ( System::InvalidCastException^ ) 
      {
         System::Console::WriteLine( "Conversion from DateTime to Boolean "+
            "is not supported by the .NET Framework." );
      }
   }
   //</Snippet20>

   void ConvertDoubles( double doubleVal )
   {
      ConvertDoubleBool( doubleVal );
      ConvertDoubleByte( doubleVal );
      ConvertDoubleInt( doubleVal );
      ConvertDoubleDecimal( doubleVal );
      CovertDoubleFloat( doubleVal );
      ConvertDoubleString( doubleVal );
   }

   void ConvertLongs( Int64 longVal )
   {
      ConvertLongChar( longVal );
      ConvertLongByte( longVal );
      ConvertLongDecimal( longVal );
      ConvertLongFloat( longVal );
   }

   void ConvertStrings( String^ stringVal )
   {
      ConvertStringBoolean( stringVal );
      ConvertStringByte( stringVal );
      ConvertStringChar( stringVal );
      ConvertStringDecimal( stringVal );
      ConvertStringFloat( stringVal );
   }

   void ConvertChars( Char charVal )
   {
      ConvertCharDecimal( charVal );
   }

   void ConvertBytes( Byte byteVal )
   {
      ConvertByteDecimal( byteVal );
      ConvertByteSingle( byteVal );
   }
};

int main()
{
   ConvertSnippet^ snippet = gcnew ConvertSnippet;

   double doubleVal;
   System::Console::WriteLine( "Enter the double value: " );
   doubleVal = System::Convert::ToDouble( System::Console::ReadLine() );
   snippet->ConvertDoubles( doubleVal );

   Int64 longVal;
   System::Console::WriteLine( "Enter the Int64 value: " );
   longVal = System::Convert::ToInt64( System::Console::ReadLine() );
   snippet->ConvertLongs( longVal );

   String^ stringVal;
   System::Console::WriteLine( "Enter the String value: " );
   stringVal = System::Console::ReadLine();
   snippet->ConvertStrings( stringVal );

   Char charVal;
   System::Console::WriteLine( "Enter the char value: " );
   charVal = System::Convert::ToChar( System::Console::ReadLine() );
   snippet->ConvertChars( charVal );

   Byte byteVal;
   System::Console::WriteLine( "Enter the Byte value: " );
   byteVal = System::Convert::ToByte( System::Console::ReadLine() );
   snippet->ConvertBytes( byteVal );

   snippet->ConvertBoolean();
}
