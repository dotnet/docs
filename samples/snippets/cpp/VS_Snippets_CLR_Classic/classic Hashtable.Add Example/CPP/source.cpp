
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintKeysAndValues( Hashtable^ myHT );
int main()
{
   
   // Creates and initializes a new Hashtable.
   Hashtable^ myHT = gcnew Hashtable;
   myHT->Add( "one", "The" );
   myHT->Add( "two", "quick" );
   myHT->Add( "three", "brown" );
   myHT->Add( "four", "fox" );
   
   // Displays the Hashtable.
   Console::WriteLine( "The Hashtable contains the following:" );
   PrintKeysAndValues( myHT );
}

void PrintKeysAndValues( Hashtable^ myHT )
{
   Console::WriteLine( "\t-KEY-\t-VALUE-" );
   IEnumerator^ myEnum = myHT->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DictionaryEntry de = *safe_cast<DictionaryEntry ^>(myEnum->Current);
      Console::WriteLine( "\t{0}:\t{1}", de.Key, de.Value );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 The Hashtable contains the following:
         -KEY-   -VALUE-
         two:    quick
         three:  brown
         four:   fox
         one:    The
 */
// </Snippet1>
