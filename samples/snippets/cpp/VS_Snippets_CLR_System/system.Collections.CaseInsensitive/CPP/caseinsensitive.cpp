
// The following code example creates a case-sensitive hashtable and a case-insensitive hashtable
// and demonstrates the difference in their behavior, even if both contain the same elements.
// <Snippet1>
using namespace System;
using namespace System::Collections;
using namespace System::Globalization;
int main()
{
   
   // Create a Hashtable using the default hash code provider and the default comparer.
   Hashtable^ myHT1 = gcnew Hashtable;
   myHT1->Add( "FIRST", "Hello" );
   myHT1->Add( "SECOND", "World" );
   myHT1->Add( "THIRD", "!" );
   
   // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
   // based on the culture of the current thread.
   Hashtable^ myHT2 = gcnew Hashtable( gcnew CaseInsensitiveHashCodeProvider,gcnew CaseInsensitiveComparer );
   myHT2->Add( "FIRST", "Hello" );
   myHT2->Add( "SECOND", "World" );
   myHT2->Add( "THIRD", "!" );
   
   // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
   // based on the InvariantCulture.
   Hashtable^ myHT3 = gcnew Hashtable( CaseInsensitiveHashCodeProvider::DefaultInvariant,CaseInsensitiveComparer::DefaultInvariant );
   myHT3->Add( "FIRST", "Hello" );
   myHT3->Add( "SECOND", "World" );
   myHT3->Add( "THIRD", "!" );
   
   // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
   // based on the Turkish culture (tr-TR), where "I" is not the uppercase version of "i".
   CultureInfo^ myCul = gcnew CultureInfo( "tr-TR" );
   Hashtable^ myHT4 = gcnew Hashtable( gcnew CaseInsensitiveHashCodeProvider( myCul ),gcnew CaseInsensitiveComparer( myCul ) );
   myHT4->Add( "FIRST", "Hello" );
   myHT4->Add( "SECOND", "World" );
   myHT4->Add( "THIRD", "!" );
   
   // Search for a key in each hashtable.
   Console::WriteLine( "first is in myHT1: {0}", myHT1->ContainsKey( "first" ) );
   Console::WriteLine( "first is in myHT2: {0}", myHT2->ContainsKey( "first" ) );
   Console::WriteLine( "first is in myHT3: {0}", myHT3->ContainsKey( "first" ) );
   Console::WriteLine( "first is in myHT4: {0}", myHT4->ContainsKey( "first" ) );
}

/* 
This code produces the following output.  Results vary depending on the system's culture settings.

first is in myHT1: False
first is in myHT2: True
first is in myHT3: True
first is in myHT4: False

*/
// </Snippet1>
