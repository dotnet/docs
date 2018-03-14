
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myCollection );
int main()
{
   
   // Creates and initializes a new Queue.
   Queue^ myQ = gcnew Queue;
   myQ->Enqueue( "Hello" );
   myQ->Enqueue( "World" );
   myQ->Enqueue( "!" );
   
   // Displays the properties and values of the Queue.
   Console::WriteLine( "myQ" );
   Console::WriteLine( "\tCount:    {0}", myQ->Count );
   Console::Write( "\tValues:" );
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
 
 myQ
     Count:    3
     Values:    Hello    World    !
*/
// </Snippet1>
