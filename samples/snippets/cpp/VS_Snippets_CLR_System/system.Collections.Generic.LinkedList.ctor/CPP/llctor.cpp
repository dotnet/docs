
// The following code example creates and initializes a LinkedList of type String and then displays its contents.
// <snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;

void main()
{
   // Create and initialize a new LinkedList.
   LinkedList< String^ > ^ ll = gcnew LinkedList< String^ >;
   ll->AddLast( L"red" );
   ll->AddLast( L"orange" );
   ll->AddLast( L"yellow" );
   ll->AddLast( L"orange" );
   
   // Display the contents of the LinkedList.
   if ( ll->Count > 0 )
   {
      Console::WriteLine( L"The first item in the list is {0}.", ll->First->Value );
      Console::WriteLine( L"The last item in the list is {0}.", ll->Last->Value );
      Console::WriteLine( L"The LinkedList contains:" );

      for each (String^ s in ll)
      {
         Console::WriteLine( L"   {0}", s );
      }
   }
   else
   {
      Console::WriteLine( L"The LinkedList is empty." );
   }
}

/* This code produces the following output.

The first item in the list is red.
The last item in the list is orange.
The LinkedList contains:
   red
   orange
   yellow
   orange
*/

// </snippet1>
