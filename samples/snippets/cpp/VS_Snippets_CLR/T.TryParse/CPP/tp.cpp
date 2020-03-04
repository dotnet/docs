//<snippet1>
// This example demonstrates overloads of the TryParse method for
// several base types, and the TryParseExact method for DateTime.
// In most cases, this example uses the most complex overload; that is, the overload
// with the most parameters for a particular type. If a complex overload specifies
// null (Nothing in Visual Basic) for the IFormatProvider parameter, formatting
// information is obtained from the culture associated with the current thread.
// If a complex overload specifies the style parameter, the parameter value is
// the default value used by the equivalent simple overload.
using namespace System;
using namespace System::Globalization;

static void Show( bool parseResult, String^ typeName, String^ parseValue )
{
   String^ msgSuccess = L"Parse for {0} = {1}";
   String^ msgFailure = L"** Parse for {0} failed. Invalid input.";
   
   //
   if ( parseResult == true )
      Console::WriteLine( msgSuccess, typeName, parseValue );
   else
      Console::WriteLine( msgFailure, typeName );
}

void main()
{
   bool result;
   CultureInfo^ ci;
   String^ nl = Environment::NewLine;
   String^ msg1 = L"This example demonstrates overloads of the TryParse method for{0}"
   L"several base types, as well as the TryParseExact method for DateTime.{0}";
   String^ msg2 = L"Non-numeric types:{0}";
   String^ msg3 = L"{0}Numeric types:{0}";
   String^ msg4 = L"{0}The following types are not CLS-compliant:{0}";
   
   // Non-numeric types.
   Boolean booleanVal;
   Char charVal;
   DateTime datetimeVal;
   
   // Numeric types.
   Byte byteVal;
   Int16 int16Val;
   Int32 int32Val;
   Int64 int64Val;
   Decimal decimalVal;
   Single singleVal;
   Double doubleVal;
   
   // The following types are not CLS-compliant.
   SByte sbyteVal;
   UInt16 uint16Val;
   UInt32 uint32Val;
   UInt64 uint64Val;
   
   //
   Console::WriteLine( msg1, nl );
   
   // Non-numeric types:
   Console::WriteLine( msg2, nl );
   
   // DateTime
   // TryParse:
   // Assume current culture is en-US, and dates of the form: MMDDYYYY.
   result = DateTime::TryParse( L"7/4/2004 12:34:56",  datetimeVal );
   Show( result, L"DateTime #1", datetimeVal.ToString() );
   
   // Use fr-FR culture, and dates of the form: DDMMYYYY.
   ci = gcnew CultureInfo( L"fr-FR" );
   result = DateTime::TryParse( L"4/7/2004 12:34:56", ci, DateTimeStyles::None,  datetimeVal );
   Show( result, L"DateTime #2", datetimeVal.ToString() );
   
   // TryParseExact:
   // Use fr-FR culture. The format, "G", is short date and long time.
   result = DateTime::TryParseExact( L"04/07/2004 12:34:56", L"G", ci, DateTimeStyles::None,  datetimeVal );
   Show( result, L"DateTime #3", datetimeVal.ToString() );
   
   // Assume en-US culture.
   array<String^>^dateFormats = {L"f",L"F",L"g",L"G"};
   result = DateTime::TryParseExact( L"7/4/2004 12:34:56 PM", dateFormats, nullptr, DateTimeStyles::None,  datetimeVal );
   Show( result, L"DateTime #4", datetimeVal.ToString() );
   Console::WriteLine();
   
   // Boolean
   result = Boolean::TryParse( L"true",  booleanVal );
   Show( result, L"Boolean", booleanVal.ToString() );
   
   // Char
   result = Char::TryParse( L"A",  charVal );
   Show( result, L"Char", charVal.ToString() );
   
   // Numeric types:
   Console::WriteLine( msg3, nl );
   
   // Byte
   result = Byte::TryParse( L"1", NumberStyles::Integer, nullptr,  byteVal );
   Show( result, L"Byte", byteVal.ToString() );
   
   // Int16
   result = Int16::TryParse( L"-2", NumberStyles::Integer, nullptr,  int16Val );
   Show( result, L"Int16", int16Val.ToString() );
   
   // Int32
   result = Int32::TryParse( L"3", NumberStyles::Integer, nullptr,  int32Val );
   Show( result, L"Int32", int32Val.ToString() );
   
   // Int64
   result = Int64::TryParse( L"4", NumberStyles::Integer, nullptr,  int64Val );
   Show( result, L"Int64", int64Val.ToString() );
   
   // Decimal
   result = Decimal::TryParse( L"-5.5", NumberStyles::Number, nullptr,  decimalVal );
   Show( result, L"Decimal", decimalVal.ToString() );
   
   // Single
   result = Single::TryParse( L"6.6", static_cast<NumberStyles>((NumberStyles::Float | NumberStyles::AllowThousands)), nullptr,  singleVal );
   Show( result, L"Single", singleVal.ToString() );
   
   // Double
   result = Double::TryParse( L"-7", static_cast<NumberStyles>(NumberStyles::Float | NumberStyles::AllowThousands), nullptr,  doubleVal );
   Show( result, L"Double", doubleVal.ToString() );
   
   // Use the simple Double.TryParse overload, but specify an invalid value.
   result = Double::TryParse( L"abc",  doubleVal );
   Show( result, L"Double #2", doubleVal.ToString() );
   
   //
   Console::WriteLine( msg4, nl );
   
   // SByte
   result = SByte::TryParse( L"-8", NumberStyles::Integer, nullptr,  sbyteVal );
   Show( result, L"SByte", sbyteVal.ToString() );
   
   // UInt16
   result = UInt16::TryParse( L"9", NumberStyles::Integer, nullptr,  uint16Val );
   Show( result, L"UInt16", uint16Val.ToString() );
   
   // UInt32
   result = UInt32::TryParse( L"10", NumberStyles::Integer, nullptr,  uint32Val );
   Show( result, L"UInt32", uint32Val.ToString() );
   
   // UInt64
   result = UInt64::TryParse( L"11", NumberStyles::Integer, nullptr,  uint64Val );
   Show( result, L"UInt64", uint64Val.ToString() );
}

/*
This example produces the following results:

This example demonstrates overloads of the TryParse method for
several base types, as well as the TryParseExact method for DateTime.

Non-numeric types:

Parse for DateTime #1 = 7/4/2004 12:34:56 PM
Parse for DateTime #2 = 7/4/2004 12:34:56 PM
Parse for DateTime #3 = 7/4/2004 12:34:56 PM
Parse for DateTime #4 = 7/4/2004 12:34:56 PM

Parse for Boolean = True
Parse for Char = A

Numeric types:

Parse for Byte = 1
Parse for Int16 = -2
Parse for Int32 = 3
Parse for Int64 = 4
Parse for Decimal = -5.5
Parse for Single = 6.6
Parse for Double = -7
** Parse for Double #2 failed. Invalid input.

The following types are not CLS-compliant:

Parse for SByte = -8
Parse for UInt16 = 9
Parse for UInt32 = 10
Parse for UInt64 = 11
*/
//</snippet1>
