

// System::Web::Services::Discovery.SoapBinding::SoapBinding
// System::Web::Services::Discovery.SoapBinding->Address
// System::Web::Services::Discovery.SoapBinding::Binding
// System::Web::Services::Discovery.SoapBinding::Namespace
// System::Web::Services::Discovery.SoapBinding
/* The following example demonstrates 'Discovery::SoapBinding' class, its
* constructor, 'Address', 'Binding' and 'Namespace' members. A variable
* of type 'SoapBinding' is created. The properties are set.
* Finally the created 'SoapBinding' is added to 'DiscoveryClientProtocol'.
*/
// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Net;
using namespace System::Xml;
using namespace System::Web::Services::Discovery;
int main()
{
   try
   {
      
      // <Snippet2>
      // 'dataservice.disco' is a sample discovery document.
      String^ myStringUrl = "http://localhost/dataservice.disco";
      
      // Call the Discover method to populate the Documents property.
      DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
      myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
      DiscoveryDocument^ myDiscoveryDocument = myDiscoveryClientProtocol->Discover( myStringUrl );
      Console::WriteLine( "Demonstrating the Discovery::SoapBinding class." );
      
      // Create a SOAP binding.
      SoapBinding^ mySoapBinding = gcnew SoapBinding;
      
      // Assign an address to the created SOAP binding.
      mySoapBinding->Address = "http://schemas.xmlsoap.org/disco/scl/";
      
      // Bind the created SOAP binding with a new XmlQualifiedName.
      mySoapBinding->Binding = gcnew XmlQualifiedName( "String*","http://www.w3.org/2001/XMLSchema" );
      
      // Add the created SOAP binding to the DiscoveryClientProtocol.
      myDiscoveryClientProtocol->AdditionalInformation->Add( mySoapBinding );
      
      // Display the namespace associated with SOAP binding.
      Console::WriteLine( "Namespace associated with the SOAP binding is: {0}", SoapBinding::Namespace );
      
      // Write all the information of the DiscoveryClientProtocol.
      myDiscoveryClientProtocol->WriteAll( ".", "results.discomap" );
      
      // </Snippet2>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e );
   }

}

// </Snippet1>
