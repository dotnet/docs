
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintKeysAndValues( Hashtable^ myHT );
int main()
{
   
   // Creates and initializes a new Hashtable.
   Hashtable^ myHT = gcnew Hashtable;
   myHT->Add( "First", "Hello" );
   myHT->Add( "Second", "World" );
   myHT->Add( "Third", "!" );
   
   // Displays the properties and values of the Hashtable.
   Console::WriteLine( "myHT" );
   Console::WriteLine( "  Count:    {0}", myHT->Count );
   Console::WriteLine( "  Keys and Values:" );
   PrintKeysAndValues( myHT );
}

void PrintKeysAndValues( Hashtable^ myHT )
{
   Console::WriteLine( "\t-KEY-\t-VALUE-" );
   IEnumerator^ myEnum = myHT->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DictionaryEntry de =  *safe_cast<DictionaryEntry ^>(myEnum->Current);
      Console::WriteLine( "\t{0}:\t{1}", de.Key, de.Value );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 myHT
   Count:    3
   Keys and Values:
         -KEY-   -VALUE-
         Second: World
         Third:  !
         First:  Hello

 */
// </Snippet1>
