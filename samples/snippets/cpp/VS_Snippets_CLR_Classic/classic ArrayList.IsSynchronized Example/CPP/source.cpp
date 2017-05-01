
// <Snippet1>
using namespace System;
using namespace System::Collections;
int main()
{
   
   // Creates and initializes a new ArrayList instance.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "The" );
   myAL->Add( "quick" );
   myAL->Add( "brown" );
   myAL->Add( "fox" );
   
   // Creates a synchronized wrapper around the ArrayList.
   ArrayList^ mySyncdAL = ArrayList::Synchronized( myAL );
   
   // Displays the sychronization status of both ArrayLists.
   String^ szRes = myAL->IsSynchronized ?  (String^)"synchronized" :  "not synchronized";
   Console::WriteLine(  "myAL is {0}.", szRes );
   String^ szSyncRes = mySyncdAL->IsSynchronized ?  (String^)"synchronized" :  "not synchronized";
   Console::WriteLine(  "mySyncdAL is {0}.", szSyncRes );
}

/* 
 This code produces the following output.
 
 myAL is not synchronized.
 mySyncdAL is synchronized.
 */
// </Snippet1>
