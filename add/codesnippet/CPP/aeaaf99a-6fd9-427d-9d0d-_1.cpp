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