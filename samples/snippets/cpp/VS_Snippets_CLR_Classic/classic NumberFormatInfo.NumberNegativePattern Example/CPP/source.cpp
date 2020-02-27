
// <Snippet1>
using namespace System;
using namespace System::Globalization;

int main()
{
   // Create a new NumberFormatinfo.
   NumberFormatInfo^ nfi = gcnew NumberFormatInfo;
   
   // Takes a negative value.
   Int64 value = -1234;
   
   // Displays the value with default formatting.
   Console::WriteLine("{0,-20} {1,-10}", "Default:", 
                          value.ToString("N", nfi));
   
   // Displays the value with other patterns.
   for (int i = 0; i <= 4; i++) {
      nfi->NumberNegativePattern = i;
      Console::WriteLine("{0,-20} {1,-10}", 
                              String::Format("Pattern {0}:", 
                                             nfi->NumberNegativePattern), 
                              value.ToString("N", nfi));
   }
}
// The example displays the following output:
//       Default:             -1,234.00
//       Pattern 0:           (1,234.00)
//       Pattern 1:           -1,234.00
//       Pattern 2:           - 1,234.00
//       Pattern 3:           1,234.00-
//       Pattern 4:           1,234.00 -
// </Snippet1>
