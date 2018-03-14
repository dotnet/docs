

// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::Collections;
void main()
{
   
   // Creates and initializes a new Hashtable.
   Hashtable^ myHT = gcnew Hashtable;
   myHT->Add( (int^)0, "zero" );
   myHT->Add( 1, "one" );
   myHT->Add( 2, "two" );
   myHT->Add( 3, "three" );
   myHT->Add( 4, "four" );
   
   // Creates a synchronized wrapper around the Hashtable.
   Hashtable^ mySyncdHT = Hashtable::Synchronized( myHT );
   
   // Displays the sychronization status of both Hashtables.
   Console::WriteLine( "myHT is {0}.", myHT->IsSynchronized ? (String^)"synchronized" : "not synchronized" );
   Console::WriteLine( "mySyncdHT is {0}.", mySyncdHT->IsSynchronized ? (String^)"synchronized" : "not synchronized" );
}

/*
 This code produces the following output.

 myHT is not synchronized.
 mySyncdHT is synchronized.
 */
// </Snippet1>
