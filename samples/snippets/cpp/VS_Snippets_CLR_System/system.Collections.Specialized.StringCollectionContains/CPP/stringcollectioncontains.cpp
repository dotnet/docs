

// The following code example searches the StringCollection for an element.
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
   array<String^>^myArr = {"RED","orange","yellow","RED","green","blue","RED","indigo","violet","RED"};
   myCol->AddRange( myArr );
   Console::WriteLine( "Initial contents of the StringCollection:" );
   PrintValues( myCol );
   
   // Checks whether the collection contains "orange" and, if so, displays its index.
   if ( myCol->Contains( "orange" ) )
      Console::WriteLine( "The collection contains \"orange\" at index {0}.", myCol->IndexOf( "orange" ) );
   else
      Console::WriteLine( "The collection does not contain \"orange\"." );
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

The collection contains "orange" at index 1.

*/
// </snippet1>
