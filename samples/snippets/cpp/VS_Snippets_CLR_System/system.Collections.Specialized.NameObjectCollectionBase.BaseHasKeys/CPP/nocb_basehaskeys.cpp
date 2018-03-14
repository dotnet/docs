// The following example uses BaseHasKeys to determine if the collection contains keys that are not a null reference.
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

   // Creates an empty collection.
   MyCollection()  {
      _de = gcnew DictionaryEntry();
   }

   // Adds an entry to the collection.
   void Add( String^ key, Object^ value )  {
      this->BaseAdd( key, value );
   }

   // Gets a value indicating whether the collection contains keys that are not a null reference.
   property Boolean HasKeys  {
      Boolean get()  {
         return( this->BaseHasKeys() );
      }
   }
};

void PrintKeysAndValues( MyCollection^ myCol )  {
   for ( int i = 0; i < myCol->Count; i++ )  {
      Console::WriteLine( "[{0}] : {1}, {2}", i, myCol[i]->Key, myCol[i]->Value );
   }
}

int main()  {

   // Creates an empty MyCollection instance.
   MyCollection^ myCol = gcnew MyCollection();
   Console::WriteLine( "Initial state of the collection (Count = {0}):", myCol->Count );
   PrintKeysAndValues( myCol );
   Console::WriteLine( "HasKeys? {0}", myCol->HasKeys );

   Console::WriteLine();

   // Adds an item to the collection.
   myCol->Add( "blue", "sky" );
   Console::WriteLine( "Initial state of the collection (Count = {0}):", myCol->Count );
   PrintKeysAndValues( myCol );
   Console::WriteLine( "HasKeys? {0}", myCol->HasKeys );

}

/*
This code produces the following output.

Initial state of the collection (Count = 0):
HasKeys? False

Initial state of the collection (Count = 1):
[0] : blue, sky
HasKeys? True

*/
// </snippet1>
