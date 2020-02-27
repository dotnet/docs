// Console.ReadLine.cpp : main project file.

// <Snippet1>
using namespace System;

void main()
{
   String^ line;
   Console::WriteLine("Enter one or more lines of text (press CTRL+Z to exit):");
   Console::WriteLine();
   do { 
      Console::Write("   ");
      line = Console::ReadLine();
      if (line != nullptr) 
         Console::WriteLine("      " + line);
   } while (line != nullptr);   
}
// The following displays possible output from this example:
//       Enter one or more lines of text (press CTRL+Z to exit):
//       
//          This is line #1.
//             This is line #1.
//          This is line #2
//             This is line #2
//          ^Z
//       
//       >}
// </Snippet1>
