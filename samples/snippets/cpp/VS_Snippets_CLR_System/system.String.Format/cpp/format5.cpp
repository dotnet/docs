// Format5.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet5>
using namespace System;

void main()
{
   DateTime date1 = DateTime(2009, 7, 1);
   TimeSpan hiTime = TimeSpan(14, 17, 32);
   Decimal hiTemp = (Decimal) 62.1; 
   TimeSpan loTime = TimeSpan(3, 16, 10);
   Decimal loTemp = (Decimal)54.8; 

   String^ result1 = String::Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)", 
                                    date1, hiTime, hiTemp, loTime, loTemp);
   Console::WriteLine(result1);
   Console::WriteLine();
           
   String^ result2 = String::Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)", 
                                    gcnew array<Object^> { date1, hiTime, hiTemp, loTime, loTemp });
   Console::WriteLine(result2);
}
// The example displays the following output:
//       Temperature on 7/1/2009:
//          14:17:32: 62.1 degrees (hi)
//          03:16:10: 54.8 degrees (lo)
//       Temperature on 7/1/2009:
//          14:17:32: 62.1 degrees (hi)
//          03:16:10: 54.8 degrees (lo)
// </Snippet5>
