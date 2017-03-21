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