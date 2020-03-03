
//<snippet1>
// This example demonstrates the DateTime.DayOfWeek property
using namespace System;
int main()
{
   
   // Assume the current culture is en-US.
   // Create a DateTime for the first of May, 2003.
   DateTime dt = DateTime(2003,5,1);
   Console::WriteLine(  "Is Thursday the day of the week for {0:d}?: {1}", dt, dt.DayOfWeek == DayOfWeek::Thursday );
   Console::WriteLine(  "The day of the week for {0:d} is {1}.", dt, dt.DayOfWeek );
}

/*
This example produces the following results:

Is Thursday the day of the week for 5/1/2003?: True
The day of the week for 5/1/2003 is Thursday.
*/
//</snippet1>
