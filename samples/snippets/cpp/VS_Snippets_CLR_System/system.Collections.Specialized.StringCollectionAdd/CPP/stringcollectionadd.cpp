

// The following code example adds new elements to the StringCollection.
// <snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;
void PrintValues( IEnumerable^ myCol );
int main()
{
   
   // Creates and initializes a new StringCollection.
   StringCollection^ myCol = gcnew StringCollection;
   Console::WriteLine( "Initial contents of the StringCollection:" );
   PrintValues( myCol );
   
   // Adds a range of elements from an array to the end of the StringCollection.
   array<String^>^myArr = {"RED","orange","yellow","RED","green","blue","RED","indigo","violet","RED"};
   myCol->AddRange( myArr );
   Console::WriteLine( "After adding a range of elements:" );
   PrintValues( myCol );
   
   // Adds one element to the end of the StringCollection and inserts another at index 3.
   myCol->Add( "* white" );
   myCol->Insert( 3, "* gray" );
   Console::WriteLine( "After adding \"* white\" to the end and inserting \"* gray\" at index 3:" );
   PrintValues( myCol );
}

void PrintValues( IEnumerable^ myCol )
{
   IEnumerator^ myEnum = myCol->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ obj = safe_cast<Object^>(myEnum->Current);
      Console::WriteLine( "   {0}", obj );
   }

   Console::WriteLine();
}

/*
This code produces the following output.

Initial contents of the StringCollection:

After adding a range of elements:
   RED
   orange
   yellow
   RED
   green
   blue
   RED
   indigo
   violet
   RED

After adding "* white" to the end and inserting "* gray" at index 3:
   RED
   orange
   yellow
   * gray
   RED
   green
   blue
   RED
   indigo
   violet
   RED
   * white

*/
// </snippet1>
