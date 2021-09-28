// System::Web::Services::Discovery.DiscoveryClientProtocol->AdditionalInformation

/* The following example demonstrates 'AdditionalInformation' of DiscoveryClientProtocol
class.
In the example 'SoapBinding' informations is added to a 'DiscoveryClientProtocol' using
'AdditionalInformation' collection. The soap binding added is retrived back and SoapBinding
address is displayed. The resultant document is written back.
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
      // dataservice.disco is a sample discovery document.
      String^ myStringUrl = "http://localhost/dataservice.disco";
      
      // Call the Discover method to populate the Documents property.
      DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
      myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
      myDiscoveryClientProtocol->Discover( myStringUrl );
      SoapBinding^ mySoapBinding = gcnew SoapBinding;
      mySoapBinding->Address = "http://schemas.xmlsoap.org/disco/scl/";
      mySoapBinding->Binding = gcnew XmlQualifiedName( "String*","http://www.w3.org/2001/XMLSchema" );
      myDiscoveryClientProtocol->AdditionalInformation->Add( mySoapBinding );
      
      // Write the information back.
      myDiscoveryClientProtocol->WriteAll( "MyDirectory", "results.discomap" );
      System::Collections::IList^ myIList = myDiscoveryClientProtocol->AdditionalInformation;
      mySoapBinding = nullptr;
      mySoapBinding = dynamic_cast<SoapBinding^>(myIList[ 0 ]);
      Console::WriteLine( "The address of the SoapBinding associated with "
      "AdditionalInformation is: {0}", mySoapBinding->Address );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e );
   }
}
// </Snippet1>
