
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList );
int main()
{
   
   // Creates and initializes a new ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "The" );
   myAL->Add( "QUICK" );
   myAL->Add( "BROWN" );
   myAL->Add( "FOX" );
   myAL->Add( "jumps" );
   myAL->Add( "over" );
   myAL->Add( "the" );
   myAL->Add( "lazy" );
   myAL->Add( "dog" );
   
   // Displays the values of the ArrayList.
   Console::WriteLine( "The ArrayList initially contains the following values:" );
   PrintValues( myAL );
   
   // Reverses the sort order of the values of the ArrayList.
   myAL->Reverse( 1, 3 );
   
   // Displays the values of the ArrayList.
   Console::WriteLine( "After reversing:" );
   PrintValues( myAL );
}

void PrintValues( IEnumerable^ myList )
{
   IEnumerator^ myEnum = myList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::WriteLine( "   {0}", obj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 The ArrayList initially contains the following values:
    The
    QUICK
    BROWN
    FOX
    jumps
    over
    the
    lazy
    dog

 After reversing:
    The
    FOX
    BROWN
    QUICK
    jumps
    over
    the
    lazy
    dog

 */
// </Snippet1>
