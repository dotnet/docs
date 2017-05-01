
//<Snippet1>
using namespace System;
using namespace System::Resources;
using namespace System::Collections;
int main()
{
   
   // Create a ResourceSet for the file items.resources.
   ResourceSet^ rs = gcnew ResourceSet( "items.resources" );
   
   // Create an IDictionaryEnumerator* to read the data in the ResourceSet.
   IDictionaryEnumerator^ id = rs->GetEnumerator();
   
   // Iterate through the ResourceSet and display the contents to the console.
   while ( id->MoveNext() )
      Console::WriteLine( "\n [{0}] \t {1}", id->Key, id->Value );

   rs->Close();
}

//</Snippet1>
