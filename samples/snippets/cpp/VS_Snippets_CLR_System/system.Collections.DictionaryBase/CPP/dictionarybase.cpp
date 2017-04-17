
// The following code example implements the DictionaryBase class and uses that implementation to create a dictionary of String keys and values that have a Length of 5 or less.
// <Snippet1>
using namespace System;
using namespace System::Collections;

public ref class ShortStringDictionary: public DictionaryBase
{
public:

   property String^ Item [String^]
   {
      String^ get( String^ key )
      {
         return (dynamic_cast<String^>(Dictionary[ key ]));
      }

      void set( String^ value, String^ key )
      {
         Dictionary[ key ] = value;
      }
   }

   property ICollection^ Keys 
   {
      ICollection^ get()
      {
         return (Dictionary->Keys);
      }
   }

   property ICollection^ Values 
   {
      ICollection^ get()
      {
         return (Dictionary->Values);
      }
   }
   void Add( String^ key, String^ value )
   {
      Dictionary->Add( key, value );
   }

   bool Contains( String^ key )
   {
      return (Dictionary->Contains( key ));
   }

   void Remove( String^ key )
   {
      Dictionary->Remove( key );
   }


protected:
   virtual void OnInsert( Object^ key, Object^ value ) override
   {
      if ( key->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "key must be of type String.","key" );
      else
      {
         String^ strKey = dynamic_cast<String^>(key);
         if ( strKey->Length > 5 )
                  throw gcnew ArgumentException( "key must be no more than 5 characters in length.","key" );
      }

      if ( value->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "value must be of type String.","value" );
      else
      {
         String^ strValue = dynamic_cast<String^>(value);
         if ( strValue->Length > 5 )
                  throw gcnew ArgumentException( "value must be no more than 5 characters in length.","value" );
      }
   }

   virtual void OnRemove( Object^ key, Object^ /*value*/ ) override
   {
      if ( key->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "key must be of type String.","key" );
      else
      {
         String^ strKey = dynamic_cast<String^>(key);
         if ( strKey->Length > 5 )
                  throw gcnew ArgumentException( "key must be no more than 5 characters in length.","key" );
      }
   }

   virtual void OnSet( Object^ key, Object^ /*oldValue*/, Object^ newValue ) override
   {
      if ( key->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "key must be of type String.","key" );
      else
      {
         String^ strKey = dynamic_cast<String^>(key);
         if ( strKey->Length > 5 )
                  throw gcnew ArgumentException( "key must be no more than 5 characters in length.","key" );
      }

      if ( newValue->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "newValue must be of type String.","newValue" );
      else
      {
         String^ strValue = dynamic_cast<String^>(newValue);
         if ( strValue->Length > 5 )
                  throw gcnew ArgumentException( "newValue must be no more than 5 characters in length.","newValue" );
      }
   }

   virtual void OnValidate( Object^ key, Object^ value ) override
   {
      if ( key->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "key must be of type String.","key" );
      else
      {
         String^ strKey = dynamic_cast<String^>(key);
         if ( strKey->Length > 5 )
                  throw gcnew ArgumentException( "key must be no more than 5 characters in length.","key" );
      }

      if ( value->GetType() != Type::GetType( "System.String" ) )
            throw gcnew ArgumentException( "value must be of type String.","value" );
      else
      {
         String^ strValue = dynamic_cast<String^>(value);
         if ( strValue->Length > 5 )
                  throw gcnew ArgumentException( "value must be no more than 5 characters in length.","value" );
      }
   }

};

void PrintKeysAndValues2( ShortStringDictionary^ myCol );
void PrintKeysAndValues3( ShortStringDictionary^ myCol );
int main()
{
   // Creates and initializes a new DictionaryBase.
   ShortStringDictionary^ mySSC = gcnew ShortStringDictionary;

   // Adds elements to the collection.
   mySSC->Add( "One", "a" );
   mySSC->Add( "Two", "ab" );
   mySSC->Add( "Three", "abc" );
   mySSC->Add( "Four", "abcd" );
   mySSC->Add( "Five", "abcde" );

   // Display the contents of the collection using the enumerator.
   Console::WriteLine( "Contents of the collection (using enumerator):" );
   PrintKeysAndValues2( mySSC );

   // Display the contents of the collection using the Keys property and the Item property.
   Console::WriteLine( "Initial contents of the collection (using Keys and Item):" );
   PrintKeysAndValues3( mySSC );

   // Tries to add a value that is too long.
   try
   {
      mySSC->Add( "Ten", "abcdefghij" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   // Tries to add a key that is too long.
   try
   {
      mySSC->Add( "Eleven", "ijk" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   Console::WriteLine();

   // Searches the collection with Contains.
   Console::WriteLine( "Contains \"Three\": {0}", mySSC->Contains( "Three" ) );
   Console::WriteLine( "Contains \"Twelve\": {0}", mySSC->Contains( "Twelve" ) );
   Console::WriteLine();

   // Removes an element from the collection.
   mySSC->Remove( "Two" );

   // Displays the contents of the collection.
   Console::WriteLine( "After removing \"Two\":" );
   PrintKeysAndValues2( mySSC );
}

// Uses the enumerator. 
void PrintKeysAndValues2( ShortStringDictionary^ myCol )
{
   DictionaryEntry myDE;
   System::Collections::IEnumerator^ myEnumerator = myCol->GetEnumerator();
   while ( myEnumerator->MoveNext() )
      if ( myEnumerator->Current != nullptr )
   {
      myDE =  *dynamic_cast<DictionaryEntry^>(myEnumerator->Current);
      Console::WriteLine( "   {0,-5} : {1}", myDE.Key, myDE.Value );
   }

   Console::WriteLine();
}


// Uses the Keys property and the Item property.
void PrintKeysAndValues3( ShortStringDictionary^ myCol )
{
   ICollection^ myKeys = myCol->Keys;
   IEnumerator^ myEnum1 = myKeys->GetEnumerator();
   while ( myEnum1->MoveNext() )
   {
      String^ k = safe_cast<String^>(myEnum1->Current);
      Console::WriteLine( "   {0,-5} : {1}", k, myCol->Item[ k ] );
   }

   Console::WriteLine();
}

/* 
This code produces the following output.

Contents of the collection (using enumerator):
   Three : abc
   Five  : abcde
   Two   : ab
   One   : a
   Four  : abcd

Initial contents of the collection (using Keys and Item):
   Three : abc
   Five  : abcde
   Two   : ab
   One   : a
   Four  : abcd

System.ArgumentException: value must be no more than 5 characters in length.
Parameter name: value
   at ShortStringDictionary.OnValidate(Object key, Object value)
   at System.Collections.DictionaryBase.System.Collections.IDictionary.Add(Object key, Object value)
   at SamplesDictionaryBase.Main()
System.ArgumentException: key must be no more than 5 characters in length.
Parameter name: key
   at ShortStringDictionary.OnValidate(Object key, Object value)
   at System.Collections.DictionaryBase.System.Collections.IDictionary.Add(Object key, Object value)
   at SamplesDictionaryBase.Main()

Contains "Three": True
Contains "Twelve": False

After removing "Two":
   Three : abc
   Five  : abcde
   One   : a
   Four  : abcd

*/
// </Snippet1>
