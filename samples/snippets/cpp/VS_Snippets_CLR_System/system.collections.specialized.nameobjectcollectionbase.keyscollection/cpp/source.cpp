#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
using namespace System::Threading;

public ref class DerivedCollection : public NameObjectCollectionBase  {

private:
   DictionaryEntry^ _de;

   // Creates an empty collection.
public:
   DerivedCollection()  {
      _de = gcnew DictionaryEntry();
   }

   // Adds elements from an IDictionary into the new collection.
   DerivedCollection( IDictionary^ d, Boolean bReadOnly )  {

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

public ref class SamplesNameObjectCollectionBaseKeys
{
public:
    static void Main()
    {
        // <Snippet1>
        // Create a collection derived from NameObjectCollectionBase
        NameObjectCollectionBase^ myBaseCollection = gcnew DerivedCollection();
        // Get the ICollection from NameObjectCollectionBase.KeysCollection
        ICollection^ myKeysCollection = myBaseCollection->Keys;
        bool lockTaken = false;
        try
        {
            Monitor::Enter(myKeysCollection->SyncRoot, lockTaken);
            for each (Object^ item in myKeysCollection)
            {
                // Insert your code here.
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor::Exit(myKeysCollection->SyncRoot);
            }
        }
        // </Snippet1>
    }
};

int main()
{
    SamplesNameObjectCollectionBaseKeys::Main();
}
