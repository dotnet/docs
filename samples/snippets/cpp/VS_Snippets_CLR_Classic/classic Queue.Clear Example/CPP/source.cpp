
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( Queue^ myQ );
int main()
{
   
   // Creates and initializes a new Queue.
   Queue^ myQ = gcnew Queue;
   myQ->Enqueue( "The" );
   myQ->Enqueue( "quick" );
   myQ->Enqueue( "brown" );
   myQ->Enqueue( "fox" );
   myQ->Enqueue( "jumped" );
   
   // Displays the count and values of the Queue.
   Console::WriteLine( "Initially," );
   Console::WriteLine( "   Count    : {0}", myQ->Count );
   Console::Write( "   Values:" );
   PrintValues( myQ );
   
   // Clears the Queue.
   myQ->Clear();
   
   // Displays the count and values of the Queue.
   Console::WriteLine( "After Clear," );
   Console::WriteLine( "   Count    : {0}", myQ->Count );
   Console::Write( "   Values:" );
   PrintValues( myQ );
}

void PrintValues( Queue^ myQ )
{
   IEnumerator^ myEnum = myQ->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ myObj = safe_cast<Object^>(myEnum->Current);
      Console::Write( "    {0}", myObj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 Initially,
    Count    : 5
    Values:    The    quick    brown    fox    jumped
 After Clear,
    Count    : 0
    Values:

 */
// </Snippet1>
