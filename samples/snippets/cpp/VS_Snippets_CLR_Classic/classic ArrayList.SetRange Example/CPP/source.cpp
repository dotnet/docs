
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList, char mySeparator );
int main()
{
   
   // Creates and initializes a new ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "The" );
   myAL->Add( "quick" );
   myAL->Add( "brown" );
   myAL->Add( "fox" );
   myAL->Add( "jumped" );
   myAL->Add( "over" );
   myAL->Add( "the" );
   myAL->Add( "lazy" );
   myAL->Add( "dog" );
   
   // Creates and initializes the source ICollection.
   Queue^ mySourceList = gcnew Queue;
   mySourceList->Enqueue( "big" );
   mySourceList->Enqueue( "gray" );
   mySourceList->Enqueue( "wolf" );
   
   // Displays the values of five elements starting at index 0.
   ArrayList^ mySubAL = myAL->GetRange( 0, 5 );
   Console::WriteLine( "Index 0 through 4 contains:" );
   PrintValues( mySubAL, '\t' );
   
   // Replaces the values of five elements starting at index 1 with the values in the ICollection.
   myAL->SetRange( 1, mySourceList );
   
   // Displays the values of five elements starting at index 0.
   mySubAL = myAL->GetRange( 0, 5 );
   Console::WriteLine( "Index 0 through 4 now contains:" );
   PrintValues( mySubAL, '\t' );
}

void PrintValues( IEnumerable^ myList, char mySeparator )
{
   IEnumerator^ myEnum = myList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::Write( "{0}{1}", mySeparator, obj );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 Index 0 through 4 contains:
         The     quick   brown   fox     jumped
 Index 0 through 4 now contains:
         The     big     gray    wolf    jumped
 */
// </Snippet1>
