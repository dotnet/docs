

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

//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
// PERF_AVERAGE_TIMER
//  Description - This counter type measures the time it takes, on 
//     average, to complete a process or operation. Counters of this
//     type display a ratio of the total elapsed time of the sample 
//     interval to the number of processes or operations completed
//     during that time. This counter type measures time in ticks 
//     of the system clock. The F variable represents the number of
//     ticks per second. The value of F is factored into the equation
//     so that the result can be displayed in seconds.
//    
//  Generic type - Average
//    
//  Formula - ((N1 - N0) / F) / (D1 - D0), where the numerator (N)
//     represents the number of ticks counted during the last 
//     sample interval, F represents the frequency of the ticks, 
//     and the denominator (D) represents the number of operations
//     completed during the last sample interval.
//    
//  Average - ((Nx - N0) / F) / (Dx - D0)
//    
//  Example - PhysicalDisk\ Avg. Disk sec/Transfer 
//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
float MyComputeCounterValue( CounterSample s0, CounterSample s1 )
{
    __int64 n1 = s1.RawValue;
    __int64 n0 = s0.RawValue;
    unsigned __int64 f = s1.SystemFrequency;
    __int64 d1 = s1.BaseValue;
    __int64 d0 = s0.BaseValue;
    double numerator = (double)(n1 - n0);
    double denominator = (double)(d1 - d0);
    float counterValue = (float)(numerator / f) / denominator;
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


[DllImport("Kernel32.dll")]
extern bool QueryPerformanceCounter( [Out]__int64 * value );
bool SetupCategory()
{
    if (  !PerformanceCounterCategory::Exists( "AverageTimer32SampleCategory") )
        {
        CounterCreationDataCollection^ CCDC = gcnew CounterCreationDataCollection;

        // Add the counter.
        CounterCreationData^ averageTimer32 = gcnew CounterCreationData;
        averageTimer32->CounterType = PerformanceCounterType::AverageTimer32;
        averageTimer32->CounterName = "AverageTimer32Sample";
        CCDC->Add( averageTimer32 );

        // Add the base counter.
        CounterCreationData^ averageTimer32Base = gcnew CounterCreationData;
        averageTimer32Base->CounterType = PerformanceCounterType::AverageBase;
        averageTimer32Base->CounterName = "AverageTimer32SampleBase";
        CCDC->Add( averageTimer32Base );

        // Create the category.
        PerformanceCounterCategory::Create( "AverageTimer32SampleCategory",
             "Demonstrates usage of the AverageTimer32 performance counter type", CCDC );
        return (true);
        }

    Console::WriteLine( "Category exists - AverageTimer32SampleCategory" );
    return (false);
}

void CreateCounters( PerformanceCounter^% PC, PerformanceCounter^% BPC )
{
    // Create the counters.
    PC = gcnew PerformanceCounter( "AverageTimer32SampleCategory","AverageTimer32Sample",false );
    BPC = gcnew PerformanceCounter( "AverageTimer32SampleCategory","AverageTimer32SampleBase",false );
    PC->RawValue = 0;
    BPC->RawValue = 0;
}

void CollectSamples( ArrayList^ samplesList, PerformanceCounter^ PC, 
PerformanceCounter^ BPC )
{
    __int64 perfTime = 0;
    Random^ r = gcnew Random( DateTime::Now.Millisecond );
    
    // Loop for the samples.
    for ( int i = 0; i < 10; i++ )
    {
    QueryPerformanceCounter(  &perfTime );
    PC->RawValue = perfTime;
    BPC->IncrementBy( 10 );
    System::Threading::Thread::Sleep( 1000 );
    Console::WriteLine( "Next value = {0}", PC->NextValue() );
    samplesList->Add( PC->NextSample() );
    }
}

void CalculateResults( ArrayList^ samplesList )
{
    for ( int i = 0; i < (samplesList->Count - 1); i++ )
    {
    // Output the sample.
    OutputSample(  *safe_cast<CounterSample^>(samplesList->Item[ i ]) );
    OutputSample(  *safe_cast<CounterSample^>(samplesList->Item[ i + 1 ]) );

    // Use .NET to calculate the counter value.
    Console::WriteLine( ".NET computed counter value = {0}",
         CounterSample::Calculate(  *safe_cast<CounterSample^>(samplesList->Item[ i ]),
         *safe_cast<CounterSample^>(samplesList->Item[ i + 1 ]) ) );

    // Calculate the counter value manually.
    Console::WriteLine( "My computed counter value = {0}", 
         MyComputeCounterValue(  *safe_cast<CounterSample^>(samplesList->Item[ i ]),
         *safe_cast<CounterSample^>(samplesList->Item[ i + 1 ]) ) );
    }
}

void main()
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

#else 

//<snippet2>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Diagnostics;
using namespace System::Runtime::InteropServices;

//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
// PERF_AVERAGE_TIMER
//  Description - This counter type measures the time it takes, on 
//     average, to complete a process or operation. Counters of this
//     type display a ratio of the total elapsed time of the sample 
//     interval to the number of processes or operations completed
//     during that time. This counter type measures time in ticks 
//     of the system clock. The F variable represents the number of
//     ticks per second. The value of F is factored into the equation
//     so that the result can be displayed in seconds.
//    
//  Generic type - Average
//    
//  Formula - ((N1 - N0) / F) / (D1 - D0), where the numerator (N)
//     represents the number of ticks counted during the last 
//     sample interval, F represents the frequency of the ticks, 
//     and the denominator (D) represents the number of operations
//     completed during the last sample interval.
//    
//  Average - ((Nx - N0) / F) / (Dx - D0)
//    
//  Example - PhysicalDisk\ Avg. Disk sec/Transfer 
//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//+++++++
float MyComputeCounterValue( CounterSample s0, CounterSample s1 )
{
    __int64 n1 = s1.RawValue;
    __int64 n0 = s0.RawValue;
    unsigned __int64 f = s1.SystemFrequency;
    __int64 d1 = s1.BaseValue;
    __int64 d0 = s0.BaseValue;
    double numerator = (double)(n1 - n0);
    double denominator = (double)(d1 - d0);
    float counterValue = (float)((numerator / f) / denominator);
    return counterValue;
}

// Output information about the counter sample.
void OutputSample( CounterSample s )
{
    Console::WriteLine( "+++++++++++" );
    Console::WriteLine( "Sample values - \r\n" );
    Console::WriteLine( "   CounterType      = {0}", s.CounterType );
    Console::WriteLine( "   RawValue         = {0}", s.RawValue.ToString() );
    Console::WriteLine( "   BaseValue        = {0}", s.BaseValue.ToString() );
    Console::WriteLine( "   CounterFrequency = {0}", s.CounterFrequency.ToString() );
    Console::WriteLine( "   CounterTimeStamp = {0}", s.CounterTimeStamp.ToString() );
    Console::WriteLine( "   SystemFrequency  = {0}", s.SystemFrequency.ToString() );
    Console::WriteLine( "   TimeStamp        = {0}", s.TimeStamp.ToString() );
    Console::WriteLine( "   TimeStamp100nSec = {0}", s.TimeStamp100nSec.ToString() );
    Console::WriteLine( "++++++++++++++++++++++" );
}

bool SetupCategory()
{
    if (  !PerformanceCounterCategory::Exists( "AverageTimer32SampleCategory") )
       {
        CounterCreationDataCollection^ CCDC = gcnew CounterCreationDataCollection;

        // Add the counter.
        CounterCreationData^ averageTimer32 = gcnew CounterCreationData;
        averageTimer32->CounterType = PerformanceCounterType::AverageTimer32;
        averageTimer32->CounterName = "AverageTimer32Sample";
        CCDC->Add( averageTimer32 );

        // Add the base counter.
        CounterCreationData^ averageTimer32Base = gcnew CounterCreationData;
        averageTimer32Base->CounterType = PerformanceCounterType::AverageBase;
        averageTimer32Base->CounterName = "AverageTimer32SampleBase";
        CCDC->Add( averageTimer32Base );

        // Create the category.
        PerformanceCounterCategory::Create( "AverageTimer32SampleCategory", 
            "Demonstrates usage of the AverageTimer32 performance counter type", 
            PerformanceCounterCategoryType::SingleInstance, CCDC );
        Console::WriteLine( "Category created - AverageTimer32SampleCategory" );
        return (true);
        }

    Console::WriteLine( "Category exists - AverageTimer32SampleCategory" );
    return (false);
}

void CreateCounters( PerformanceCounter^% PC, PerformanceCounter^% BPC )
{
    // Create the counters.
    PC = gcnew PerformanceCounter( "AverageTimer32SampleCategory","AverageTimer32Sample",false );
    BPC = gcnew PerformanceCounter( "AverageTimer32SampleCategory","AverageTimer32SampleBase",false );
    PC->RawValue = 0;
    BPC->RawValue = 0;
}

void CollectSamples( ArrayList^ samplesList, PerformanceCounter^ PC, 
PerformanceCounter^ BPC )
{
    __int64 perfTime = 0;
    Random^ r = gcnew Random( DateTime::Now.Millisecond );

    // Loop for the samples.
    for ( int i = 0; i < 10; i++ )
        {
        PC->RawValue = Stopwatch::GetTimestamp();
        BPC->IncrementBy( 10 );
        System::Threading::Thread::Sleep( 1000 );
        Console::WriteLine( "Next value = {0}", PC->NextValue().ToString() );
        samplesList->Add( PC->NextSample() );
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
        Console::WriteLine( ".NET computed counter value = {0}",
           CounterSample::Calculate(  *safe_cast<CounterSample^>(samplesList[ i ]),
           *safe_cast<CounterSample^>(samplesList[ i + 1 ]) ) );

        // Calculate the counter value manually.
        Console::WriteLine( "My computed counter value = {0}", 
            MyComputeCounterValue(  *safe_cast<CounterSample^>(samplesList[ i ]),
           *safe_cast<CounterSample^>(samplesList[ i + 1 ]) ) );
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

    Console::WriteLine("\n\nHit ENTER to return");
    Console::ReadLine();
}
//</snippet2>
#endif 




/*  This sample produces the following output:

Category exists - AverageTimer32SampleCategory
Next value = 0
Next value = 0.2922242
Next value = 0.1006012
Next value = 0.1026979
Next value = 0.1000201
Next value = 0.09999784
Next value = 0.1000056
Next value = 0.1000048
Next value = 0.1000179
Next value = 0.0999926
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 245993582716663
   BaseValue        = 10
   CounterFrequency = 3391660000
   CounterTimeStamp = 246003493730416
   SystemFrequency  = 3391660000
   TimeStamp        = 246003493243766
   TimeStamp100nSec = 128354785913052296
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246003493967464
   BaseValue        = 20
   CounterFrequency = 3391660000
   CounterTimeStamp = 246006905797637
   SystemFrequency  = 3391660000
   TimeStamp        = 246006905071074
   TimeStamp100nSec = 128354785923052232
++++++++++++++++++++++
.NET computed counter value = 0.2922242
My computed counter value = 0.2922242
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246003493967464
   BaseValue        = 20
   CounterFrequency = 3391660000
   CounterTimeStamp = 246006905797637
   SystemFrequency  = 3391660000
   TimeStamp        = 246006905071074
   TimeStamp100nSec = 128354785923052232
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246006906017226
   BaseValue        = 30
   CounterFrequency = 3391660000
   CounterTimeStamp = 246010389015238
   SystemFrequency  = 3391660000
   TimeStamp        = 246010388506317
   TimeStamp100nSec = 128354785933364666
++++++++++++++++++++++
.NET computed counter value = 0.1006012
My computed counter value = 0.1006012
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246006906017226
   BaseValue        = 30
   CounterFrequency = 3391660000
   CounterTimeStamp = 246010389015238
   SystemFrequency  = 3391660000
   TimeStamp        = 246010388506317
   TimeStamp100nSec = 128354785933364666
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246010389179424
   BaseValue        = 40
   CounterFrequency = 3391660000
   CounterTimeStamp = 246013781326656
   SystemFrequency  = 3391660000
   TimeStamp        = 246013780865880
   TimeStamp100nSec = 128354785943364602
++++++++++++++++++++++
.NET computed counter value = 0.1026979
My computed counter value = 0.1026979
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246010389179424
   BaseValue        = 40
   CounterFrequency = 3391660000
   CounterTimeStamp = 246013781326656
   SystemFrequency  = 3391660000
   TimeStamp        = 246013780865880
   TimeStamp100nSec = 128354785943364602
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246013781520023
   BaseValue        = 50
   CounterFrequency = 3391660000
   CounterTimeStamp = 246017172950765
   SystemFrequency  = 3391660000
   TimeStamp        = 246017172485449
   TimeStamp100nSec = 128354785953364538
++++++++++++++++++++++
.NET computed counter value = 0.1000201
My computed counter value = 0.1000201
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246013781520023
   BaseValue        = 50
   CounterFrequency = 3391660000
   CounterTimeStamp = 246017172950765
   SystemFrequency  = 3391660000
   TimeStamp        = 246017172485449
   TimeStamp100nSec = 128354785953364538
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246017173106808
   BaseValue        = 60
   CounterFrequency = 3391660000
   CounterTimeStamp = 246020564801041
   SystemFrequency  = 3391660000
   TimeStamp        = 246020564333499
   TimeStamp100nSec = 128354785963364474
++++++++++++++++++++++
.NET computed counter value = 0.09999784
My computed counter value = 0.09999784
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246017173106808
   BaseValue        = 60
   CounterFrequency = 3391660000
   CounterTimeStamp = 246020564801041
   SystemFrequency  = 3391660000
   TimeStamp        = 246020564333499
   TimeStamp100nSec = 128354785963364474
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246020564958427
   BaseValue        = 70
   CounterFrequency = 3391660000
   CounterTimeStamp = 246023956622001
   SystemFrequency  = 3391660000
   TimeStamp        = 246023956148126
   TimeStamp100nSec = 128354785973364410
++++++++++++++++++++++
.NET computed counter value = 0.1000056
My computed counter value = 0.1000056
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246020564958427
   BaseValue        = 70
   CounterFrequency = 3391660000
   CounterTimeStamp = 246023956622001
   SystemFrequency  = 3391660000
   TimeStamp        = 246023956148126
   TimeStamp100nSec = 128354785973364410
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246023956781555
   BaseValue        = 80
   CounterFrequency = 3391660000
   CounterTimeStamp = 246027348892339
   SystemFrequency  = 3391660000
   TimeStamp        = 246027348432710
   TimeStamp100nSec = 128354785983364346
++++++++++++++++++++++
.NET computed counter value = 0.1000048
My computed counter value = 0.1000048
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246023956781555
   BaseValue        = 80
   CounterFrequency = 3391660000
   CounterTimeStamp = 246027348892339
   SystemFrequency  = 3391660000
   TimeStamp        = 246027348432710
   TimeStamp100nSec = 128354785983364346
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246027349049997
   BaseValue        = 90
   CounterFrequency = 3391660000
   CounterTimeStamp = 246030740294504
   SystemFrequency  = 3391660000
   TimeStamp        = 246030739836839
   TimeStamp100nSec = 128354785993364282
++++++++++++++++++++++
.NET computed counter value = 0.1000179
My computed counter value = 0.1000179
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246027349049997
   BaseValue        = 90
   CounterFrequency = 3391660000
   CounterTimeStamp = 246030740294504
   SystemFrequency  = 3391660000
   TimeStamp        = 246030739836839
   TimeStamp100nSec = 128354785993364282
++++++++++++++++++++++
+++++++++++
Sample values -

   CounterType      = AverageTimer32
   RawValue         = 246030740458758
   BaseValue        = 100
   CounterFrequency = 3391660000
   CounterTimeStamp = 246034132151377
   SystemFrequency  = 3391660000
   TimeStamp        = 246034131692912
   TimeStamp100nSec = 128354786003364218
++++++++++++++++++++++
.NET computed counter value = 0.0999926
My computed counter value = 0.0999926


Hit ENTER to return

*/