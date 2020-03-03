
// The following code example implements the ReadOnlyCollectionBase class.
// <Snippet1>
using namespace System;
using namespace System::Collections;
public ref class ROCollection: public ReadOnlyCollectionBase
{
public:
   ROCollection( IList^ sourceList )
   {
      InnerList->AddRange( sourceList );
   }

   property Object^ Item [int]
   {
      Object^ get( int index )
      {
         return (InnerList[ index ]);
      }

   }
   int IndexOf( Object^ value )
   {
      return (InnerList->IndexOf( value ));
   }

   bool Contains( Object^ value )
   {
      return (InnerList->Contains( value ));
   }

};

void PrintIndexAndValues( ROCollection^ myCol );
void PrintValues2( ROCollection^ myCol );
int main()
{
   // Create an ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "red" );
   myAL->Add( "blue" );
   myAL->Add( "yellow" );
   myAL->Add( "green" );
   myAL->Add( "orange" );
   myAL->Add( "purple" );

   // Create a new ROCollection that contains the elements in myAL.
   ROCollection^ myCol = gcnew ROCollection( myAL );

   // Display the contents of the collection using the enumerator.
   Console::WriteLine( "Contents of the collection (using enumerator):" );
   PrintValues2( myCol );

   // Display the contents of the collection using the Count property and the Item property.
   Console::WriteLine( "Contents of the collection (using Count and Item):" );
   PrintIndexAndValues( myCol );

   // Search the collection with Contains and IndexOf.
   Console::WriteLine( "Contains yellow: {0}", myCol->Contains( "yellow" ) );
   Console::WriteLine( "orange is at index {0}.", myCol->IndexOf( "orange" ) );
   Console::WriteLine();
}


// Uses the Count property and the Item property.
void PrintIndexAndValues( ROCollection^ myCol )
{
   for ( int i = 0; i < myCol->Count; i++ )
      Console::WriteLine( "   [{0}]:   {1}", i, myCol->Item[ i ] );
   Console::WriteLine();
}


// Uses the enumerator. 
void PrintValues2( ROCollection^ myCol )
{
   System::Collections::IEnumerator^ myEnumerator = myCol->GetEnumerator();
   while ( myEnumerator->MoveNext() )
      Console::WriteLine( "   {0}", myEnumerator->Current );

   Console::WriteLine();
}

/* 
This code produces the following output.

Contents of the collection (using enumerator):
   red
   blue
   yellow
   green
   orange
   purple

Contents of the collection (using Count and Item):
   [0]:   red
   [1]:   blue
   [2]:   yellow
   [3]:   green
   [4]:   orange
   [5]:   purple

Contains yellow: True
orange is at index 4.

*/
// </Snippet1>
