

// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::Collections;
int main()
{
   
   // Creates and initializes a new Stack.
   Stack^ myStack = gcnew Stack;
   myStack->Push( "The" );
   myStack->Push( "quick" );
   myStack->Push( "brown" );
   myStack->Push( "fox" );
   
   // Creates a synchronized wrapper around the Stack.
   Stack^ mySyncdStack = Stack::Synchronized( myStack );
   
   // Displays the sychronization status of both Stacks.
   Console::WriteLine( "myStack is {0}.", myStack->IsSynchronized ? (String^)"synchronized" : "not synchronized" );
   Console::WriteLine( "mySyncdStack is {0}.", mySyncdStack->IsSynchronized ? (String^)"synchronized" : "not synchronized" );
}

/*
This code produces the following output.

myStack is not synchronized.
mySyncdStack is synchronized.
*/
// </Snippet1>
