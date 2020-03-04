
//<Snippet1>
// Example of the Convert::ToInt64( String* ) and 
// Convert::ToInt64( String*, IFormatProvider* ) methods.
using namespace System;
using namespace System::Globalization;
const __wchar_t * protoFmt = L"{0,-22}{1,-20}{2}";

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}

void ConvertToInt64( String^ numericStr, IFormatProvider^ provider )
{
   Object^ defaultValue;
   Object^ providerValue;
   
   // Convert numericStr to Int64 without a format provider.
   try
   {
      defaultValue = Convert::ToInt64( numericStr );
   }
   catch ( Exception^ ex ) 
   {
      defaultValue = GetExceptionType( ex );
   }

   
   // Convert numericStr to Int64 with a format provider.
   try
   {
      providerValue = Convert::ToInt64( numericStr, provider );
   }
   catch ( Exception^ ex ) 
   {
      providerValue = GetExceptionType( ex );
   }

   Console::WriteLine( gcnew String( protoFmt ), numericStr, defaultValue, providerValue );
}

int main()
{
   
   // Create a NumberFormatInfo object and set several of its
   // properties that apply to numbers.
   NumberFormatInfo^ provider = gcnew NumberFormatInfo;
   
   // These properties affect the conversion.
   provider->NegativeSign = "neg ";
   provider->PositiveSign = "pos ";
   
   // These properties do not affect the conversion.
   // The input string cannot have decimal and group separators.
   provider->NumberDecimalSeparator = ".";
   provider->NumberGroupSeparator = ",";
   array<Int32>^sizes = {3};
   provider->NumberGroupSizes = sizes;
   provider->NumberNegativePattern = 0;
   Console::WriteLine( "This example of\n"
   "  Convert::ToInt64( String* ) and \n"
   "  Convert::ToInt64( String*, IFormatProvider* ) "
   "\ngenerates the following output. It converts "
   "several strings to \n__int64 values, using "
   "default formatting or a NumberFormatInfo object.\n" );
   Console::WriteLine( gcnew String( protoFmt ), "String to convert", "Default/exception", "Provider/exception" );
   Console::WriteLine( gcnew String( protoFmt ), "-----------------", "-----------------", "------------------" );
   
   // Convert strings, with and without an IFormatProvider.
   ConvertToInt64( "123456789", provider );
   ConvertToInt64( "+123456789", provider );
   ConvertToInt64( "pos 123456789", provider );
   ConvertToInt64( "-123456789", provider );
   ConvertToInt64( "neg 123456789", provider );
   ConvertToInt64( "123456789.", provider );
   ConvertToInt64( "123,456,789", provider );
   ConvertToInt64( "(123456789)", provider );
   ConvertToInt64( "9223372036854775808", provider );
   ConvertToInt64( "-9223372036854775809", provider );
}

/*
This example of
  Convert::ToInt64( String* ) and
  Convert::ToInt64( String*, IFormatProvider* )
generates the following output. It converts several strings to
__int64 values, using default formatting or a NumberFormatInfo object.

String to convert     Default/exception   Provider/exception
-----------------     -----------------   ------------------
123456789             123456789           123456789
+123456789            123456789           FormatException
pos 123456789         FormatException     123456789
-123456789            -123456789          FormatException
neg 123456789         FormatException     -123456789
123456789.            FormatException     FormatException
123,456,789           FormatException     FormatException
(123456789)           FormatException     FormatException
9223372036854775808   OverflowException   OverflowException
-9223372036854775809  OverflowException   FormatException
*/
//</Snippet1>
