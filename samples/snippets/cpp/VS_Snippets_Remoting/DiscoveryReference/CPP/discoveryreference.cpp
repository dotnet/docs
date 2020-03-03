// System::Web::Services::Discovery.DiscoveryReference::ClientProtocol
// System::Web::Services::Discovery.DiscoveryReference::DefaultFilename
// System::Web::Services::Discovery.DiscoveryReference::WriteDocument(Object*, Stream)
// System::Web::Services::Discovery.DiscoveryReference::ReadDocument(Stream)
// System::Web::Services::Discovery.DiscoveryReference::Url
// System::Web::Services::Discovery.DiscoveryReference::Resolve()
// This program demonstrates 'ClientProtocol', 'WriteDocumant', 'Url' properties
//   and 'DefaultFilename', 'readDocument', 'Resolve' methods of 'DiscoveryReference'
//   class. DiscoveryReference class is derived in 'MyDiscoveryReferenceClass'. A
//   variable of type 'MyDiscoveryReferenceClass' class is taken to demonstrate these
//   members.
//  Note : The dataservice.disco file should be copied to Inetpub\wwwroot
//

// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Discovery;
using namespace System::Net;

// Class derived from DiscoveryReference class and overriding its members.
ref class MyDiscoveryReferenceClass: public DiscoveryReference
{
private:
   String^ myDocumentUrl;

public:
   property String^ DefaultFilename 
   {
      virtual String^ get() override
      {
         return "dataservice.disco";
      }
   }

   virtual Object^ ReadDocument( Stream^ stream ) override
   {
      return stream;
   }

   void Resolve()
   {
      try
      {
         DiscoveryDocument^ myDiscoveryRefDocument;
         myDiscoveryRefDocument = __super::ClientProtocol->Discover( Url );
      }
      catch ( Exception^ e ) 
      {
         throw e;
      }
   }

protected:
   virtual void Resolve( String^ contentType, Stream^ stream ) override {}

public:

   property String^ Url 
   {
      virtual String^ get() override
      {
         return myDocumentUrl;
      }

      virtual void set( String^ value ) override
      {
         myDocumentUrl = value;
      }
   }
   virtual void WriteDocument( Object^ document, System::IO::Stream^ stream ) override
   {
      DiscoveryDocument^ myDiscoveryDocument = dynamic_cast<DiscoveryDocument^>(document);
      myDiscoveryDocument->Write( stream );
   }
};

int main()
{
   DiscoveryDocument^ myDiscoveryDocument;
   StreamReader^ myStreamReader = gcnew StreamReader( "c:\\Inetpub\\wwwroot\\dataservice.disco" );
   FileStream^ myStream = gcnew FileStream( "C:\\MyDiscovery.disco",FileMode::OpenOrCreate );
   Console::WriteLine( "Demonstrating Discovery Reference class." );
   
   // Read discovery file.
   myDiscoveryDocument = DiscoveryDocument::Read( myStreamReader );
   
   // Variable of type DiscoveryReference class defined.
   MyDiscoveryReferenceClass^ myDiscoveryReference;
   myDiscoveryReference = gcnew MyDiscoveryReferenceClass;
   DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
   myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
   
   // Set client protocol.
   myDiscoveryReference->ClientProtocol = myDiscoveryClientProtocol;
   
   // Read the default file name.
   Console::WriteLine( "Default file name is: {0}", myDiscoveryReference->DefaultFilename );
   
   // Write the document.
   myDiscoveryReference->WriteDocument( myDiscoveryDocument, myStream );
   
   // Read the document.
   myDiscoveryReference->ReadDocument( myStream );
   
   // Set the URL.
   myDiscoveryReference->Url = "http://localhost/dataservice.disco";
   Console::WriteLine( "Url is: {0}", myDiscoveryReference->Url );
   
   // Resolve the URL.
   myDiscoveryReference->Resolve();
   myStreamReader->Close();
   myStream->Close();
}
// </Snippet1>
