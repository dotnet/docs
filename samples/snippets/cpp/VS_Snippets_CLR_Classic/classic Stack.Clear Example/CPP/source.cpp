
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myCollection );
int main()
{
   
   // Creates and initializes a new Stack.
   Stack^ myStack = gcnew Stack;
   myStack->Push( "The" );
   myStack->Push( "quick" );
   myStack->Push( "brown" );
   myStack->Push( "fox" );
   myStack->Push( "jumped" );
   
   // Displays the count and values of the Stack.
   Console::WriteLine( "Initially," );
   Console::WriteLine( "   Count    : {0}", myStack->Count );
   Console::Write( "   Values:" );
   PrintValues( myStack );
   
   // Clears the Stack.
   myStack->Clear();
   
   // Displays the count and values of the Stack.
   Console::WriteLine( "After Clear," );
   Console::WriteLine( "   Count    : {0}", myStack->Count );
   Console::Write( "   Values:" );
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
 
 Initially,
    Count    : 5
    Values:    jumped    fox    brown    quick    The
 After Clear,
    Count    : 0
    Values:
 */
// </Snippet1>
