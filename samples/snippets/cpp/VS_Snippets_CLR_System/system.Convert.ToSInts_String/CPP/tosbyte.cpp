
//<Snippet4>
// Example of the Convert::ToSByte( String* ) and 
// Convert::ToSByte( String*, IFormatProvider* ) methods.
using namespace System;
using namespace System::Globalization;
const __wchar_t * protoFmt = L"{0,-20}{1,-20}{2}";

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}

void ConvertToSByte( String^ numericStr, IFormatProvider^ provider )
{
   Object^ defaultValue;
   Object^ providerValue;
   
   // Convert numericStr to SByte without a format provider.
   try
   {
      defaultValue = Convert::ToSByte( numericStr );
   }
   catch ( Exception^ ex ) 
   {
      defaultValue = GetExceptionType( ex );
   }

   
   // Convert numericStr to SByte with a format provider.
   try
   {
      providerValue = Convert::ToSByte( numericStr, provider );
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
   provider->NumberNegativePattern = 0;
   Console::WriteLine( "This example of\n"
   "  Convert::ToSByte( String* ) and \n"
   "  Convert::ToSByte( String*, IFormatProvider* ) "
   "\ngenerates the following output. It converts "
   "several strings to \nSByte values, using "
   "default formatting or a NumberFormatInfo object.\n" );
   Console::WriteLine( gcnew String( protoFmt ), "String to convert", "Default/exception", "Provider/exception" );
   Console::WriteLine( gcnew String( protoFmt ), "-----------------", "-----------------", "------------------" );
   
   // Convert strings, with and without an IFormatProvider.
   ConvertToSByte( "123", provider );
   ConvertToSByte( "+123", provider );
   ConvertToSByte( "pos 123", provider );
   ConvertToSByte( "-123", provider );
   ConvertToSByte( "neg 123", provider );
   ConvertToSByte( "123.", provider );
   ConvertToSByte( "(123)", provider );
   ConvertToSByte( "128", provider );
   ConvertToSByte( "-129", provider );
}

/*
This example of
  Convert::ToSByte( String* ) and
  Convert::ToSByte( String*, IFormatProvider* )
generates the following output. It converts several strings to
SByte values, using default formatting or a NumberFormatInfo object.

String to convert   Default/exception   Provider/exception
-----------------   -----------------   ------------------
123                 123                 123
+123                123                 FormatException
pos 123             FormatException     123
-123                -123                FormatException
neg 123             FormatException     -123
123.                FormatException     FormatException
(123)               FormatException     FormatException
128                 OverflowException   OverflowException
-129                OverflowException   FormatException
*/
//</Snippet4>
