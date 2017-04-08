// System::Diagnostics->CounterCreationDataCollection->CounterCreationDataCollection(CounterCreationData->Item[])

/*
The following program demonstrates 'CounterCreationDataCollection(CounterCreationData->Item[])'
constructor of 'CounterCreationDataCollection' class.
An instance of 'CounterCreationDataCollection' is created by passing an array of
'CounterCreationData' to the constructor. The counters of the 'CounterCreationDataCollection'
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
      
// <Snippet1>
      String^ myCategoryName;
      int numberOfCounters;
      Console::Write( "Enter the category Name : " );
      myCategoryName = Console::ReadLine();
      
      // Check if the category already exists or not.
      if (  !PerformanceCounterCategory::Exists( myCategoryName ) )
      {
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
         
         // Create the category.
         PerformanceCounterCategory::Create( myCategoryName, "Sample Category", myCounterCollection );
         for ( int i = 0; i < numberOfCounters; i++ )
         {
            myCounter = gcnew PerformanceCounter( myCategoryName,myCounterCreationData[ i ]->CounterName,"",false );

         }
         Console::WriteLine( "The list of counters in 'CounterCollection' are :" );
         for ( int i = 0; i < myCounterCollection->Count; i++ )
            Console::WriteLine( "Counter {0} is '{1}'", i, myCounterCollection[ i ]->CounterName );
      }
      else
      {
         Console::WriteLine( "The category already exists" );
      }
// </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}.", e->Message );
      return;
   }
}
