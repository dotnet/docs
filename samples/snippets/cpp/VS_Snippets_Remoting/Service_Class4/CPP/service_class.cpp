// System.Web.Services.Description.Service.Ports
// System.Web.Services.Description.Service.Extensions
// System.Web.Services.Description.Service.Service()
// System.Web.Services.Description.Service.Name

/*The following sample demonstrates the properties 'Ports','Extensions','Name' and
constructor 'Service()'.This sample reads the contents of a file 'MathService_cs.wsdl'
into a 'ServiceDescription' instance. It gets the collection of Service
instances from 'ServiceDescription'. It then removes a 'Service' from the collection and
creates a new 'Service' and adds it into collection. It writes a new web service description
file 'MathService_New.wsdl'.
*/

// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Xml;

Port^ CreatePort( String^ PortName, String^ BindingName, String^ targetNamespace )
{
   Port^ myPort = gcnew Port;
   myPort->Name = PortName;
   myPort->Binding = gcnew XmlQualifiedName( BindingName,targetNamespace );
   
   // Create a SoapAddress extensibility element to add to the port.
   SoapAddressBinding^ mySoapAddressBinding = gcnew SoapAddressBinding;
   mySoapAddressBinding->Location = "http://localhost/Service_Class/MathService_CS.asmx";
   myPort->Extensions->Add( mySoapAddressBinding );
   return myPort;
}

int main()
{
   try
   {
      // <Snippet2>
      // <Snippet3>
      // <Snippet4>
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_CS.wsdl" );
      ServiceCollection^ myServiceCollection = myServiceDescription->Services;
      int noOfServices = myServiceCollection->Count;
      Console::WriteLine( "\nTotal number of services: {0}", noOfServices );
      
      // Get a reference to the service.
      Service^ myOldService = myServiceCollection[ 0 ];
      Console::WriteLine( "No. of Ports in the Service{0}", myServiceCollection[ 0 ]->Ports->Count );
      Console::WriteLine( "These are the ports in the service:" );
      for ( int i = 0; i < myOldService->Ports->Count; i++ )
         Console::WriteLine( "Port name: {0}", myOldService->Ports[ i ]->Name );
      Console::WriteLine( "Service name: {0}", myOldService->Name );
      Service^ myService = gcnew Service;
      myService->Name = "MathService";
      
      // Add the ports to the newly created service.
      for ( int i = 0; i < myOldService->Ports->Count; i++ )
      {
         String^ PortName = myServiceCollection[ 0 ]->Ports[ i ]->Name;
         String^ BindingName = myServiceCollection[ 0 ]->Ports[ i ]->Binding->Name;
         myService->Ports->Add( CreatePort( PortName, BindingName, myServiceDescription->TargetNamespace ) );

      }
      Console::WriteLine( "Newly created ports -" );
      for ( int i = 0; i < myService->Ports->Count; i++ )
         Console::WriteLine( "Port Name: {0}", myOldService->Ports[ i ]->Name );
      
      // Add the extensions to the newly created service.
      int noOfExtensions = myOldService->Extensions->Count;
      Console::WriteLine( "No. of extensions: {0}", noOfExtensions );
      if ( noOfExtensions > 0 )
      {
         for ( int i = 0; i < myOldService->Ports->Count; i++ )
            myService->Extensions->Add( myServiceCollection[ 0 ]->Extensions[ i ] );
      }
      
      // Remove the service from the collection.
      myServiceCollection->Remove( myOldService );
      
      // Add the newly created service.
      myServiceCollection->Add( myService );
      myServiceDescription->Write( "MathService_New.wsdl" );
      // </Snippet4>
      // </Snippet3>
      // </Snippet2>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }

}
// </Snippet1>
