

// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::Collections;
int main()
{
   
   // Creates and initializes a new SortedList.
   SortedList^ mySL = gcnew SortedList;
   mySL->Add( 2, "two" );
   mySL->Add( 3, "three" );
   mySL->Add( 1, "one" );
   mySL->Add( (int^)0, "zero" );
   mySL->Add( 4, "four" );
   
   // Creates a synchronized wrapper around the SortedList.
   SortedList^ mySyncdSL = SortedList::Synchronized( mySL );
   
   // Displays the sychronization status of both SortedLists.
   Console::WriteLine( "mySL is {0}.", mySL->IsSynchronized ? (String^)"synchronized" : "not synchronized" );
   Console::WriteLine( "mySyncdSL is {0}.", mySyncdSL->IsSynchronized ? (String^)"synchronized" : "not synchronized" );
}

/*
This code produces the following output.

mySL is not synchronized.
mySyncdSL is synchronized.
*/
// </Snippet1>
