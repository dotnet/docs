// The following example shows how to implement and use the NameObjectCollectionBase class.

// <snippet1>
#using <System.dll>
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

public ref class MyCollection : public NameObjectCollectionBase  {

private:
   DictionaryEntry^ _de;

   // Creates an empty collection.
public:
   MyCollection()  {
      _de = gcnew DictionaryEntry();
   }

   // Adds elements from an IDictionary into the new collection.
   MyCollection( IDictionary^ d, Boolean bReadOnly )  {

      _de = gcnew DictionaryEntry();

      for each ( DictionaryEntry^ de in d )  {
         this->BaseAdd( (String^) de->Key, de->Value );
      }
      this->IsReadOnly = bReadOnly;
   }

   // Gets a key-and-value pair (DictionaryEntry) using an index.
   property DictionaryEntry^ default[ int ]  {
      DictionaryEntry^ get(int index)  {
         _de->Key = this->BaseGetKey(index);
         _de->Value = this->BaseGet(index);
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

   // Gets a String array that contains all the keys in the collection.
   property array<String^>^ AllKeys  {
      array<String^>^ get()  {
         return( (array<String^>^)this->BaseGetAllKeys() );
      }
   }

   // Gets an Object array that contains all the values in the collection.
   property Array^ AllValues  {
      Array^ get()  {
         return( this->BaseGetAllValues() );
      }
   }

   // Gets a String array that contains all the values in the collection.
   property array<String^>^ AllStringValues  {
      array<String^>^ get()  {
         return( (array<String^>^) this->BaseGetAllValues(  String ::typeid ));
      }
   }

   // Gets a value indicating if the collection contains keys that are not null.
   property Boolean HasKeys  {
      Boolean get()  {
         return( this->BaseHasKeys() );
      }
   }

   // Adds an entry to the collection.
   void Add( String^ key, Object^ value )  {
      this->BaseAdd( key, value );
   }

   // Removes an entry with the specified key from the collection.
   void Remove( String^ key )  {
      this->BaseRemove( key );
   }

   // Removes an entry in the specified index from the collection.
   void Remove( int index )  {
      this->BaseRemoveAt( index );
   }

   // Clears all the elements in the collection.
   void Clear()  {
      this->BaseClear();
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

      // Creates and initializes an empty MyCollection that is writable.
      MyCollection^ myRWCol = gcnew MyCollection();

      // Adds new items to the collection.
      myRWCol->Add( "purple", "grape" );
      myRWCol->Add( "orange", "tangerine" );
      myRWCol->Add( "black", "berries" );
      Console::WriteLine( "Writable Collection (after adding values):" );
      PrintKeysAndValues( myRWCol );

      // Changes the value of one element.
      myRWCol["orange"] = "grapefruit";
      Console::WriteLine( "Writable Collection (after changing one value):" );
      PrintKeysAndValues( myRWCol );

      // Removes one item from the collection.
      myRWCol->Remove( "black" );
      Console::WriteLine( "Writable Collection (after removing one value):" );
      PrintKeysAndValues( myRWCol );

      // Removes all elements from the collection.
      myRWCol->Clear();
      Console::WriteLine( "Writable Collection (after clearing the collection):" );
      PrintKeysAndValues( myRWCol );
   }

   // Prints the indexes, keys, and values.
   static void PrintKeysAndValues( MyCollection^ myCol )  {
      for ( int i = 0; i < myCol->Count; i++ )  {
         Console::WriteLine( "[{0}] : {1}, {2}", i, myCol[i]->Key, myCol[i]->Value );
      }
   }

   // Prints the keys and values using AllKeys.
   static void PrintKeysAndValues2( MyCollection^ myCol )  {
      for each ( String^ s in myCol->AllKeys )  {
         Console::WriteLine( "{0}, {1}", s, myCol[s] );
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
Writable Collection (after adding values):
[0] : purple, grape
[1] : orange, tangerine
[2] : black, berries
Writable Collection (after changing one value):
[0] : purple, grape
[1] : orange, grapefruit
[2] : black, berries
Writable Collection (after removing one value):
[0] : purple, grape
[1] : orange, grapefruit
Writable Collection (after clearing the collection):

*/
// </snippet1>
