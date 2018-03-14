// Decimal1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet1>
using namespace System;

void main()
{
   Decimal dividend = Decimal::One;
   Decimal divisor = 3;
   // The following displays 0.9999999999999999999999999999 to the console
   Console::WriteLine(dividend/divisor * divisor);   
}
// </Snippet1>

