

//<Snippet1>
#using <system.windows.forms.dll>
#using <System.dll>

using namespace System;
using namespace System::Resources;
using namespace System::Collections;
void main()
{

   // Create a ResXResourceReader for the file items.resx.
   ResXResourceReader^ rsxr = gcnew ResXResourceReader( "items.resx" );


   // Iterate through the resources and display the contents to the console.
   IEnumerator^ myEnum = rsxr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DictionaryEntry^ d = safe_cast<DictionaryEntry^>(myEnum->Current);
      Console::WriteLine( "{0}:\t {1}", d->Key, d->Value );
   }


   //Close the reader.
   rsxr->Close();
}

//</Snippet1>
