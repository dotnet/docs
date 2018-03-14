// <Snippet3>
using namespace System;

//void main(array<System::String ^> ^args)
void main()
{
   DateTime dateRecorded(2009, 6, 15);
   DateTime startTime(1, 1, 1, 0, 30, 0);
   TimeSpan interval(12, 0, 0);

   Double temperature1 = 52.8;
   Double temperature2 = 63.5;
   
   Console::Write("Date: {0:d}:\n   Temperature at {1:t}: {2}\n   Temperature at {3:t}: {4}\n", 
                  dateRecorded, startTime, temperature1, 
                  startTime.Add(interval), temperature2);
    Console::ReadLine();
}
// The example displays the following output:
//      Date: 6/15/2009:
//         Temperature at 12:30 AM: 52.8
//         Temperature at 12:30 PM: 63.5
// </Snippet3>
