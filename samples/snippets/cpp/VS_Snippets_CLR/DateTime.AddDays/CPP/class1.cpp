// <Snippet1>
using namespace System;

int main()
{
   // Calculate what day of the week is 36 days from this instant.
   DateTime today = System::DateTime::Now;
   DateTime answer = today.AddDays( 36 );
   Console::WriteLine("Today: {0:dddd}", today);
   Console::WriteLine("36 days from today: {0:dddd}", answer);
}
// The example displays output like the following:
//       Today: Wednesday
//       36 days from today: Thursday
// </Snippet1>
