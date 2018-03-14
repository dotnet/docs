
// The following example shows how to copy the elements of an ArrayList to a string array.
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintIndexAndValues( ArrayList^ myList );
void PrintIndexAndValues( array<String^>^myArr );
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

   // Displays the values of the ArrayList.
   Console::WriteLine( "The ArrayList contains the following values:" );
   PrintIndexAndValues( myAL );

   // Copies the elements of the ArrayList to a string array.
   array<String^>^myArr = reinterpret_cast<array<String^>^>(myAL->ToArray( String::typeid ));

   // Displays the contents of the string array.
   Console::WriteLine( "The string array contains the following values:" );
   PrintIndexAndValues( myArr );
}

void PrintIndexAndValues( ArrayList^ myList )
{
   int i = 0;
   IEnumerator^ myEnum = myList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ o = safe_cast<Object^>(myEnum->Current);
      Console::WriteLine( "\t[{0}]:\t{1}", i++, o );
   }

   Console::WriteLine();
}

void PrintIndexAndValues( array<String^>^myArr )
{
   for ( int i = 0; i < myArr->Length; i++ )
      Console::WriteLine( "\t[{0}]:\t{1}", i, myArr[ i ] );
   Console::WriteLine();
}

/* 
This code produces the following output.

The ArrayList contains the following values:
        [0]:    The
        [1]:    quick
        [2]:    brown
        [3]:    fox
        [4]:    jumped
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog

The string array contains the following values:
        [0]:    The
        [1]:    quick
        [2]:    brown
        [3]:    fox
        [4]:    jumped
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog

*/
// </Snippet1>
