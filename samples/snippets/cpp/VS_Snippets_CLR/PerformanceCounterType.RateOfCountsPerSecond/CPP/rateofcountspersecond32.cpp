

//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Diagnostics;

//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
//    PERF_COUNTER_COUNTER
//    Description     - This counter type shows the average number of operations completed
//        during each second of the sample interval. Counters of this type
//        measure time in ticks of the system clock. The F variable represents
//        the number of ticks per second. The value of F is factored into the
//        equation so that the result can be displayed in seconds.
//
//    Generic type - Difference
//
//    Formula - (N1 - N0) / ( (D1 - D0) / F), where the numerator (N) represents the number
//        of operations performed during the last sample interval, the denominator
//        (D) represents the number of ticks elapsed during the last sample
//        interval, and F is the frequency of the ticks.
//
//         Average - (Nx - N0) / ((Dx - D0) / F) 
//
//       Example - System\ File Read Operations/sec 
//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
float MyComputeCounterValue( CounterSample s0, CounterSample s1 )
{
   float numerator = (float)(s1.RawValue - s0.RawValue);
   float denomenator = (float)(s1.TimeStamp - s0.TimeStamp) / (float)s1.SystemFrequency;
   float counterValue = numerator / denomenator;
   return counterValue;
}


// Output information about the counter sample.
void OutputSample( CounterSample s )
{
   Console::WriteLine( "\r\n+++++++++++" );
   Console::WriteLine( "Sample values - \r\n" );
   Console::WriteLine( "   BaseValue        = {0}", s.BaseValue );
   Console::WriteLine( "   CounterFrequency = {0}", s.CounterFrequency );
   Console::WriteLine( "   CounterTimeStamp = {0}", s.CounterTimeStamp );
   Console::WriteLine( "   CounterType      = {0}", s.CounterType );
   Console::WriteLine( "   RawValue         = {0}", s.RawValue );
   Console::WriteLine( "   SystemFrequency  = {0}", s.SystemFrequency );
   Console::WriteLine( "   TimeStamp        = {0}", s.TimeStamp );
   Console::WriteLine( "   TimeStamp100nSec = {0}", s.TimeStamp100nSec );
   Console::WriteLine( "++++++++++++++++++++++" );
}

bool SetupCategory()
{
   if (  !PerformanceCounterCategory::Exists( "RateOfCountsPerSecond32SampleCategory" ) )
   {
      CounterCreationDataCollection^ CCDC = gcnew CounterCreationDataCollection;

      // Add the counter.
      CounterCreationData^ rateOfCounts32 = gcnew CounterCreationData;
      rateOfCounts32->CounterType = PerformanceCounterType::RateOfCountsPerSecond32;
      rateOfCounts32->CounterName = "RateOfCountsPerSecond32Sample";
      CCDC->Add( rateOfCounts32 );

      // Create the category.
      PerformanceCounterCategory::Create( "RateOfCountsPerSecond32SampleCategory", "Demonstrates usage of the RateOfCountsPerSecond32 performance counter type.", CCDC );
      return true;
   }
   else
   {
      Console::WriteLine( "Category exists - RateOfCountsPerSecond32SampleCategory" );
      return false;
   }
}

void CreateCounters( PerformanceCounter^% PC )
{
   // Create the counter.
   PC = gcnew PerformanceCounter( "RateOfCountsPerSecond32SampleCategory","RateOfCountsPerSecond32Sample",false );
   PC->RawValue = 0;
}

void CollectSamples( ArrayList^ samplesList, PerformanceCounter^ PC )
{
   Random^ r = gcnew Random( DateTime::Now.Millisecond );

   // Initialize the performance counter.
   PC->NextSample();

   // Loop for the samples.
   for ( int j = 0; j < 100; j++ )
   {
      int value = r->Next( 1, 10 );
      PC->IncrementBy( value );
      Console::Write( "{0} = {1}", j, value );
      if ( (j % 10) == 9 )
      {
         Console::WriteLine( ";       NextValue() = {0}", PC->NextValue() );
         OutputSample( PC->NextSample() );
         samplesList->Add( PC->NextSample() );
      }
      else
            Console::WriteLine();
      System::Threading::Thread::Sleep( 50 );
   }
}

void CalculateResults( ArrayList^ samplesList )
{
   for ( int i = 0; i < (samplesList->Count - 1); i++ )
   {
      // Output the sample.
      OutputSample(  *safe_cast<CounterSample^>(samplesList[ i ]) );
      OutputSample(  *safe_cast<CounterSample^>(samplesList[ i + 1 ]) );

      // Use .NET to calculate the counter value.
      Console::WriteLine( ".NET computed counter value = {0}", CounterSampleCalculator::ComputeCounterValue(  *safe_cast<CounterSample^>(samplesList[ i ]),  *safe_cast<CounterSample^>(samplesList[ i + 1 ]) ) );

      // Calculate the counter value manually.
      Console::WriteLine( "My computed counter value = {0}", MyComputeCounterValue(  *safe_cast<CounterSample^>(samplesList[ i ]),  *safe_cast<CounterSample^>(samplesList[ i + 1 ]) ) );
   }
}

int main()
{
   ArrayList^ samplesList = gcnew ArrayList;
   PerformanceCounter^ PC;
   SetupCategory();
   CreateCounters( PC );
   CollectSamples( samplesList, PC );
   CalculateResults( samplesList );
}
//</snippet1>
