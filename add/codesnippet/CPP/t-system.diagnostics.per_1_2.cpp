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