// ToInt_Str_Int32.cpp : main project file.

//#include "stdafx.h"

using namespace System;

int main(array<System::String ^> ^args)
{
   // <Snippet1>
   // Create a hexadecimal value out of range of the integer type. 
   String^ value1 = Convert::ToString((static_cast<__int64>(int::MaxValue)) + 1, 16);
   // Convert it back to a number.
   try {
      int number = Convert::ToInt32(value1, 16);
      Console::WriteLine("0x{0} converts to {1}.", value1, number);
   }
   catch (OverflowException ^e) {
      Console::WriteLine("Unable to convert '0x{0}' to an integer.", value1);
   }
   // The example displays the following output:
   //      0x80000000 converts to -2147483648.
   // </Snippet1>

   // <Snippet2>
   __int64 sourceNumber2 = (static_cast<__int64>(int::MaxValue)) + 1;
   bool isNegative = Math::Sign(sourceNumber2) == -1;
   String^ value2 = Convert::ToString(sourceNumber2, 16);
   int targetNumber;
   try {
      targetNumber = Convert::ToInt32(value2, 16);
      if (!(isNegative) & (targetNumber & 0x80000000) != 0)
         throw gcnew OverflowException();
      else
         Console::WriteLine("0x{0} converts to {1}.", value2, targetNumber);
   }
   catch (OverflowException ^e) {
      Console::WriteLine("Unable to convert '0x{0}' to an integer.", value2);
   }
   // The example displays the following output:
   //       Unable to convert '0x80000000' to an integer.
   // </Snippet2>
   //Console::Write("Press any key...");
   //Console::ReadLine();
   return 0;
}
