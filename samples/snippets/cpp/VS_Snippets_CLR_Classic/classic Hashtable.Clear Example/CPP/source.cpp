
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
   myHT->Add( "five", "jumped" );
   
   // Displays the count and values of the Hashtable.
   Console::WriteLine( "Initially," );
   Console::WriteLine( "   Count    : {0}", myHT->Count );
   Console::WriteLine( "   Values:" );
   PrintKeysAndValues( myHT );
   
   // Clears the Hashtable.
   myHT->Clear();
   
   // Displays the count and values of the Hashtable.
   Console::WriteLine( "After Clear," );
   Console::WriteLine( "   Count    : {0}", myHT->Count );
   Console::WriteLine( "   Values:" );
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
 
 Initially,
    Count    : 5
    Values:
         -KEY-   -VALUE-
         two:    quick
         three:  brown
         four:   fox
         five:   jumped
         one:    The

 After Clear,
    Count    : 0
    Values:
         -KEY-   -VALUE-

 */
// </Snippet1>
