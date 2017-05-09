// The following example creates a read-only collection.
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

   // Adds elements from an IDictionary into the new collection.
   MyCollection( IDictionary^ d, Boolean bReadOnly )  {

      _de = gcnew DictionaryEntry();

      for each ( DictionaryEntry^ de in d )  {
         this->BaseAdd( (String^) de->Key, de->Value );
      }
      this->IsReadOnly = bReadOnly;
   }

   // Adds an entry to the collection.
   void Add( String^ key, Object^ value )  {
      this->BaseAdd( key, value );
   }
};

public ref class SamplesNameObjectCollectionBase  {

public:
   static void Main()  {

      // Creates and initializes a new MyCollection that is read-only.
      IDictionary^ d = gcnew ListDictionary();
      d->Add( "red", "apple" );
      d->Add( "yellow", "banana" );
      d->Add( "green", "pear" );
      MyCollection^ myROCol = gcnew MyCollection( d, true );

      // Tries to add a new item.
      try  {
         myROCol->Add( "blue", "sky" );
      }
      catch ( NotSupportedException^ e )  {
         Console::WriteLine( e->ToString() );
      }

      // Displays the keys and values of the MyCollection.
      Console::WriteLine( "Read-Only Collection:" );
      PrintKeysAndValues( myROCol );
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

System.NotSupportedException: Collection is read-only.
   at System.Collections.Specialized.NameObjectCollectionBase.BaseAdd(String name, Object value)
   at SamplesNameObjectCollectionBase.Main()
Read-Only Collection:
[0] : red, apple
[1] : yellow, banana
[2] : green, pear

*/
// </snippet1>
