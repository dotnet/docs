

// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::Collections;
void PrintKeysAndValues( SortedList^ myList )
{
   Console::WriteLine(  "\t-KEY-\t-VALUE-" );
   for ( int i = 0; i < myList->Count; i++ )
   {
      Console::WriteLine(  "\t{0}:\t{1}", myList->GetKey( i ), myList->GetByIndex( i ) );

   }
   Console::WriteLine();
}

int main()
{
   
   // Creates and initializes a new SortedList.
   SortedList^ mySL = gcnew SortedList;
   mySL->Add( "one", "The" );
   mySL->Add( "two", "quick" );
   mySL->Add( "three", "brown" );
   mySL->Add( "four", "fox" );
   
   // Displays the SortedList.
   Console::WriteLine(  "The SortedList contains the following:" );
   PrintKeysAndValues( mySL );
}

/* 
This code produces the following output.

The SortedList contains the following:
        -KEY-   -VALUE-
        four:   fox
        one:    The
        three:  brown
        two:    quick
*/
// </Snippet1>
