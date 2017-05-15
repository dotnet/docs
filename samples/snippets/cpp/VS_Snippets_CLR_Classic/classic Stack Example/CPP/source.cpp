
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myCollection );
int main()
{
   
   // Creates and initializes a new Stack.
   Stack^ myStack = gcnew Stack;
   myStack->Push( "Hello" );
   myStack->Push( "World" );
   myStack->Push( "!" );
   
   // Displays the properties and values of the Stack.
   Console::WriteLine( "myStack" );
   Console::WriteLine( "\tCount:    {0}", myStack->Count );
   Console::Write( "\tValues:" );
   PrintValues( myStack );
}

void PrintValues( IEnumerable^ myCollection )
{
   IEnumerator^ myEnum = myCollection->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::Write( "    {0}", obj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 myStack
     Count:    3
     Values:    !    World    Hello
 */
// </Snippet1>
