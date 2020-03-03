

// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::Collections;
public ref class SamplesSortedList
{
public:
   static void PrintKeysAndValues( SortedList^ myList )
   {
      Console::WriteLine( "\t-KEY-\t-VALUE-" );
      for ( int i = 0; i < myList->Count; i++ )
      {
         Console::WriteLine( "\t{0}:\t{1}", myList->GetKey( i ), myList->GetByIndex( i ) );

      }
      Console::WriteLine();
   }

};

int main()
{

   // Creates and initializes a new SortedList.
   SortedList^ mySL = gcnew SortedList;
   mySL->Add( "Third", "!" );
   mySL->Add( "Second", "World" );
   mySL->Add( "First", "Hello" );

   // Displays the properties and values of the SortedList.
   Console::WriteLine( "mySL" );
   Console::WriteLine( "  Count:    {0}", mySL->Count );
   Console::WriteLine( "  Capacity: {0}", mySL->Capacity );
   Console::WriteLine( "  Keys and Values:" );
   SamplesSortedList::PrintKeysAndValues( mySL );
}

/*
This code produces the following output.

mySL
Count:    3
Capacity: 16
Keys and Values:
-KEY-    -VALUE-
First:    Hello
Second:    World
Third:    !
*/
// </Snippet1>
