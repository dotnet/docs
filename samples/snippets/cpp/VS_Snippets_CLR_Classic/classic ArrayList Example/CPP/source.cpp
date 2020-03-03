
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList );
int main()
{
   
   // Creates and initializes a new ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "Hello" );
   myAL->Add( "World" );
   myAL->Add( "!" );
   
   // Displays the properties and values of the ArrayList.
   Console::WriteLine( "myAL" );
   Console::WriteLine( "    Count:    {0}", myAL->Count );
   Console::WriteLine( "    Capacity: {0}", myAL->Capacity );
   Console::Write( "    Values:" );
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
This code produces output similar to the following:

myAL
    Count:    3
    Capacity: 4
    Values:   Hello   World   !

*/
// </Snippet1>
