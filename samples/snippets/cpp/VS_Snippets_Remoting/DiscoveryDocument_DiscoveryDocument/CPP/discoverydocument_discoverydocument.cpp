

// System::Web::Services::Discovery.DiscoveryDocument::DiscoveryDocument
// System::Web::Services::Discovery.DiscoveryDocument::Namespace
// System::Web::Services::Discovery.DiscoveryDocument::CanRead
// System::Web::Services::Discovery.DiscoveryDocument::Read(XmlReader)
// System::Web::Services::Discovery.DiscoveryDocument::References
/* The following example deomonstrates the 'DiscoveryDocument' constructor,
'Namespace' field, 'References' property and the 'CanRead' and 'Read(XmlReader)'
methods of the 'DiscoveryDocument' class.
The namespace field is displayed onto the console. A XmlTextReader Object* is
created with a sample discovery file and this is passed to the CanRead method
to check whether it is readable. Then we read this file to create a Discovery
document and display the references in the created document.
*/
// <Snippet1>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::IO;
using namespace System::Web::Services::Discovery;
using namespace System::Collections;
int main()
{
   try
   {
      
      // Create an Object* of the 'DiscoveryDocument'.
      DiscoveryDocument^ myDiscoveryDocument = gcnew DiscoveryDocument;
      
      // <Snippet2>
      // Display the 'Namespace' field.
      Console::WriteLine( "The namespace is : {0}", DiscoveryDocument::Namespace );
      
      // </Snippet2>
      // Create an XmlTextReader with the sample file.
      XmlTextReader^ myXmlTextReader = gcnew XmlTextReader( "http://localhost/example.vsdisco" );
      
      // <Snippet3>
      // <Snippet4>
      // Check whether the given XmlTextReader is readable.
      if ( DiscoveryDocument::CanRead( myXmlTextReader ) == true )
            
      // Read the given XmlTextReader.
      myDiscoveryDocument = DiscoveryDocument::Read( myXmlTextReader );
      else
            Console::WriteLine( "The supplied file is not readable" );
      
      // </Snippet4>
      // </Snippet3>
      // <Snippet5>
      // Enumerate the 'References' in the DiscoveryDocument.
      IEnumerator^ myEnumerator = myDiscoveryDocument->References->GetEnumerator();
      Console::WriteLine( "The 'References' in the discovery document are-" );
      while ( myEnumerator->MoveNext() )
            Console::Write( (dynamic_cast<DiscoveryDocumentReference^>(myEnumerator->Current)->Url) );
      
      // </Snippet5>
      Console::WriteLine();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised : {0}", e->Message );
   }

}

// </Snippet1>
