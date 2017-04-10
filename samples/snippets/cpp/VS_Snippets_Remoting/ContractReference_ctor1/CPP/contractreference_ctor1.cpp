// System::Web::Services::Discovery.ContractReference::ContractReference(String*)

/*
The following example demonstrates the constructor 'ContractReference(String*)'
of 'ContractReference' class. A 'DiscoveryDocument' Object* is created .The
constructor initializes a new instance of 'ContractReference' using the supplied
reference to a Service Description::The Contract reference Object* is added to the list
of references contained within the discovery document. A '.disco' file is generated
for the webservice, where the reference tags of ContractReference are reflected.
*/

#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::IO;
using namespace System::Web::Services::Discovery;

int main()
{
   try
   {
      // Create a DiscoveryDocument.
      DiscoveryDocument^ myDiscoveryDocument = gcnew DiscoveryDocument;
      
// <Snippet1>
      // Create a ContractReference using a reference to a service description.
      ContractReference^ myContractReference = gcnew ContractReference(
         "http://localhost/Service1::asmx?wsdl" );
// </Snippet1>

      // Set the URL for an XML Web service implementing the service description.
      myContractReference->DocRef = "http://localhost/service1.asmx";
      SoapBinding^ myBinding = gcnew SoapBinding;
      myBinding->Binding = gcnew XmlQualifiedName( "q1:Service1Soap" );
      myBinding->Address = "http://localhost/service1.asmx";
      
      // Add myContractReference to the list of references contained
      // in the discovery document.
      myDiscoveryDocument->References->Add( myContractReference );
      myDiscoveryDocument->References->Add( myBinding );
      
      // Open or create a file for writing.
      FileStream^ myFileStream = gcnew FileStream( "Service1.disco",FileMode::OpenOrCreate,FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      
      // Write myDiscoveryDocument into the passed stream.
      myDiscoveryDocument->Write( myStreamWriter );
      Console::WriteLine( "The Service1.disco is generated." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Error is {0}", e->Message );
   }
}
