
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList );
int main()
{
   
   // Creates and initializes a new ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "The" );
   myAL->Add( "quick" );
   myAL->Add( "brown" );
   myAL->Add( "fox" );
   myAL->Add( "jumped" );
   myAL->Add( "over" );
   myAL->Add( "the" );
   myAL->Add( "lazy" );
   myAL->Add( "dog" );
   
   // Displays the ArrayList.
   Console::WriteLine( "The ArrayList initially contains the following:" );
   PrintValues( myAL );
   
   // Removes the element containing "lazy".
   myAL->Remove( "lazy" );
   
   // Displays the current state of the ArrayList.
   Console::WriteLine( "After removing \"lazy\":" );
   PrintValues( myAL );
   
   // Removes the element at index 5.
   myAL->RemoveAt( 5 );
   
   // Displays the current state of the ArrayList.
   Console::WriteLine( "After removing the element at index 5:" );
   PrintValues( myAL );
   
   // Removes three elements starting at index 4.
   myAL->RemoveRange( 4, 3 );
   
   // Displays the current state of the ArrayList.
   Console::WriteLine( "After removing three elements starting at index 4:" );
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
 
 The ArrayList initially contains the following:
    The   quick   brown   fox   jumped   over   the   lazy   dog
 After removing "lazy":
    The   quick   brown   fox   jumped   over   the   dog
 After removing the element at index 5:
    The   quick   brown   fox   jumped   the   dog
 After removing three elements starting at index 4:
    The   quick   brown   fox
 */
// </Snippet1>
