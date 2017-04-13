// FormatOverload1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet8>
using namespace System;

void main()
{
   DateTime^ dat = gcnew DateTime(2012, 1, 17, 9, 30, 0); 
   String^ city = "Chicago";
   int temp = -16;
   String^ output = String::Format("At {0} in {1}, the temperature was {2} degrees.",
                                   dat, city, temp);
   Console::WriteLine(output);
}
// The example displays the following output: 
//    At 1/17/2012 9:30:00 AM in Chicago, the temperature was -16 degrees.   
// </Snippet8>
