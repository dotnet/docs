// System::Diagnostics->CounterCreationDataCollection->CounterCreationDataCollection(CounterCreationDataCollection)

/*
The following program demonstrates 'CounterCreationDataCollection(CounterCreationDataCollection)'
constructor of 'CounterCreationDataCollection' class.
An instance of 'CounterCreationDataCollection' is created by passing another instance
of 'CounterCreationDataCollection'. The counters of the 'CounterCreationDataCollection'
are displayed to the console.
*/

#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
void main()
{
   PerformanceCounter^ myCounter;
   try
   {
      String^ myCategoryName;
      int numberOfCounters;
      Console::Write( "Enter the number of counters : " );
      numberOfCounters = Int32::Parse( Console::ReadLine() );
      array<CounterCreationData^>^myCounterCreationData = gcnew array<CounterCreationData^>(numberOfCounters);
      for ( int i = 0; i < numberOfCounters; i++ )
      {
         Console::Write( "Enter the counter name for {0} counter : ", i );
         myCounterCreationData[ i ] = gcnew CounterCreationData;
         myCounterCreationData[ i ]->CounterName = Console::ReadLine();

      }
      CounterCreationDataCollection^ myCounterCollection = gcnew CounterCreationDataCollection( myCounterCreationData );
      Console::Write( "Enter the category Name:" );
      myCategoryName = Console::ReadLine();
      
      // Check if the category already exists or not.
      if (  !PerformanceCounterCategory::Exists( myCategoryName ) )
      {
         CounterCreationDataCollection^ myNewCounterCollection = gcnew CounterCreationDataCollection( myCounterCollection );
         PerformanceCounterCategory::Create( myCategoryName, "Sample Category", myNewCounterCollection );
         for ( int i = 0; i < numberOfCounters; i++ )
         {
            myCounter = gcnew PerformanceCounter( myCategoryName,myCounterCreationData[ i ]->CounterName,"",false );

         }
         Console::WriteLine( "The list of counters in 'CounterCollection' are : " );
         for ( int i = 0; i < myNewCounterCollection->Count; i++ )
            Console::WriteLine( "Counter {0} is '{1}'", i, myNewCounterCollection[ i ]->CounterName );
      }
      else
      {
         Console::WriteLine( "The category already exists" );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}.", e->Message );
      return;
   }
}
