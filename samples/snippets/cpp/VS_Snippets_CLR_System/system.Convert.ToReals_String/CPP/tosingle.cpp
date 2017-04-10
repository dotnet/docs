
//<Snippet3>
// Example of the Convert::ToSingle( String ) and 
// Convert::ToSingle( String, IFormatProvider ) methods.
using namespace System;
using namespace System::Globalization;
const __wchar_t * formatter = L"{0,-22}{1,-20}{2}";

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}

void ConvertToSingle( String^ numericStr, IFormatProvider^ provider )
{
   Object^ defaultValue;
   Object^ providerValue;
   
   // Convert numericStr to float without a format provider.
   try
   {
      defaultValue = Convert::ToSingle( numericStr );
   }
   catch ( Exception^ ex ) 
   {
      defaultValue = GetExceptionType( ex );
   }

   
   // Convert numericStr to float with a format provider.
   try
   {
      providerValue = Convert::ToSingle( numericStr, provider );
   }
   catch ( Exception^ ex ) 
   {
      providerValue = GetExceptionType( ex );
   }

   Console::WriteLine( gcnew String( formatter ), numericStr, defaultValue, providerValue );
}

int main()
{
   
   // Create a NumberFormatInfo object and set several of its
   // properties that apply to numbers.
   NumberFormatInfo^ provider = gcnew NumberFormatInfo;
   provider->NumberDecimalSeparator = ",";
   provider->NumberGroupSeparator = ".";
   array<Int32>^sizes = {3};
   provider->NumberGroupSizes = sizes;
   Console::WriteLine( "This example of\n  Convert::ToSingle( String* ) and \n"
   "  Convert::ToSingle( String*, IFormatProvider* ) \n"
   "generates the following output when run in the "
   "[{0}] culture.", CultureInfo::CurrentCulture->Name );
   Console::WriteLine( "\nSeveral "
   "strings are converted to float values, using \n"
   "default formatting and a NumberFormatInfo object.\n" );
   Console::WriteLine( gcnew String( formatter ), "String to convert", "Default/exception", "Provider/exception" );
   Console::WriteLine( gcnew String( formatter ), "-----------------", "-----------------", "------------------" );
   
   // Convert strings, with and without an IFormatProvider.
   ConvertToSingle( "1234567", provider );
   ConvertToSingle( "1234.567", provider );
   ConvertToSingle( "1234,567", provider );
   ConvertToSingle( "12,345.67", provider );
   ConvertToSingle( "12.345,67", provider );
   ConvertToSingle( "1,234,567.89", provider );
   ConvertToSingle( "1.234.567,89", provider );
}

/*
This example of
  Convert::ToSingle( String* ) and
  Convert::ToSingle( String*, IFormatProvider* )
generates the following output when run in the [en-US] culture.

Several strings are converted to float values, using
default formatting and a NumberFormatInfo object.

String to convert     Default/exception   Provider/exception
-----------------     -----------------   ------------------
1234567               1234567             1234567
1234.567              1234.567            1234567
1234,567              1234567             1234.567
12,345.67             12345.67            FormatException
12.345,67             FormatException     12345.67
1,234,567.89          1234568             FormatException
1.234.567,89          FormatException     1234568
*/
//</Snippet3>
