

// System::Web::Services::Discovery.SchemaReference::SchemaReference()
// System::Web::Services::Discovery.SchemaReference::SchemaReference(String*)
// System::Web::Services::Discovery.SchemaReference::SchemaReference.DefaultFileName
// System::Web::Services::Discovery.SchemaReference::SchemaReference.Namespace
// System::Web::Services::Discovery.SchemaReference::SchemaReference.ReadDocument(stream)
// System::Web::Services::Discovery.SchemaReference::SchemaReference.Schema
// System::Web::Services::Discovery.SchemaReference::SchemaReference.Ref
// System::Web::Services::Discovery.SchemaReference::SchemaReference.TargetNamespace
// System::Web::Services::Discovery.SchemaReference::SchemaReference.Url
// System::Web::Services::Discovery.SchemaReference::SchemaReference.WriteDocument(Object*, stream)
// System::Web::Services::Discovery.SchemaReference::SchemaReference
/* This example demonstrates 'SchemaReference' class, its constructors, 'ReadDocument',
* 'WriteDocument', 'Namespace, 'DefaultFileName', 'Schema', 'Ref', 'TargetNamespace',
* and 'Url' members. A variable of type 'SchemaReference' is taken. An xml schema
* document is passed as parameter to overloaded constructor. All the membes are shown
* using 'SchemaReference' variable.
Note : The dataservice.xsd file should be copied to Inetpub\wwwroot
*/
// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Web::Services::Discovery;
int main()
{
   try
   {
      
      // <Snippet2>
      // Reference the schema document.
      String^ myStringUrl = "c:\\Inetpub\\wwwroot\\dataservice.xsd";
      XmlSchema^ myXmlSchema;
      
      // Create the client protocol.
      DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
      myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
      
      //  Create a schema reference.
      SchemaReference^ mySchemaReferenceNoParam = gcnew SchemaReference;
      SchemaReference^ mySchemaReference = gcnew SchemaReference( myStringUrl );
      
      // Set the client protocol.
      mySchemaReference->ClientProtocol = myDiscoveryClientProtocol;
      
      // Access the default file name associated with the schema reference.
      Console::WriteLine( "Default filename is : {0}", mySchemaReference->DefaultFilename );
      
      // Access the namespace associated with schema reference class.
      Console::WriteLine( "Namespace is : {0}", SchemaReference::Namespace );
      FileStream^ myStream = gcnew FileStream( myStringUrl,FileMode::OpenOrCreate );
      
      // Read the document in a stream.
      mySchemaReference->ReadDocument( myStream );
      
      // Get the schema of referenced document.
      myXmlSchema = mySchemaReference->Schema;
      Console::WriteLine( "Reference is : {0}", mySchemaReference->Ref );
      Console::WriteLine( "Target namespace (default empty) is : {0}", mySchemaReference->TargetNamespace );
      Console::WriteLine( "URL is : {0}", mySchemaReference->Url );
      
      // Write the document in the stream.
      mySchemaReference->WriteDocument( myXmlSchema, myStream );
      myStream->Close();
      mySchemaReference = nullptr;
      
      // </Snippet2>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e );
   }

}

// </Snippet1>
