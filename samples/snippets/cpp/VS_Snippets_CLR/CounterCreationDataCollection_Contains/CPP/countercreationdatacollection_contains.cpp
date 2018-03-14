// System::Diagnostics->CounterCreationDataCollection::Contains(CounterCreationData)
// System::Diagnostics->CounterCreationDataCollection::Remove(CounterCreationData)

/*
The following program demonstrates 'Contains' and 'Remove' methods of
'CounterCreationDataCollection' class. An instance of 'CounterCreationDataCollection'
is created by passing an array of 'CounterCreationData'. A particular instance of
'CounterCreationData' is removed if it exist in the 'CounterCreationDataCollection'.
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
// <Snippet2>
      String^ myCategoryName;
      int numberOfCounters;
      Console::Write( "Enter the category Name :" );
      myCategoryName = Console::ReadLine();
      // Check if the category already exists or not.
      if (  !PerformanceCounterCategory::Exists( myCategoryName ) )
      {
         Console::Write( "Enter the number of counters : " );
         numberOfCounters = Int32::Parse( Console::ReadLine() );
         array<CounterCreationData^>^ myCounterCreationData =
            gcnew array<CounterCreationData^>(numberOfCounters);
         for ( int i = 0; i < numberOfCounters; i++ )
         {
            Console::Write( "Enter the counter name for {0} counter : ", i );
            myCounterCreationData[ i ] = gcnew CounterCreationData;
            myCounterCreationData[ i ]->CounterName = Console::ReadLine();
         }
         CounterCreationDataCollection^ myCounterCollection =
            gcnew CounterCreationDataCollection;
         // Add the 'CounterCreationData[]' to 'CounterCollection'.
         myCounterCollection->AddRange( myCounterCreationData );

         PerformanceCounterCategory::Create( myCategoryName,
            "Sample Category", myCounterCollection );

         for ( int i = 0; i < numberOfCounters; i++ )
         {
            myCounter = gcnew PerformanceCounter( myCategoryName,
               myCounterCreationData[ i ]->CounterName, "", false );
         }
         if ( myCounterCreationData->Length > 0 )
         {
            if ( myCounterCollection->Contains( myCounterCreationData[ 0 ] ) )
            {
               myCounterCollection->Remove( myCounterCreationData[ 0 ] );
               Console::WriteLine( "'{0}' counter is removed from the" +
                 " CounterCreationDataCollection", myCounterCreationData[ 0 ]->CounterName );
            }
         }
         else
         {
            Console::WriteLine( "The counters does not exist" );
         }
      }
      else
      {
         Console::WriteLine( "The category already exists" );
      }
// </Snippet2>
// </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}.", e->Message );
      return;
   }
}
