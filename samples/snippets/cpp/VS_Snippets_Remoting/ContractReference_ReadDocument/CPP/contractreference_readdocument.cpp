// System::Web::Services::Discovery.ContractReference::ReadDocument
/*
* The following example demonstrates the 'ReadDocument' method of the
* 'ContractReference' class.
* It creates an instance of 'ContractReference' class and calls the
* 'ReadDocument' method passing a service description stream and get a
* 'ServiceDescription' instance.
*/
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Discovery;
using namespace System::Web::Services::Description;

// <Snippet1>
int main()
{
   try
   {
      // Create the file stream.
      FileStream^ wsdlStream = gcnew FileStream( "MyService1_cpp.wsdl",FileMode::Open );
      ContractReference^ myContractReference = gcnew ContractReference;
      
      // Read the service description from the passed stream.
      ServiceDescription^ myServiceDescription = dynamic_cast<ServiceDescription^>(myContractReference->ReadDocument( wsdlStream ));
      Console::Write( "Target Namespace for the service description is: {0}", myServiceDescription->TargetNamespace );
      wsdlStream->Close();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
