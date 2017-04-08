// The following example uses BaseRemove and BaseRemoveAt to remove elements from a NameObjectCollectionBase.
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
      DictionaryEntry^ get(int index)  {
         _de->Key = this->BaseGetKey( index );
         _de->Value = this->BaseGet( index );
         return( _de );
      }
   }

   // Adds elements from an IDictionary into the new collection.
   MyCollection( IDictionary^ d )  {

      _de = gcnew DictionaryEntry();

      for each ( DictionaryEntry^ de in d )  {
         this->BaseAdd( (String^) de->Key, de->Value );
      }
   }

   // Removes an entry with the specified key from the collection.
   void Remove( String^ key )  {
      this->BaseRemove( key );
   }

   // Removes an entry in the specified index from the collection.
   void Remove( int index )  {
      this->BaseRemoveAt( index );
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

      // Removes an element at a specific index.
      myCol->Remove( 1 );
      Console::WriteLine( "After removing the element at index 1 (Count = {0}):", myCol->Count );
      PrintKeysAndValues( myCol );

      // Removes an element with a specific key.
      myCol->Remove( "red" );
      Console::WriteLine( "After removing the element with the key \"red\" (Count = {0}):", myCol->Count );
      PrintKeysAndValues( myCol );

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
After removing the element at index 1 (Count = 2):
[0] : red, apple
[1] : green, pear
After removing the element with the key "red" (Count = 1):
[0] : green, pear

*/
// </snippet1>
