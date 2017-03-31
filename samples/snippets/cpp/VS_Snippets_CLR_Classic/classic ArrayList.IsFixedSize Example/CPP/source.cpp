
// <Snippet1>
using namespace System;
using namespace System::Collections;
void PrintValues( IEnumerable^ myList, char mySeparator );
int main()
{
   
   // Creates and initializes a new ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "The" );
   myAL->Add( "quick" );
   myAL->Add( "brown" );
   myAL->Add( "fox" );
   myAL->Add( "jumped" );
   myAL->Add( "over" );
   myAL->Add( "the" );
   myAL->Add( "lazy" );
   myAL->Add( "dog" );
   
   // Create a fixed-size wrapper around the ArrayList.
   ArrayList^ myFixedSizeAL = ArrayList::FixedSize( myAL );
   
   // Display whether the ArrayLists have a fixed size or not.
   Console::WriteLine( "myAL {0}.", myAL->IsFixedSize ? (String^)"has a fixed size" : "does not have a fixed size" );
   Console::WriteLine( "myFixedSizeAL {0}.", myFixedSizeAL->IsFixedSize ? (String^)"has a fixed size" : "does not have a fixed size" );
   Console::WriteLine();
   
   // Display both ArrayLists.
   Console::WriteLine( "Initially," );
   Console::Write( "Standard  :" );
   PrintValues( myAL, ' ' );
   Console::Write( "Fixed size:" );
   PrintValues( myFixedSizeAL, ' ' );
   
   // Sort is allowed in the fixed-size ArrayList.
   myFixedSizeAL->Sort();
   
   // Display both ArrayLists.
   Console::WriteLine( "After Sort," );
   Console::Write( "Standard  :" );
   PrintValues( myAL, ' ' );
   Console::Write( "Fixed size:" );
   PrintValues( myFixedSizeAL, ' ' );
   
   // Reverse is allowed in the fixed-size ArrayList.
   myFixedSizeAL->Reverse();
   
   // Display both ArrayLists.
   Console::WriteLine( "After Reverse," );
   Console::Write( "Standard  :" );
   PrintValues( myAL, ' ' );
   Console::Write( "Fixed size:" );
   PrintValues( myFixedSizeAL, ' ' );
   
   // Add an element to the standard ArrayList.
   myAL->Add( "AddMe" );
   
   // Display both ArrayLists.
   Console::WriteLine( "After adding to the standard ArrayList," );
   Console::Write( "Standard  :" );
   PrintValues( myAL, ' ' );
   Console::Write( "Fixed size:" );
   PrintValues( myFixedSizeAL, ' ' );
   Console::WriteLine();
   
   // Adding or inserting elements to the fixed-size ArrayList throws an exception.
   try
   {
      myFixedSizeAL->Add( "AddMe2" );
   }
   catch ( Exception^ myException ) 
   {
      Console::WriteLine( "Exception: {0}", myException );
   }

   try
   {
      myFixedSizeAL->Insert( 3, "InsertMe" );
   }
   catch ( Exception^ myException ) 
   {
      Console::WriteLine( "Exception: {0}", myException );
   }

}

void PrintValues( IEnumerable^ myList, char mySeparator )
{
   IEnumerator^ myEnum = myList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::Write( "{0}{1}", mySeparator, obj );
   }

   Console::WriteLine();
}

/*
 This code produces the following output.
 
 myAL does not have a fixed size.
 myFixedSizeAL has a fixed size.

 Initially,
 Standard  : The quick brown fox jumped over the lazy dog
 Fixed size: The quick brown fox jumped over the lazy dog
 After Sort,
 Standard  : brown dog fox jumped lazy over quick the The
 Fixed size: brown dog fox jumped lazy over quick the The
 After Reverse,
 Standard  : The the quick over lazy jumped fox dog brown
 Fixed size: The the quick over lazy jumped fox dog brown
 After adding to the standard ArrayList,
 Standard  : The the quick over lazy jumped fox dog brown AddMe
 Fixed size: The the quick over lazy jumped fox dog brown AddMe

 Exception: System.NotSupportedException: Collection was of a fixed size.
    at System.Collections.FixedSizeArrayList.Add(Object obj)
    at SamplesArrayList.Main()
 Exception: System.NotSupportedException: Collection was of a fixed size.
    at System.Collections.FixedSizeArrayList.Insert(Int32 index, Object obj)
    at SamplesArrayList.Main()

 */
// </Snippet1>
