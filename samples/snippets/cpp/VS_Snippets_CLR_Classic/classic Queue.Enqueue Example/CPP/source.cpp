
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myCollection );
int main()
{
   
   // Creates and initializes a new Queue.
   Queue^ myQ = gcnew Queue;
   myQ->Enqueue( "The" );
   myQ->Enqueue( "quick" );
   myQ->Enqueue( "brown" );
   myQ->Enqueue( "fox" );
   
   // Displays the Queue.
   Console::Write( "Queue values:" );
   PrintValues( myQ );
   
   // Removes an element from the Queue.
   Console::WriteLine( "(Dequeue)\t{0}", myQ->Dequeue() );
   
   // Displays the Queue.
   Console::Write( "Queue values:" );
   PrintValues( myQ );
   
   // Removes another element from the Queue.
   Console::WriteLine( "(Dequeue)\t{0}", myQ->Dequeue() );
   
   // Displays the Queue.
   Console::Write( "Queue values:" );
   PrintValues( myQ );
   
   // Views the first element in the Queue but does not remove it.
   Console::WriteLine( "(Peek)   \t{0}", myQ->Peek() );
   
   // Displays the Queue.
   Console::Write( "Queue values:" );
   PrintValues( myQ );
}

void PrintValues( IEnumerable^ myCollection )
{
   IEnumerator^ myEnum = myCollection->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::Write( "    {0}", obj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 Queue values:    The    quick    brown    fox
 (Dequeue)       The
 Queue values:    quick    brown    fox
 (Dequeue)       quick
 Queue values:    brown    fox
 (Peek)          brown
 Queue values:    brown    fox

 */
// </Snippet1>
