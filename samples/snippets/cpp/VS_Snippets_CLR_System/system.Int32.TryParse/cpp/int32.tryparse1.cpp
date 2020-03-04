// ConsoleApplication1.cpp : Defines the entry point for the console application.
//


// <Snippet1>
using namespace System;


   void TryToParse(String^ value)
   {
      Int32 number;
      bool result = Int32::TryParse(value, number);
      if (result) {
         Console::WriteLine("Converted '{0}' to {1}.", value, number);
      }
      else {
         if (value == nullptr) value = "";
         Console::WriteLine("Attempted conversion of '{0}' failed.", value);
      }
   }


void main()
{
      TryToParse(nullptr);
      TryToParse("160519");
      TryToParse("9432.0");
      TryToParse("16,667");
      TryToParse("   -322   ");
      TryToParse("+4302");
      TryToParse("(100);");
      TryToParse("01FA");
}
// The example displays the following output:
//      Attempted conversion of '' failed.
//      Converted '160519' to 160519.
//      Attempted conversion of '9432.0' failed.
//      Attempted conversion of '16,667' failed.
//      Converted '   -322   ' to -322.
//      Converted '+4302' to 4302.
//      Attempted conversion of '(100);' failed.
//      Attempted conversion of '01FA' failed.
// </Snippet1>