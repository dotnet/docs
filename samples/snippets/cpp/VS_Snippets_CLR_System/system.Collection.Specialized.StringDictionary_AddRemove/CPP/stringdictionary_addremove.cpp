

// The following code example demonstrates how to add and remove elements from a StringDictionary.
// <snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
void PrintKeysAndValues( StringDictionary^ myCol )
{
   Console::WriteLine( "   KEY        VALUE" );
   IEnumerator^ enum0 = myCol->GetEnumerator();
   while ( enum0->MoveNext() )
   {
      DictionaryEntry^ de = safe_cast<DictionaryEntry^>(enum0->Current);
      Console::WriteLine( "   {0,-10} {1}", de->Key, de->Value );
   }

   Console::WriteLine();
}

int main()
{
   
   // Creates and initializes a new StringDictionary.
   StringDictionary^ myCol = gcnew StringDictionary;
   myCol->Add( "red", "rojo" );
   myCol->Add( "green", "verde" );
   myCol->Add( "blue", "azul" );
   
   // Displays the values in the StringDictionary.
   Console::WriteLine( "Initial contents of the StringDictionary:" );
   PrintKeysAndValues( myCol );
   
   // Deletes an element.
   myCol->Remove( "green" );
   Console::WriteLine( "The collection contains the following elements after removing \"green\":" );
   PrintKeysAndValues( myCol );
   
   // Clears the entire collection.
   myCol->Clear();
   Console::WriteLine( "The collection contains the following elements after it is cleared:" );
   PrintKeysAndValues( myCol );
}

/*
This code produces the following output.

Initial contents of the StringDictionary:
   KEY        VALUE
   green      verde
   red        rojo
   blue       azul

The collection contains the following elements after removing "green":
   KEY        VALUE
   red        rojo
   blue       azul

The collection contains the following elements after it is cleared:
   KEY        VALUE

*/
// </snippet1>
