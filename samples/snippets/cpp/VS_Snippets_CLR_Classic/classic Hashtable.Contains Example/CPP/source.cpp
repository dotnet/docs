
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintIndexAndKeysAndValues( Hashtable^ myHT );
int main()
{
   
   // Creates and initializes a new Hashtable.
   Hashtable^ myHT = gcnew Hashtable;
   myHT->Add( (int^)0, "zero" );
   myHT->Add( 1, "one" );
   myHT->Add( 2, "two" );
   myHT->Add( 3, "three" );
   myHT->Add( 4, "four" );
   
   // Displays the values of the Hashtable.
   Console::WriteLine( "The Hashtable contains the following values:" );
   PrintIndexAndKeysAndValues( myHT );
   
   // Searches for a specific key.
   int myKey = 2;
   Console::WriteLine( "The key \"{0}\" is {1}.", myKey, myHT->ContainsKey( myKey ) ? (String^)"in the Hashtable" : "NOT in the Hashtable" );
   myKey = 6;
   Console::WriteLine( "The key \"{0}\" is {1}.", myKey, myHT->ContainsKey( myKey ) ? (String^)"in the Hashtable" : "NOT in the Hashtable" );
   
   // Searches for a specific value.
   String^ myValue = "three";
   Console::WriteLine( "The value \"{0}\" is {1}.", myValue, myHT->ContainsValue( myValue ) ? (String^)"in the Hashtable" : "NOT in the Hashtable" );
   myValue = "nine";
   Console::WriteLine( "The value \"{0}\" is {1}.", myValue, myHT->ContainsValue( myValue ) ? (String^)"in the Hashtable" : "NOT in the Hashtable" );
}

void PrintIndexAndKeysAndValues( Hashtable^ myHT )
{
   int i = 0;
   Console::WriteLine( "\t-INDEX-\t-KEY-\t-VALUE-" );
   IEnumerator^ myEnum = myHT->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DictionaryEntry de =  *safe_cast<DictionaryEntry ^>(myEnum->Current);
      Console::WriteLine( "\t[{0}]:\t{1}\t{2}", i++, de.Key, de.Value );
   }

   Console::WriteLine();
}

/* 
 This code produces the following output.
 
 The Hashtable contains the following values:
         -INDEX- -KEY-   -VALUE-
         [0]:    4       four
         [1]:    3       three
         [2]:    2       two
         [3]:    1       one
         [4]:    0       zero

 The key "2" is in the Hashtable.
 The key "6" is NOT in the Hashtable.
 The value "three" is in the Hashtable.
 The value "nine" is NOT in the Hashtable.

 */
// </Snippet1>
