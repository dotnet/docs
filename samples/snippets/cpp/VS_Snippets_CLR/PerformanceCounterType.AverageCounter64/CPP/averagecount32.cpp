//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Diagnostics;

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

//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
//    Description - This counter type shows how many items are processed, on average,
//        during an operation. Counters of this type display a ratio of the items 
//        processed (such as bytes sent) to the number of operations completed. The  
//        ratio is calculated by comparing the number of items processed during the 
//        last interval to the number of operations completed during the last interval. 
// Generic type - Average
//      Formula - (N1 - N0) / (D1 - D0), where the numerator (N) represents the number 
//        of items processed during the last sample interval and the denominator (D) 
//        represents the number of operations completed during the last two sample 
//        intervals. 
//    Average (Nx - N0) / (Dx - D0)  
//    Example PhysicalDisk\ Avg. Disk Bytes/Transfer 
//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
float MyComputeCounterValue( CounterSample s0, CounterSample s1 )
{
   float numerator = (float)s1.RawValue - (float)s0.RawValue;
   float denomenator = (float)s1.BaseValue - (float)s0.BaseValue;
   float counterValue = numerator / denomenator;
   return counterValue;
}

bool SetupCategory()
{
   if (  !PerformanceCounterCategory::Exists( "AverageCounter64SampleCategory" ) )
   {
      CounterCreationDataCollection^ CCDC = gcnew CounterCreationDataCollection;
      
      // Add the counter.
      CounterCreationData^ averageCount64 = gcnew CounterCreationData;
      averageCount64->CounterType = PerformanceCounterType::AverageCount64;
      averageCount64->CounterName = "AverageCounter64Sample";
      CCDC->Add( averageCount64 );
      
      // Add the base counter.
      CounterCreationData^ averageCount64Base = gcnew CounterCreationData;
      averageCount64Base->CounterType = PerformanceCounterType::AverageBase;
      averageCount64Base->CounterName = "AverageCounter64SampleBase";
      CCDC->Add( averageCount64Base );
      
      // Create the category.
      PerformanceCounterCategory::Create( "AverageCounter64SampleCategory", "Demonstrates usage of the AverageCounter64 performance counter type.", CCDC );
      return (true);
   }
   else
   {
      Console::WriteLine( "Category exists - AverageCounter64SampleCategory" );
      return (false);
   }
}

void CreateCounters( PerformanceCounter^% PC, PerformanceCounter^% BPC )
{
   
   // Create the counters.
   //<snippet2>
   PC = gcnew PerformanceCounter( "AverageCounter64SampleCategory","AverageCounter64Sample",false );
   //</snippet2>

   BPC = gcnew PerformanceCounter( "AverageCounter64SampleCategory","AverageCounter64SampleBase",false );
   PC->RawValue = 0;
   BPC->RawValue = 0;
}
//<Snippet3>
void CollectSamples( ArrayList^ samplesList, PerformanceCounter^ PC, PerformanceCounter^ BPC )
{
   Random^ r = gcnew Random( DateTime::Now.Millisecond );

   // Loop for the samples.
   for ( int j = 0; j < 100; j++ )
   {
      int value = r->Next( 1, 10 );
      Console::Write( "{0} = {1}", j, value );
      PC->IncrementBy( value );
      BPC->Increment();
      if ( (j % 10) == 9 )
      {
         OutputSample( PC->NextSample() );
         samplesList->Add( PC->NextSample() );
      }
      else
            Console::WriteLine();
      System::Threading::Thread::Sleep( 50 );
   }
}
//</Snippet3>

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
   PerformanceCounter^ BPC;
   SetupCategory();
   CreateCounters( PC, BPC );
   CollectSamples( samplesList, PC, BPC );
   CalculateResults( samplesList );
}
//</snippet1>
