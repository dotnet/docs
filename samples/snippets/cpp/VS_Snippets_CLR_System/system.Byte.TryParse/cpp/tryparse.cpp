// Byte.TryParse.cpp : main project file.
// Byte.TryParse(String, Byte)

// <Snippet1>
using namespace System;

void main()
{
   array<String^>^ byteStrings = gcnew array<String^> { nullptr, String::Empty, 
                                                        "1024", "100.1", "100", 
                                                        "+100", "-100", "000000000000000100", 
                                                        "00,100", "   20   ", "FF", "0x1F" };
   Byte byteValue;
   for each (String^ byteString in byteStrings) {
      bool result = Byte::TryParse(byteString, byteValue);
      if (result)
         Console::WriteLine("Converted '{0}' to {1}", 
                            byteString, byteValue);
      else
         Console::WriteLine("Attempted conversion of '{0}' failed.", 
                            byteString);
   }
}
// The example displays the following output:
//       Attempted conversion of '' failed.
//       Attempted conversion of '' failed.`
//       Attempted conversion of '1024' failed.
//       Attempted conversion of '100.1' failed.
//       Converted '100' to 100
//       Converted '+100' to 100
//       Attempted conversion of '-100' failed.
//       Converted '000000000000000100' to 100
//       Attempted conversion of '00,100' failed.
//       Converted '   20   ' to 20
//       Attempted conversion of 'FF' failed.
//       Attempted conversion of '0x1F' failed.}
// </Snippet1>
