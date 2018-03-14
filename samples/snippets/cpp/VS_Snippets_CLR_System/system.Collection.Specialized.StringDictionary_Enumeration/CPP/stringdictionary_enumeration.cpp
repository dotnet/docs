// The following code example enumerates the elements of a StringDictionary.
// <snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

void PrintKeysAndValues1( StringDictionary^ myCol );
void PrintKeysAndValues2( StringDictionary^ myCol );
void PrintKeysAndValues3( StringDictionary^ myCol );

int main()
{
   // Creates and initializes a new StringDictionary.
   StringDictionary^ myCol = gcnew StringDictionary;
   myCol->Add( "red", "rojo" );
   myCol->Add( "green", "verde" );
   myCol->Add( "blue", "azul" );
   
   // Display the contents of the collection using for each. This is the preferred method.
   Console::WriteLine( "Displays the elements using for each:" );
   PrintKeysAndValues1( myCol );

   // Display the contents of the collection using the enumerator.
   Console::WriteLine( "Displays the elements using the IEnumerator:" );
   PrintKeysAndValues2( myCol );
   
   // Display the contents of the collection using the Keys, Values, Count, and Item properties.
   Console::WriteLine( "Displays the elements using the Keys, Values, Count, and Item properties:" );
   PrintKeysAndValues3( myCol );
}

// Uses the for each statement which hides the complexity of the enumerator.
// NOTE: The for each statement is the preferred way of enumerating the contents of a collection.
void PrintKeysAndValues1( StringDictionary^ myCol )  {
   Console::WriteLine( "   KEY                       VALUE" );
   for each ( DictionaryEntry^ de in myCol )
      Console::WriteLine( "   {0,-25} {1}", de->Key, de->Value );
   Console::WriteLine();
}

// Uses the enumerator. 
void PrintKeysAndValues2( StringDictionary^ myCol )
{
   IEnumerator^ myEnumerator = myCol->GetEnumerator();
   DictionaryEntry^ de;
   Console::WriteLine( "   KEY                       VALUE" );
   while ( myEnumerator->MoveNext() )
   {
      de =  (DictionaryEntry^)(myEnumerator->Current);
      Console::WriteLine( "   {0,-25} {1}", de->Key, de->Value );
   }
   Console::WriteLine();
}

// Uses the Keys, Values, Count, and Item properties.
void PrintKeysAndValues3( StringDictionary^ myCol )
{
   array<String^>^myKeys = gcnew array<String^>(myCol->Count);
   myCol->Keys->CopyTo( myKeys, 0 );
   Console::WriteLine( "   INDEX KEY                       VALUE" );
   for ( int i = 0; i < myCol->Count; i++ )
      Console::WriteLine( "   {0,-5} {1,-25} {2}", i, myKeys[ i ], myCol[ myKeys[ i ] ] );
   Console::WriteLine();
}

/*
This code produces the following output.

Displays the elements using for each:
   KEY                       VALUE
   red                       rojo
   blue                      azul
   green                     verde

Displays the elements using the IEnumerator:
   KEY                       VALUE
   red                       rojo
   blue                      azul
   green                     verde

Displays the elements using the Keys, Values, Count, and Item properties:
   INDEX KEY                       VALUE
   0     red                       rojo
   1     blue                      azul
   2     green                     verde

*/
// </snippet1>
