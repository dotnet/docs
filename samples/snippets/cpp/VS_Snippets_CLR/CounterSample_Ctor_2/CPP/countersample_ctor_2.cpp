// System::Diagnostics->CounterSample->CounterSample(long, long, long, long, long, long, PerformanceCounterType)
// System::Diagnostics->CounterSample->CounterSample(long, long, long, long, long, long, PerformanceCounterType, long)

/* The following program demonstrates the constructors of the 'CounterSample'
structure. It creates an instance of performance counter, configures it
to interact with 'Processor' category, '% Processor Time' counter and
'0' instance, creates an instance of 'CounterSample', and displays
the corresponding fields.
*/

#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

int main()
{
// <Snippet1>
   PerformanceCounter^ myPerformanceCounter1 = gcnew PerformanceCounter(
      "Processor","% Processor Time","0" );
   CounterSample myCounterSample1( 10L, 20L, 30L, 40L, 50L, 60L,
     PerformanceCounterType::AverageCount64 );
   Console::WriteLine( "CounterTimeStamp = {0}", myCounterSample1.CounterTimeStamp );

   Console::WriteLine( "BaseValue = {0}", myCounterSample1.BaseValue );
   Console::WriteLine( "RawValue = {0}", myCounterSample1.RawValue );
   Console::WriteLine( "CounterFrequency = {0}", myCounterSample1.CounterFrequency );
   Console::WriteLine( "SystemFrequency = {0}", myCounterSample1.SystemFrequency );
   Console::WriteLine( "TimeStamp = {0}", myCounterSample1.TimeStamp );
   Console::WriteLine( "TimeStamp100nSec = {0}", myCounterSample1.TimeStamp100nSec );
   Console::WriteLine( "CounterType = {0}", myCounterSample1.CounterType );
   // Hold the results of sample.
   myCounterSample1 = myPerformanceCounter1->NextSample();
   Console::WriteLine( "BaseValue = {0}", myCounterSample1.BaseValue );
   Console::WriteLine( "RawValue = {0}", myCounterSample1.RawValue );
   Console::WriteLine( "CounterFrequency = {0}", myCounterSample1.CounterFrequency );
   Console::WriteLine( "SystemFrequency = {0}", myCounterSample1.SystemFrequency );
   Console::WriteLine( "TimeStamp = {0}", myCounterSample1.TimeStamp );
   Console::WriteLine( "TimeStamp100nSec = {0}", myCounterSample1.TimeStamp100nSec );
   Console::WriteLine( "CounterType = {0}", myCounterSample1.CounterType );
// </Snippet1>
   Console::WriteLine( "" );
   Console::WriteLine( "" );
// <Snippet2>
   PerformanceCounter^ myPerformanceCounter2 =
      gcnew PerformanceCounter( "Processor","% Processor Time","0" );
   CounterSample myCounterSample2( 10L, 20L, 30L, 40L, 50L, 60L,
     PerformanceCounterType::AverageCount64,300);
   Console::WriteLine( "CounterTimeStamp = {0}", myCounterSample2.CounterTimeStamp );
   Console::WriteLine( "BaseValue = {0}", myCounterSample2.BaseValue );
   Console::WriteLine( "RawValue = {0}", myCounterSample2.RawValue );
   Console::WriteLine( "CounterFrequency = {0}", myCounterSample2.CounterFrequency );
   Console::WriteLine( "SystemFrequency = {0}", myCounterSample2.SystemFrequency );
   Console::WriteLine( "TimeStamp = {0}", myCounterSample2.TimeStamp );
   Console::WriteLine( "TimeStamp100nSec = {0}", myCounterSample2.TimeStamp100nSec );
   Console::WriteLine( "CounterType = {0}", myCounterSample2.CounterType );
   Console::WriteLine( "CounterTimeStamp = {0}", myCounterSample2.CounterTimeStamp );
   // Hold the results of sample.
   myCounterSample2 = myPerformanceCounter2->NextSample();
   Console::WriteLine( "BaseValue = {0}", myCounterSample2.BaseValue );
   Console::WriteLine( "RawValue = {0}", myCounterSample2.RawValue );
   Console::WriteLine( "CounterFrequency = {0}", myCounterSample2.CounterFrequency );
   Console::WriteLine( "SystemFrequency = {0}", myCounterSample2.SystemFrequency );
   Console::WriteLine( "TimeStamp = {0}", myCounterSample2.TimeStamp );
   Console::WriteLine( "TimeStamp100nSec = {0}", myCounterSample2.TimeStamp100nSec );
   Console::WriteLine( "CounterType = {0}", myCounterSample2.CounterType );
   Console::WriteLine( "CounterTimeStamp = {0}", myCounterSample2.CounterTimeStamp );
// </Snippet2>
}
