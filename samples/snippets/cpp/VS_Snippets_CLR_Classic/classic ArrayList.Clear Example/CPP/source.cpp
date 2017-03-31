// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList );
int main()
{
   
   // Creates and initializes a new ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "The" );
   myAL->Add( "quick" );
   myAL->Add( "brown" );
   myAL->Add( "fox" );
   myAL->Add( "jumped" );
   
   // Displays the count, capacity and values of the ArrayList.
   Console::WriteLine( "Initially," );
   Console::WriteLine( "   Count    : {0}", myAL->Count );
   Console::WriteLine( "   Capacity : {0}", myAL->Capacity );
   Console::Write( "   Values:" );
   PrintValues( myAL );
   
   // Trim the ArrayList.
   myAL->TrimToSize();
   
   // Displays the count, capacity and values of the ArrayList.
   Console::WriteLine( "After TrimToSize," );
   Console::WriteLine( "   Count    : {0}", myAL->Count );
   Console::WriteLine( "   Capacity : {0}", myAL->Capacity );
   Console::Write( "   Values:" );
   PrintValues( myAL );
   
   // Clear the ArrayList.
   myAL->Clear();
   
   // Displays the count, capacity and values of the ArrayList.
   Console::WriteLine( "After Clear," );
   Console::WriteLine( "   Count    : {0}", myAL->Count );
   Console::WriteLine( "   Capacity : {0}", myAL->Capacity );
   Console::Write( "   Values:" );
   PrintValues( myAL );
   
   // Trim the ArrayList again.
   myAL->TrimToSize();
   
   // Displays the count, capacity and values of the ArrayList.
   Console::WriteLine( "After the second TrimToSize," );
   Console::WriteLine( "   Count    : {0}", myAL->Count );
   Console::WriteLine( "   Capacity : {0}", myAL->Capacity );
   Console::Write( "   Values:" );
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
 This code produces the following output.
 
 Initially,
    Count    : 5
    Capacity : 16
    Values:    The    quick    brown    fox    jumped
 After TrimToSize,
    Count    : 5
    Capacity : 5
    Values:    The    quick    brown    fox    jumped
 After Clear,
    Count    : 0
    Capacity : 5
    Values:
 After the second TrimToSize,
    Count    : 0
    Capacity : 16
    Values:
 */
// </Snippet1>
