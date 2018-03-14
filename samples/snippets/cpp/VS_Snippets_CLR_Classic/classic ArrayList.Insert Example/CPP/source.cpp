// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList );
int main()
{
   
   // Creates and initializes a new ArrayList using Insert instead of Add.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Insert( 0, "The" );
   myAL->Insert( 1, "fox" );
   myAL->Insert( 2, "jumps" );
   myAL->Insert( 3, "over" );
   myAL->Insert( 4, "the" );
   myAL->Insert( 5, "dog" );
   
   // Creates and initializes a new Queue.
   Queue^ myQueue = gcnew Queue;
   myQueue->Enqueue( "quick" );
   myQueue->Enqueue( "brown" );
   
   // Displays the ArrayList and the Queue.
   Console::WriteLine( "The ArrayList initially contains the following:" );
   PrintValues( myAL );
   Console::WriteLine( "The Queue initially contains the following:" );
   PrintValues( myQueue );
   
   // Copies the Queue elements to the ArrayList at index 1.
   myAL->InsertRange( 1, myQueue );
   
   // Displays the ArrayList.
   Console::WriteLine( "After adding the Queue, the ArrayList now contains:" );
   PrintValues( myAL );
   
   // Search for "dog" and add "lazy" before it.
   myAL->Insert( myAL->IndexOf( "dog" ), "lazy" );
   
   // Displays the ArrayList.
   Console::WriteLine( "After adding \"lazy\", the ArrayList now contains:" );
   PrintValues( myAL );
   
   // Add "!!!" at the end.
   myAL->Insert( myAL->Count, "!!!" );
   
   // Displays the ArrayList.
   Console::WriteLine( "After adding \"!!!\", the ArrayList now contains:" );
   PrintValues( myAL );
   
   // Inserting an element beyond Count throws an exception.
   try
   {
      myAL->Insert( myAL->Count + 1, "anystring" );
   }
   catch ( Exception^ myException ) 
   {
      Console::WriteLine( "Exception: {0}", myException );
   }

}

void PrintValues( IEnumerable^ myList )
{
   IEnumerator^ myEnum = myList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::Write( "   {0}", obj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 The ArrayList initially contains the following:
    The   fox   jumps   over   the   dog
 The Queue initially contains the following:
    quick   brown
 After adding the Queue, the ArrayList now contains:
    The   quick   brown   fox   jumps   over   the   dog
 After adding "lazy", the ArrayList now contains:
    The   quick   brown   fox   jumps   over   the   lazy   dog
 After adding "!!!", the ArrayList now contains:
    The   quick   brown   fox   jumps   over   the   lazy   dog   !!!
 Exception: System.ArgumentOutOfRangeException: Insertion index was out of range.  Must be non-negative and less than or equal to size.
 Parameter name: index
    at System.Collections.ArrayList.Insert(Int32 index, Object value)
    at SamplesArrayList.Main()
 */
// </Snippet1>
