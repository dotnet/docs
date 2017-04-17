
// The following example uses BaseGetKey and BaseGet to get specific keys and values.
// For an expanded version of this example, see the NameObjectCollectionBase class topic.

// <snippet1>
#using <System.dll>
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

public ref class MyCollection : public NameObjectCollectionBase  {

private:
   DictionaryEntry^ _de;

   // Gets a key-and-value pair (DictionaryEntry) using an index.
public:
   property DictionaryEntry^ default[ int ]  {
      DictionaryEntry^ get( int index )  {
         _de->Key = this->BaseGetKey( index );
         _de->Value = this->BaseGet( index );
         return( _de );
      }
   }

   // Gets or sets the value associated with the specified key.
   property Object^ default[ String^ ]  {
      Object^ get(String^ key)  {
         return( this->BaseGet( key ) );
      }
      void set( String^ key, Object^ value )  {
         this->BaseSet( key, value );
      }
   }

   // Adds elements from an IDictionary into the new collection.
   MyCollection( IDictionary^ d )  {

      _de = gcnew DictionaryEntry();

      for each ( DictionaryEntry^ de in d )  {
         this->BaseAdd( (String^) de->Key, de->Value );
      }
   }
};

public ref class SamplesNameObjectCollectionBase  {

public:
   static void Main()  {

      // Creates and initializes a new MyCollection instance.
      IDictionary^ d = gcnew ListDictionary();
      d->Add( "red", "apple" );
      d->Add( "yellow", "banana" );
      d->Add( "green", "pear" );
      MyCollection^ myCol = gcnew MyCollection( d );
      Console::WriteLine( "Initial state of the collection (Count = {0}):", myCol->Count );
      PrintKeysAndValues( myCol );

      // Gets specific keys and values.
      Console::WriteLine( "The key at index 0 is {0}.", myCol[0]->Key );
      Console::WriteLine( "The value at index 0 is {0}.", myCol[0]->Value );
      Console::WriteLine( "The value associated with the key \"green\" is {0}.", myCol["green"] );

   }

   static void PrintKeysAndValues( MyCollection^ myCol )  {
      for ( int i = 0; i < myCol->Count; i++ )  {
         Console::WriteLine( "[{0}] : {1}, {2}", i, myCol[i]->Key, myCol[i]->Value );
      }
   }
};

int main()
{
    SamplesNameObjectCollectionBase::Main();
}

/*
This code produces the following output.

Initial state of the collection (Count = 3):
[0] : red, apple
[1] : yellow, banana
[2] : green, pear
The key at index 0 is red.
The value at index 0 is apple.
The value associated with the key "green" is pear.

*/
// </snippet1>
