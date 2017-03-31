// The following example uses BaseSet to set the value of a specific element.
// For an expanded version of this example, see the NameObjectCollectionBase class topic.

// <snippet1>
#using <System.dll>
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

public ref class MyCollection : public NameObjectCollectionBase  {

   // Gets or sets the value at the specified index.
public:
   property Object^ default[ int ]  {
      Object^ get(int index)  {
         return( this->BaseGet( index ) );
      }
      void set( int index, Object^ value )  {
         this->BaseSet( index, value );
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
         return( this->BaseGetAllKeys() );
      }
   }

   // Adds elements from an IDictionary into the new collection.
   MyCollection( IDictionary^ d )  {
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
      Console::WriteLine( "Initial state of the collection:" );
      PrintKeysAndValues2( myCol );
      Console::WriteLine();

      // Sets the value at index 1.
      myCol[1] = "sunflower";
      Console::WriteLine( "After setting the value at index 1:" );
      PrintKeysAndValues2( myCol );
      Console::WriteLine();

      // Sets the value associated with the key "red".
      myCol["red"] = "tulip";
      Console::WriteLine( "After setting the value associated with the key \"red\":" );
      PrintKeysAndValues2( myCol );

   }

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

Initial state of the collection:
red, apple
yellow, banana
green, pear

After setting the value at index 1:
red, apple
yellow, sunflower
green, pear

After setting the value associated with the key "red":
red, tulip
yellow, sunflower
green, pear

*/
// </snippet1>
