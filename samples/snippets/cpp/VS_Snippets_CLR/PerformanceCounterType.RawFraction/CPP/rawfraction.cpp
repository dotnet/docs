

//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Diagnostics;

//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
// Formula from MSDN -
//      Description - This counter type shows the ratio of a subset to its set as a percentage.
//            For example, it compares the number of bytes in use on a disk to the
//            total number of bytes on the disk. Counters of this type display the 
//            current percentage only, not an average over time.
//
// Generic type - Instantaneous, Percentage 
//        Formula - (N0 / D0), where D represents a measured attribute and N represents one
//            component of that attribute.
//
//        Average - SUM (N / D) /x 
//        Example - Paging File\% Usage Peak
//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
float MyComputeCounterValue( CounterSample rfSample )
{
   float numerator = (float)rfSample.RawValue;
   float denomenator = (float)rfSample.BaseValue;
   float counterValue = (numerator / denomenator) * 100;
   return counterValue;
}


// Output information about the counter sample.
void OutputSample( CounterSample s )
{
   Console::WriteLine( "+++++++++++" );
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
   if (  !PerformanceCounterCategory::Exists( "RawFractionSampleCategory" ) )
   {
      CounterCreationDataCollection^ CCDC = gcnew CounterCreationDataCollection;
      
      // Add the counter.
      CounterCreationData^ rf = gcnew CounterCreationData;
      rf->CounterType = PerformanceCounterType::RawFraction;
      rf->CounterName = "RawFractionSample";
      CCDC->Add( rf );
      
      // Add the base counter.
      CounterCreationData^ rfBase = gcnew CounterCreationData;
      rfBase->CounterType = PerformanceCounterType::RawBase;
      rfBase->CounterName = "RawFractionSampleBase";
      CCDC->Add( rfBase );
      
      // Create the category.
      PerformanceCounterCategory::Create( "RawFractionSampleCategory", "Demonstrates usage of the RawFraction performance counter type.", CCDC );
      return true;
   }
   else
   {
      Console::WriteLine( "Category exists - RawFractionSampleCategory" );
      return false;
   }
}

void CreateCounters( PerformanceCounter^% PC, PerformanceCounter^% BPC )
{
   
   // Create the counters.
   PC = gcnew PerformanceCounter( "RawFractionSampleCategory","RawFractionSample",false );
   BPC = gcnew PerformanceCounter( "RawFractionSampleCategory","RawFractionSampleBase",false );
   PC->RawValue = 0;
   BPC->RawValue = 0;
}

void CollectSamples( ArrayList^ samplesList, PerformanceCounter^ PC, PerformanceCounter^ BPC )
{
   Random^ r = gcnew Random( DateTime::Now.Millisecond );
   
   // Initialize the performance counter.
   PC->NextSample();
   
   // Loop for the samples.
   for ( int j = 0; j < 100; j++ )
   {
      int value = r->Next( 1, 10 );
      Console::Write( "{0} = {1}", j, value );
      
      // Increment the base every time, because the counter measures the number 
      // of high hits (raw fraction value) against all the hits (base value).
      BPC->Increment();
      
      // Get the % of samples that are 9 or 10 out of all the samples taken.
      if ( value >= 9 )
            PC->Increment();
      
      // Copy out the next value every ten times around the loop.
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
   for ( int i = 0; i < samplesList->Count; i++ )
   {
      
      // Output the sample.
      OutputSample(  *safe_cast<CounterSample^>(samplesList[ i ]) );
      
      // Use .NET to calculate the counter value.
      Console::WriteLine( ".NET computed counter value = {0}", CounterSampleCalculator::ComputeCounterValue(  *safe_cast<CounterSample^>(samplesList[ i ]) ) );
      
      // Calculate the counter value manually.
      Console::WriteLine( "My computed counter value = {0}", MyComputeCounterValue(  *safe_cast<CounterSample^>(samplesList[ i ]) ) );

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
