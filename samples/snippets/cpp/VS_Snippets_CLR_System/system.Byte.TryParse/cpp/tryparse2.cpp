// Byte.TryParse2.cpp : main project file.

// <Snippet2>
using namespace System;
using namespace System::Globalization;

void CallTryParse(String^ byteString, NumberStyles styles);

void main()
{
   String^ byteString; 
   NumberStyles styles;

   byteString = "1024";
   styles = NumberStyles::Integer;
   CallTryParse(byteString, styles);

   byteString = "100.1";
   styles = NumberStyles::Integer | NumberStyles::AllowDecimalPoint;
   CallTryParse(byteString, styles);

   byteString = "100.0";
   CallTryParse(byteString, styles);

   byteString = "+100";
   styles = NumberStyles::Integer | NumberStyles::AllowLeadingSign 
            | NumberStyles::AllowTrailingSign;
   CallTryParse(byteString, styles);

   byteString = "-100";
   CallTryParse(byteString, styles);

   byteString = "000000000000000100";
   CallTryParse(byteString, styles);

   byteString = "00,100";
   styles = NumberStyles::Integer | NumberStyles::AllowThousands;
   CallTryParse(byteString, styles);

   byteString = "2E+3   ";
   styles = NumberStyles::Integer | NumberStyles::AllowExponent;
   CallTryParse(byteString, styles);

   byteString = "FF";
   styles = NumberStyles::HexNumber;
   CallTryParse(byteString, styles);

   byteString = "0x1F";
   CallTryParse(byteString, styles);
}

void CallTryParse(String^ stringToConvert, NumberStyles styles)
{  
   Byte byteValue;
   bool result = Byte::TryParse(stringToConvert, styles, 
                                 (IFormatProvider^) nullptr , byteValue);
   if (result)
      Console::WriteLine("Converted '{0}' to {1}", 
                     stringToConvert, byteValue);
   else
      Console::WriteLine("Attempted conversion of '{0}' failed.", 
                        stringToConvert);
}
// The example displays the following output:
//       Attempted conversion of '1024' failed.
//       Attempted conversion of '100.1' failed.
//       Converted '100.0' to 100
//       Converted '+100' to 100
//       Attempted conversion of '-100' failed.
//       Converted '000000000000000100' to 100
//       Converted '00,100' to 100
//       Attempted conversion of '2E+3   ' failed.
//       Converted 'FF' to 255
//       Attempted conversion of '0x1F' failed.}
// </Snippet2>
