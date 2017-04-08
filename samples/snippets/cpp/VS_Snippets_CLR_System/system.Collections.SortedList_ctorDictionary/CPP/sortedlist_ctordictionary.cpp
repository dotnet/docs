
// The following code example creates SortedList instances using different constructors
// and demonstrates the differences in the behavior of the SortedList instances.
// <Snippet1>


using namespace System;
using namespace System::Collections;
using namespace System::Globalization;
void PrintKeysAndValues( SortedList^ myList )
{
   Console::WriteLine( "        -KEY-   -VALUE-" );
   for ( int i = 0; i < myList->Count; i++ )
   {
      Console::WriteLine( "        {0,-6}: {1}", myList->GetKey( i ), myList->GetByIndex( i ) );

   }
   Console::WriteLine();
}

int main()
{
   
   // Create the dictionary.
   Hashtable^ myHT = gcnew Hashtable;
   myHT->Add( "FIRST", "Hello" );
   myHT->Add( "SECOND", "World" );
   myHT->Add( "THIRD", "!" );
   
   // Create a SortedList using the default comparer.
   SortedList^ mySL1 = gcnew SortedList( myHT );
   Console::WriteLine( "mySL1 (default):" );
   try
   {
      mySL1->Add( "first", "Ola!" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   PrintKeysAndValues( mySL1 );
   
   // Create a SortedList using the specified case-insensitive comparer.
   SortedList^ mySL2 = gcnew SortedList( myHT,gcnew CaseInsensitiveComparer );
   Console::WriteLine( "mySL2 (case-insensitive comparer):" );
   try
   {
      mySL2->Add( "first", "Ola!" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   PrintKeysAndValues( mySL2 );
   
    // Create a SortedList using the specified CaseInsensitiveComparer,
    // which is based on the Turkish culture (tr-TR), where "I" is not
    // the uppercase version of "i".
   CultureInfo^ myCul = gcnew CultureInfo( "tr-TR" );
   SortedList^ mySL3 = gcnew SortedList( myHT, gcnew CaseInsensitiveComparer( myCul ) );
   Console::WriteLine( "mySL3 (case-insensitive comparer, Turkish culture):" );
   try
   {
      mySL3->Add( "first", "Ola!" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   PrintKeysAndValues( mySL3 );
   
   // Create a SortedList using the ComparisonType.InvariantCultureIgnoreCase value.
   SortedList^ mySL4 = gcnew SortedList( myHT, StringComparer::InvariantCultureIgnoreCase );
   Console::WriteLine( "mySL4 (InvariantCultureIgnoreCase):" );
   try
   {
      mySL4->Add( "first", "Ola!" );
   }
   catch ( ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   PrintKeysAndValues( mySL4 );
}

/* 
This code produces the following output.  Results vary depending on the system's culture settings.

mySL1 (default):
        -KEY-   -VALUE-
        first : Ola!
        FIRST : Hello
        SECOND: World
        THIRD : !

mySL2 (case-insensitive comparer):
System.ArgumentException: Item has already been added.  Key in dictionary: 'FIRST'  Key being added: 'first'
   at System.Collections.SortedList.Add(Object key, Object value)
   at SamplesSortedList.Main()
        -KEY-   -VALUE-
        FIRST : Hello
        SECOND: World
        THIRD : !

mySL3 (case-insensitive comparer, Turkish culture):
        -KEY-   -VALUE-
        FIRST : Hello
        first : Ola!
        SECOND: World
        THIRD : !

mySL4 (InvariantCultureIgnoreCase):
System.ArgumentException: Item has already been added.  Key in dictionary: 'FIRST'  Key being added: 'first'
   at System.Collections.SortedList.Add(Object key, Object value)
   at SamplesSortedList.Main()
        -KEY-   -VALUE-
        FIRST : Hello
        SECOND: World
        THIRD : !

*/
// </Snippet1>
