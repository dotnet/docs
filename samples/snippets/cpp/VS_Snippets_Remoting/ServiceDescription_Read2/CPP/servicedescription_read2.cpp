

// System::Web::Services::Description.Read(StreamReader)
/*
The following example demonstrates the 'Read(StreamReader)' method  of
'ServiceDescription' class.A ServiceDescription instance is
obtained from existing Wsdl. Name property of Bindings in the
ServiceDescription is displayed to console.
*/
#using <System.Web.Services.dll>

// #using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Web::Services::Description;
using namespace System::Xml;
using namespace System::IO;

int main()
{
   try
   {
      // <Snippet1>
      // Create a StreamReader to read a WSDL file.
      StreamReader^ myStreamReader = gcnew StreamReader( "MyWsdl.wsdl" );
      ServiceDescription^ myDescription = ServiceDescription::Read( myStreamReader );
      Console::WriteLine( "Bindings are: " );

      // Display the Bindings present in the WSDL file.
      System::Collections::IEnumerator^ myEnum = myDescription->Bindings->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Binding^ myBinding = safe_cast<Binding^>(myEnum->Current);
         Console::WriteLine( myBinding->Name );
      }
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }
}
