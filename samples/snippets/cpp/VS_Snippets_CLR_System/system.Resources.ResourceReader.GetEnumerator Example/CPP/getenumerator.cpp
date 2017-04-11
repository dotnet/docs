
//<snippet1>
using namespace System;
using namespace System::Resources;
using namespace System::Collections;
int main()
{
   
   // Create a ResourceReader for the file items.resources.
   ResourceReader^ rr = gcnew ResourceReader( "items.resources" );
   
   // Create an IDictionaryEnumerator* to iterate through the resources.
   IDictionaryEnumerator^ id = rr->GetEnumerator();
   
   // Iterate through the resources and display the contents to the console.
   while ( id->MoveNext() )
      Console::WriteLine( "\n [{0}] \t {1}", id->Key, id->Value );

   rr->Close();
}

//</snippet1>
