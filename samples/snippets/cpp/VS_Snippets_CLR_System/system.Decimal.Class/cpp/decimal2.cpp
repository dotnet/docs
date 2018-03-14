// Decimal2.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"
// <Snippet2>
using namespace System;


void main()
{
   Decimal dividend = Decimal::One;
   Decimal divisor = 3;
   // The following displays 1.00 to the console
   Console::WriteLine(Math::Round(dividend/divisor * divisor, 2));   	
}
// </Snippet2>


