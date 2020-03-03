// System.Web.Services.Discovery.DiscoveryReference

/*
This program demonstrates 'DiscoveryReference' class.
DiscoveryReference class is derived in 'MyDiscoveryReferenceClass'. A
variable of type 'MyDiscoveryReferenceClass' class is taken to demonstrate
members of 'MyDiscoveryReferenceClass'.
Note : The dataservice.disco file should be copied to c:\Inetpub\wwwroot
*/

// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Discovery;
using namespace System::Net;

// Class derived from DiscoveryReference class and overriding it members.
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
         myDiscoveryRefDocument = DiscoveryReference::ClientProtocol->Discover( Url );
      }
      catch ( Exception^ e ) 
      {
         throw e;
      }
   }

protected:
   virtual void Resolve( String^ /*contentType*/, Stream^ /*stream*/ ) override {}

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
   try
   {
      DiscoveryDocument^ myDiscoveryDocument;
      StreamReader^ myStreamReader = gcnew StreamReader( "c:\\Inetpub\\wwwroot\\dataservice.disco" );
      FileStream^ myStream = gcnew FileStream( "c:\\MyDiscovery.disco",FileMode::OpenOrCreate );
      Console::WriteLine( "Demonstrating DiscoveryReference class." );
      
      // Read discovery file.
      myDiscoveryDocument = DiscoveryDocument::Read( myStreamReader );
      
      // Create a new instance of the DiscoveryReference class.
      MyDiscoveryReferenceClass^ myDiscoveryReference;
      myDiscoveryReference = gcnew MyDiscoveryReferenceClass;
      DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
      myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
      
      // Set the client protocol.
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
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught! - {0}", e->Message );
   }
}
// </Snippet1>
