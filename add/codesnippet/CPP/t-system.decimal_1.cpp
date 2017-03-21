using namespace System;

void main()
{
   Decimal dividend = Decimal::One;
   Decimal divisor = 3;
   // The following displays 0.9999999999999999999999999999 to the console
   Console::WriteLine(dividend/divisor * divisor);   
}