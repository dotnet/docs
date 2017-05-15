// MinValue.cpp : main project file.

using namespace System;

int main(array<System::String ^> ^args)
{
      // <Snippet1>
      array<Int64>^ numbersToConvert = {162345, 32183, -54000};
      Int16 newNumber;
      for each (Int64 number in numbersToConvert)
      {
         if (number >= Int16::MinValue && number <= Int16::MaxValue)
         {
            newNumber = Convert::ToInt16(number);
            Console::WriteLine("Successfully converted {0} to an Int16.", 
                               newNumber);
         }
         else
         {
            Console::WriteLine("Unable to convert {0} to an Int16.", number);
         }
      }
      // The example displays the following output:
      //       Unable to convert 162345 to an Int16.
      //       Successfully converted 32183 to an Int16.
      //       Unable to convert -54000 to an Int16.   
      // </Snippet1>
      Console::ReadLine();
      return 0;
}
