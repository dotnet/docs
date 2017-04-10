// Format4.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet4>
using namespace System;

void main()
{
   String^ formatString = "    {0,10} ({0,8:X8})\n" + 
                           "And {1,10} ({1,8:X8})\n" + 
                           "  = {2,10} ({2,8:X8})";
   int value1 = 16932;
   int value2 = 15421;
   String^ result = String::Format(formatString, 
                                   value1, value2, value1 & value2);
   Console::WriteLine(result);
}
// The example displays the following output:
//                16932 (00004224)
//       And      15421 (00003C3D)
//         =         36 (00000024)
// </Snippet4>
