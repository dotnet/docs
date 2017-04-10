

// The following code example shows how a StringDictionary can be copied to an array.
// <snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
void main()
{
   
   // Creates and initializes a new StringDictionary.
   StringDictionary^ myCol = gcnew StringDictionary;
   myCol->Add( "red", "rojo" );
   myCol->Add( "green", "verde" );
   myCol->Add( "blue", "azul" );
   
   // Displays the values in the StringDictionary.
   Console::WriteLine( "KEYS\tVALUES in the StringDictionary" );
   IEnumerator^ myEnum = myCol->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DictionaryEntry^ myDE = safe_cast<DictionaryEntry^>(myEnum->Current);
      Console::WriteLine( "{0}\t{1}", myDE->Key, myDE->Value );
      Console::WriteLine();
      
      // Creates an array with DictionaryEntry elements.
      array<DictionaryEntry>^myArr = gcnew array<DictionaryEntry>(3);
      
      // Copies the StringDictionary to the array.
      myCol->CopyTo( myArr, 0 );
      
      // Displays the values in the array.
      Console::WriteLine( "KEYS\tVALUES in the array" );
      for ( int i = 0; i < myArr->Length; i++ )
         Console::WriteLine( "{0}\t{1}", myArr[ i ].Key, myArr[ i ].Value );
      Console::WriteLine();
   }
}

/*
This code produces the following output.

KEYS    VALUES in the StringDictionary
green   verde
red     rojo
blue    azul

KEYS    VALUES in the array
green   verde
red     rojo
blue    azul

*/
// </snippet1>
