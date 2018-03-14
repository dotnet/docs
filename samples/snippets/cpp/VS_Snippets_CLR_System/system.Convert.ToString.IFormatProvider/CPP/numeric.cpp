
//<Snippet3>
// Example of the Convert::ToString( numeric types ) and 
// Convert::ToString( numeric types, IFormatProvider* ) methods.
using namespace System;
using namespace System::Globalization;
int main()
{
   // Create a NumberFormatInfo object and set several of its
   // properties that apply to numbers.
   NumberFormatInfo^ provider = gcnew NumberFormatInfo;
   String^ formatter = "{0,22}   {1}";

   // These properties will affect the conversion.
   provider->NegativeSign = "minus ";
   provider->NumberDecimalSeparator = " point ";

   // These properties will not be applied.
   provider->NumberDecimalDigits = 2;
   provider->NumberGroupSeparator = ".";
   array<Int32>^sizes = {3};
   provider->NumberGroupSizes = sizes;

   // Convert these values using default values and the
   // format provider created above.
   Byte ByteA = 140;
   SByte SByteA = -60;
   UInt16 UInt16A = 61680;
   short Int16A = -3855;
   UInt32 UInt32A = 4042322160;
   int Int32A = -252645135;
   UInt64 UInt64A = 8138269444283625712;
   __int64 Int64A = -1085102592571150095;
   float SingleA = -32.375F;
   double DoubleA = 61680.3855;
   Decimal DecimA = Convert::ToDecimal( "4042322160.252645135" );
   Object^ ObjDouble =  -98765.4321;
   Console::WriteLine( "This example of "
   "Convert::ToString( numeric types ) and \n"
   "Convert::ToString( numeric types, IFormatProvider* ) \n"
   "converts values of each of the CLR base numeric types "
   "to strings, \nusing default formatting and a "
   "NumberFormatInfo object." );
   Console::WriteLine( "\nNote: Of the several NumberFormatInfo "
   "properties that are changed, \nonly the negative sign "
   "and decimal separator affect the conversions.\n" );
   Console::WriteLine( formatter, "Default", "Format Provider" );
   Console::WriteLine( formatter, "-------", "---------------" );

   // Convert the values with and without a format provider.
   Console::WriteLine( formatter, Convert::ToString( ByteA ), Convert::ToString( ByteA, provider ) );
   Console::WriteLine( formatter, Convert::ToString( SByteA ), Convert::ToString( SByteA, provider ) );
   Console::WriteLine( formatter, Convert::ToString( UInt16A ), Convert::ToString( UInt16A, provider ) );
   Console::WriteLine( formatter, Convert::ToString( Int16A ), Convert::ToString( Int16A, provider ) );
   Console::WriteLine( formatter, Convert::ToString( UInt32A ), Convert::ToString( UInt32A, provider ) );
   Console::WriteLine( formatter, Convert::ToString( Int32A ), Convert::ToString( Int32A, provider ) );
   Console::WriteLine( formatter, Convert::ToString( UInt64A ), Convert::ToString( UInt64A, provider ) );
   Console::WriteLine( formatter, Convert::ToString( Int64A ), Convert::ToString( Int64A, provider ) );
   Console::WriteLine( formatter, Convert::ToString( SingleA ), Convert::ToString( SingleA, provider ) );
   Console::WriteLine( formatter, Convert::ToString( DoubleA ), Convert::ToString( DoubleA, provider ) );
   Console::WriteLine( formatter, Convert::ToString( DecimA ), Convert::ToString( DecimA, provider ) );
   Console::WriteLine( formatter, Convert::ToString( ObjDouble ), Convert::ToString( ObjDouble, provider ) );
}

/*
This example of Convert::ToString( numeric types ) and
Convert::ToString( numeric types, IFormatProvider* )
converts values of each of the CLR base numeric types to strings,
using default formatting and a NumberFormatInfo object.

Note: Of the several NumberFormatInfo properties that are changed,
only the negative sign and decimal separator affect the conversions.

               Default   Format Provider
               -------   ---------------
                   140   140
                   -60   minus 60
                 61680   61680
                 -3855   minus 3855
            4042322160   4042322160
            -252645135   minus 252645135
   8138269444283625712   8138269444283625712
  -1085102592571150095   minus 1085102592571150095
               -32.375   minus 32 point 375
            61680.3855   61680 point 3855
  4042322160.252645135   4042322160 point 252645135
           -98765.4321   minus 98765 point 4321
*/
//</Snippet3>
