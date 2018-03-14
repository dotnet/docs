// Convert.ToByte.cpp : main project file.

// <Snippet1>
using namespace System;

void main()
{
   bool falseFlag = false;
   bool trueFlag = true;

   Console::WriteLine("{0} converts to {1}.", falseFlag,
                      Convert::ToByte(falseFlag));
   Console::WriteLine("{0} converts to {1}.", trueFlag, 
                      Convert::ToByte(trueFlag));
}
// The example displays the following output:
//       False converts to 0.
//       True converts to 1.
// </Snippet1>
