

// The following code example implements the CollectionBase class and uses that implementation to create a collection of Int16 objects.
// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;

public ref class Int16Collection: public CollectionBase
{
public:

   property Int16 Item [int]
   {
      Int16 get( int index )
      {
         return ( (Int16)(List[ index ]));
      }

      void set( int index, Int16 value )
      {
         List[ index ] = value;
      }
   }
   int Add( Int16 value )
   {
      return (List->Add( value ));
   }

   int IndexOf( Int16 value )
   {
      return (List->IndexOf( value ));
   }

   void Insert( int index, Int16 value )
   {
      List->Insert( index, value );
   }

   void Remove( Int16 value )
   {
      List->Remove( value );
   }

   bool Contains( Int16 value )
   {
      // If value is not of type Int16, this will return false.
      return (List->Contains( value ));
   }

protected:
   virtual void OnInsert( int /*index*/, Object^ /*value*/ ) override
   {
      // Insert additional code to be run only when inserting values.
   }

   virtual void OnRemove( int /*index*/, Object^ /*value*/ ) override
   {
      // Insert additional code to be run only when removing values.
   }

   virtual void OnSet( int /*index*/, Object^ /*oldValue*/, Object^ /*newValue*/ ) override
   {
      // Insert additional code to be run only when setting values.
   }

   virtual void OnValidate( Object^ value ) override
   {
      if ( value->GetType() != Type::GetType( "System.Int16" ) )
            throw gcnew ArgumentException( "value must be of type Int16.","value" );
   }

};

void PrintIndexAndValues( Int16Collection^ myCol );
void PrintValues2( Int16Collection^ myCol );
int main()
{
   // Create and initialize a new CollectionBase.
   Int16Collection^ myI16 = gcnew Int16Collection;
   
   // Add elements to the collection.
   myI16->Add( (Int16)1 );
   myI16->Add( (Int16)2 );
   myI16->Add( (Int16)3 );
   myI16->Add( (Int16)5 );
   myI16->Add( (Int16)7 );

   // Display the contents of the collection using the enumerator.
   Console::WriteLine( "Contents of the collection (using enumerator):" );
   PrintValues2( myI16 );

   // Display the contents of the collection using the Count property and the Item property.
   Console::WriteLine( "Initial contents of the collection (using Count and Item):" );
   PrintIndexAndValues( myI16 );

   // Search the collection with Contains and IndexOf.
   Console::WriteLine( "Contains 3: {0}", myI16->Contains( 3 ) );
   Console::WriteLine( "2 is at index {0}.", myI16->IndexOf( 2 ) );
   Console::WriteLine();

   // Insert an element into the collection at index 3.
   myI16->Insert( 3, (Int16)13 );
   Console::WriteLine( "Contents of the collection after inserting at index 3:" );
   PrintIndexAndValues( myI16 );

   // Get and set an element using the index.
   myI16->Item[ 4 ] = 123;
   Console::WriteLine( "Contents of the collection after setting the element at index 4 to 123:" );
   PrintIndexAndValues( myI16 );

   // Remove an element from the collection.
   myI16->Remove( (Int16)2 );

   // Display the contents of the collection using the Count property and the Item property.
   Console::WriteLine( "Contents of the collection after removing the element 2:" );
   PrintIndexAndValues( myI16 );
}

// Uses the Count property and the Item property.
void PrintIndexAndValues( Int16Collection^ myCol )
{
   for ( int i = 0; i < myCol->Count; i++ )
      Console::WriteLine( "   [{0}]:   {1}", i, myCol->Item[ i ] );
   Console::WriteLine();
}

// Uses the enumerator. 
void PrintValues2( Int16Collection^ myCol )
{
   System::Collections::IEnumerator^ myEnumerator = myCol->GetEnumerator();
   while ( myEnumerator->MoveNext() )
      Console::WriteLine( "   {0}", myEnumerator->Current );

   Console::WriteLine();
}

/* 
This code produces the following output.

Contents of the collection (using enumerator):
   1
   2
   3
   5
   7

Initial contents of the collection (using Count and Item):
   [0]:   1
   [1]:   2
   [2]:   3
   [3]:   5
   [4]:   7

Contains 3: True
2 is at index 1.

Contents of the collection after inserting at index 3:
   [0]:   1
   [1]:   2
   [2]:   3
   [3]:   13
   [4]:   5
   [5]:   7

Contents of the collection after setting the element at index 4 to 123:
   [0]:   1
   [1]:   2
   [2]:   3
   [3]:   13
   [4]:   123
   [5]:   7

Contents of the collection after removing the element 2:
   [0]:   1
   [1]:   3
   [2]:   13
   [3]:   123
   [4]:   7

*/
// </Snippet1>
