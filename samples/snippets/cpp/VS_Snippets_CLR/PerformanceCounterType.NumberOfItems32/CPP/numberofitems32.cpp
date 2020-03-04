

//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Diagnostics;
float MyComputeCounterValue( CounterSample s0, CounterSample s1 )
{
   float counterValue = (float)s1.RawValue;
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
   if (  !PerformanceCounterCategory::Exists( "NumberOfItems32SampleCategory" ) )
   {
      CounterCreationDataCollection^ CCDC = gcnew CounterCreationDataCollection;

      // Add the counter.
      CounterCreationData^ NOI64 = gcnew CounterCreationData;
      NOI64->CounterType = PerformanceCounterType::NumberOfItems64;
      NOI64->CounterName = "NumberOfItems32Sample";
      CCDC->Add( NOI64 );

      // Create the category.
      PerformanceCounterCategory::Create( "NumberOfItems32SampleCategory", "Demonstrates usage of the NumberOfItems32 performance counter type.", CCDC );
      return true;
   }
   else
   {
      Console::WriteLine( "Category exists - NumberOfItems32SampleCategory" );
      return false;
   }
}

void CreateCounters( PerformanceCounter^% PC )
{
   // Create the counter.
   PC = gcnew PerformanceCounter( "NumberOfItems32SampleCategory","NumberOfItems32Sample",false );
   PC->RawValue = 0;
}

void CollectSamples( ArrayList^ samplesList, PerformanceCounter^ PC )
{
   Random^ r = gcnew Random( DateTime::Now.Millisecond );

   // Loop for the samples.
   for ( int j = 0; j < 100; j++ )
   {
      int value = r->Next( 1, 10 );
      Console::Write( "{0} = {1}", j, value );
      PC->IncrementBy( value );
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

void main()
{
   ArrayList^ samplesList = gcnew ArrayList;
   PerformanceCounter^ PC;
   SetupCategory();
   CreateCounters( PC );
   CollectSamples( samplesList, PC );
   CalculateResults( samplesList );
}
//</snippet1>
