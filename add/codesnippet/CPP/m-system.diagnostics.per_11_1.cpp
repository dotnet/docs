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

   
   // Create the performance counter.
   PerformanceCounter^ PC = gcnew PerformanceCounter( categoryName,
                                                      counterName,
                                                      false );
   // Initialize the counter.
   PC->RawValue = Stopwatch::GetTimestamp();

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