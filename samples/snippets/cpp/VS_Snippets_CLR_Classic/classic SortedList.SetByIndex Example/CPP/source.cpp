

// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::Collections;
void PrintIndexAndKeysAndValues( SortedList^ myList )
{
   Console::WriteLine( "\t-INDEX-\t-KEY-\t-VALUE-" );
   for ( int i = 0; i < myList->Count; i++ )
   {
      Console::WriteLine( "\t[{0}]:\t{1}\t{2}", i, myList->GetKey( i ), myList->GetByIndex( i ) );

   }
   Console::WriteLine();
}

int main()
{
   
   // Creates and initializes a new SortedList.
   SortedList^ mySL = gcnew SortedList;
   mySL->Add( 2, "two" );
   mySL->Add( 3, "three" );
   mySL->Add( 1, "one" );
   mySL->Add( 0, "zero" );
   mySL->Add( 4, "four" );
   
   // Displays the values of the SortedList.
   Console::WriteLine( "The SortedList contains the following values:" );
   PrintIndexAndKeysAndValues( mySL );
   
   // Replaces the values at index 3 and index 4.
   mySL->SetByIndex( 3, "III" );
   mySL->SetByIndex( 4, "IV" );
   
   // Displays the updated values of the SortedList.
   Console::WriteLine( "After replacing the value at index 3 and index 4," );
   PrintIndexAndKeysAndValues( mySL );
}

/*
This code produces the following output.

The SortedList contains the following values:
        -INDEX- -KEY-   -VALUE-
        [0]:    0       zero
        [1]:    1       one
        [2]:    2       two
        [3]:    3       three
        [4]:    4       four

After replacing the value at index 3 and index 4,
        -INDEX- -KEY-   -VALUE-
        [0]:    0       zero
        [1]:    1       one
        [2]:    2       two
        [3]:    3       III
        [4]:    4       IV
*/
// </Snippet1>
