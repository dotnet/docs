// Notice that the sample is conditionally compiled for Everett vs.
// Whidbey builds.  Whidbey introduced new APIs that are not available
// in Everett.  Snippet IDs do not overlap between Whidbey and Everett;
// Snippet #1 is Everett, Snippet #2 and #3 are Whidbey.

#if ( BELOW_WHIDBEY_BUILD ) 

//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Diagnostics;
using namespace System::Runtime::InteropServices;

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

// Reads the counter information to enable setting the RawValue.
[DllImport("Kernel32.dll")]
extern bool QueryPerformanceCounter( [Out]__int64 * value );

bool SetupCategory()
{
   if (  !PerformanceCounterCategory::Exists( "ElapsedTimeSampleCategory" ) )
   {
      CounterCreationDataCollection^ CCDC = gcnew CounterCreationDataCollection;
      
      // Add the counter.
      CounterCreationData^ ETimeData = gcnew CounterCreationData;
      ETimeData->CounterType = PerformanceCounterType::ElapsedTime;
      ETimeData->CounterName = "ElapsedTimeSample";
      CCDC->Add( ETimeData );
      
      // Create the category.
      PerformanceCounterCategory::Create( "ElapsedTimeSampleCategory",
         "Demonstrates usage of the ElapsedTime performance counter type.",
         CCDC );
      return true;
   }
   else
   {
      Console::WriteLine( "Category exists - ElapsedTimeSampleCategory" );
      return false;
   }
}

void CreateCounters( PerformanceCounter^% PC )
{
   // Create the counter.
   PC = gcnew PerformanceCounter( "ElapsedTimeSampleCategory",
      "ElapsedTimeSample",
      false );
}

void CollectSamples( ArrayList^ samplesList, PerformanceCounter^ PC )
{
   __int64 pcValue;
   DateTime Start;
   
   // Initialize the counter.
   QueryPerformanceCounter(  &pcValue );
   PC->RawValue = pcValue;
   Start = DateTime::Now;
   
   // Loop for the samples.
   for ( int j = 0; j < 1000; j++ )
   {
      // Output the values.
      if ( (j % 10) == 9 )
      {
         Console::WriteLine( "NextValue() = {0}", PC->NextValue() );
         Console::WriteLine( "Actual elapsed time = {0}", DateTime::Now.Subtract( Start ) );
         OutputSample( PC->NextSample() );
         samplesList->Add( PC->NextSample() );
      }
      
      // reset the counter on 100th iteration.
      if ( j % 100 == 0 )
      {
         QueryPerformanceCounter(  &pcValue );
         PC->RawValue = pcValue;
         Start = DateTime::Now;
      }
      System::Threading::Thread::Sleep( 50 );
   }

   Console::WriteLine( "Elapsed time = {0}", DateTime::Now.Subtract( Start ) );
}

void main()
{
   ArrayList^ samplesList = gcnew ArrayList;
//   PerformanceCounter^ PC;
   SetupCategory();
//   CreateCounters( PC );
   CreateCounters();
   CollectSamples( samplesList, PC );
}
//</snippet1>

#else 
// Build sample for Whidbey or higher.

//<snippet2>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Diagnostics;
using namespace System::Runtime::InteropServices;

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

void CollectSamples()
{
   String^ categoryName = "ElapsedTimeSampleCategory";
   String^ counterName = "ElapsedTimeSample";
   
   // Create the performance counter category.
   if (  !PerformanceCounterCategory::Exists( categoryName ) )
   {
      CounterCreationDataCollection^ CCDC = gcnew CounterCreationDataCollection;
      
      // Add the counter.
      CounterCreationData^ ETimeData = gcnew CounterCreationData;
      ETimeData->CounterType = PerformanceCounterType::ElapsedTime;
      ETimeData->CounterName = counterName;
      CCDC->Add( ETimeData );
      
      // Create the category.
      PerformanceCounterCategory::Create( categoryName,
         "Demonstrates ElapsedTime performance counter usage.",
         CCDC );
   }
   else
   {
      Console::WriteLine( "Category exists - {0}", categoryName );
   }

   
   //<Snippet3>
   // Create the performance counter.
   PerformanceCounter^ PC = gcnew PerformanceCounter( categoryName,
                                                      counterName,
                                                      false );
   // Initialize the counter.
   PC->RawValue = Stopwatch::GetTimestamp();
   //</Snippet3>

   DateTime Start = DateTime::Now;
   
   // Loop for the samples.
   for ( int j = 0; j < 100; j++ )
   {
      // Output the values.
      if ( (j % 10) == 9 )
      {
         Console::WriteLine( "NextValue() = {0}", PC->NextValue() );
         Console::WriteLine( "Actual elapsed time = {0}", DateTime::Now.Subtract( Start ) );
         OutputSample( PC->NextSample() );
      }
      
      // Reset the counter on every 20th iteration.
      if ( j % 20 == 0 )
      {
         PC->RawValue = Stopwatch::GetTimestamp();
         Start = DateTime::Now;
      }
      System::Threading::Thread::Sleep( 50 );
   }

   Console::WriteLine( "Elapsed time = {0}", DateTime::Now.Subtract( Start ) );
}

int main()
{
   CollectSamples();
}
// </Snippet2>
#endif 
