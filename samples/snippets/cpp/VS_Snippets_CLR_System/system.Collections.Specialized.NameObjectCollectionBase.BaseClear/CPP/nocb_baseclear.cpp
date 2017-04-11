

// The following example uses BaseClear to remove all elements from a NameObjectCollectionBase.
// For an expanded version of this example, see the NameObjectCollectionBase class topic.
// <snippet1>
#using <system.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
public ref class MyCollection: public NameObjectCollectionBase
{
private:
   DictionaryEntry _de;

public:

   property DictionaryEntry Item [ int ]
   {
      // Gets a key-and-value pair (DictionaryEntry) using an index.
      DictionaryEntry get( int index )
      {
         _de.Key = this->BaseGetKey( index );
         _de.Value = this->BaseGet( index );
         return (_de);
      }
   }

   // Adds elements from an IDictionary* into the new collection.
   MyCollection( IDictionary^ d )
   {
      IEnumerator^ myEnum = d->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DictionaryEntry^ de = safe_cast<DictionaryEntry^>(myEnum->Current);
         this->BaseAdd( safe_cast<String^>(de->Key), de->Value );
      }
   }

   // Clears all the elements in the collection.
   void Clear()
   {
      this->BaseClear();
   }
};

static void PrintKeysAndValues( MyCollection^ myCol )
{
   for ( int i = 0; i < myCol->Count; i++ )
   {
      Console::WriteLine( "[{0}] : {1}, {2}", i, myCol->Item[ i ].Key, myCol->Item[ i ].Value );

   }
}

int main()
{
   // Creates and initializes a new MyCollection instance.
   IDictionary^ d = gcnew ListDictionary;
   d->Add( "red", "apple" );
   d->Add( "yellow", "banana" );
   d->Add( "green", "pear" );
   MyCollection^ myCol = gcnew MyCollection( d );
   Console::WriteLine( "Initial state of the collection (Count = {0}):", myCol->Count );
   PrintKeysAndValues( myCol );

   // Removes all elements from the collection.
   myCol->Clear();
   Console::WriteLine( "After clearing the collection (Count = {0}):", myCol->Count );
   PrintKeysAndValues( myCol );
}

/*
This code produces the following output.

Initial state of the collection (Count = 3):
[0] : red, apple
[1] : yellow, banana
[2] : green, pear
After clearing the collection (Count = 0):

*/
// </snippet1>
