
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList );
int main()
{
   
   // Creates a new ArrayList with five elements and initialize each element with a null value.
   ArrayList^ myAL = ArrayList::Repeat( 0, 5 );
   
   // Displays the count, capacity and values of the ArrayList.
   Console::WriteLine( "ArrayList with five elements with a null value" );
   Console::WriteLine( "   Count    : {0}", myAL->Count );
   Console::WriteLine( "   Capacity : {0}", myAL->Capacity );
   Console::Write( "   Values:" );
   PrintValues( myAL );
   
   // Creates a new ArrayList with seven elements and initialize each element with the string "abc".
   myAL = ArrayList::Repeat( "abc", 7 );
   
   // Displays the count, capacity and values of the ArrayList.
   Console::WriteLine( "ArrayList with seven elements with a string value" );
   Console::WriteLine( "   Count    : {0}", myAL->Count );
   Console::WriteLine( "   Capacity : {0}", myAL->Capacity );
   Console::Write( "   Values:" );
   PrintValues( myAL );
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
 
 ArrayList with five elements with a null value
    Count    : 5
    Capacity : 16
    Values:
 ArrayList with seven elements with a string value
    Count    : 7
    Capacity : 16
    Values:   abc   abc   abc   abc   abc   abc   abc

 */
// </Snippet1>
