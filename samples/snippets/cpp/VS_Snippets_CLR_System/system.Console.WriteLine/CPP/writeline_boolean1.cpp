// Console.WriteLine1.cpp : main project file.

// <Snippet4>
using namespace System;

void main()
{
   // Assign 10 random integers to an array.
   Random^ rnd = gcnew Random();
   array<Int32>^ numbers = gcnew array<Int32>(10); 
   for (int ctr = 0; ctr <= numbers->GetUpperBound(0); ctr++)
      numbers[ctr] = rnd->Next();

   // Determine whether the numbers are even or odd.
   for each (Int32 number in numbers) {
      bool even = (number % 2 == 0);
      Console::WriteLine("Is {0} even:", number);
      Console::WriteLine(even);
      Console::WriteLine();      
   }
}
// </Snippet4>