

// System.Web.Services.Description.ServiceDescriptionBaseCollection.
/*
The following example demonstrates 'ServiceDescriptionBaseCollection' class.
A 'ServiceDescription' instance is obtained from the existing Wsdl.
'MyMethod' takes an instance of 'ServiceDescriptionBaseCollection' as a parameter.
Instance of different types of collections that were actually derived from 
'ServiceDescriptionBaseCollection' are passed to my method and modifications of
corresponding  instances in done.
*/
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;
ref class ServiceDescription_Sample
{
public:
   static ServiceDescription^ myServiceDescription;
   static void Main()
   {
      // Read a ServiceDescription of existing WSDL.
      myServiceDescription = ServiceDescription::Read( "Input_CS.wsdl" );

      // Get the ServiceCollection of the ServiceDescription.
      ServiceCollection^ myServiceCollection = myServiceDescription->Services;
      MyMethod( myServiceCollection );
      BindingCollection^ myBindingCollection = myServiceDescription->Bindings;
      MyMethod( myBindingCollection );
      PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
      MyMethod( myPortTypeCollection );
      myServiceDescription->Write( "Output.Wsdl" );
   }

   // <Snippet1>
   static void MyMethod( ServiceDescriptionBaseCollection^ myServiceCollection )
   {
      Type^ myType = myServiceCollection->GetType();
      if ( myType->Equals( System::Web::Services::Description::ServiceCollection::typeid ) )
      {
         // Remove the services at index 0 of the collection.
         (dynamic_cast<ServiceCollection^>(myServiceCollection))->Remove( myServiceDescription->Services[ 0 ] );

         // Build a new Service.
         Service^ myService = gcnew Service;
         myService->Name = "MathService";
         XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:MathServiceSoap" );

         // Build a new Port for SOAP.
         Port^ mySoapPort = gcnew Port;
         mySoapPort->Name = "MathServiceSoap";
         mySoapPort->Binding = myXmlQualifiedName;
         SoapAddressBinding^ mySoapAddressBinding = gcnew SoapAddressBinding;
         mySoapAddressBinding->Location = "http://localhost/"
         "ServiceDescriptionBaseCollection/AddSubtractService.CS.asmx";
         mySoapPort->Extensions->Add( mySoapAddressBinding );

         // Build a new Port for HTTP-GET.
         XmlQualifiedName^ myXmlQualifiedName2 = gcnew XmlQualifiedName( "s0:MathServiceHttpGet" );
         Port^ myHttpGetPort = gcnew Port;
         myHttpGetPort->Name = "MathServiceHttpGet";
         myHttpGetPort->Binding = myXmlQualifiedName2;
         HttpAddressBinding^ myHttpAddressBinding = gcnew HttpAddressBinding;
         myHttpAddressBinding->Location = "http://localhost/"
         "ServiceDescriptionBaseCollection/AddSubtractService.CS.asmx";
         myHttpGetPort->Extensions->Add( myHttpAddressBinding );

         // Add the ports to the Service.
         myService->Ports->Add( myHttpGetPort );
         myService->Ports->Add( mySoapPort );

         // Add the Service to the ServiceCollection.
         myServiceDescription->Services->Add( myService );
      }
      else
      if ( myType->Equals( System::Web::Services::Description::BindingCollection::typeid ) )
      {
         // Remove the Binding in the BindingCollection at index 0.
         (dynamic_cast<BindingCollection^>(myServiceCollection))->Remove( myServiceDescription->Bindings[ 0 ] );

         // Build a new Binding.
         Binding^ myBinding = gcnew Binding;
         myBinding->Name = "MathServiceSoap";
         XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:MathServiceSoap" );
         myBinding->Type = myXmlQualifiedName;
         SoapBinding^ mySoapBinding = gcnew SoapBinding;
         mySoapBinding->Transport = "http://schemas.xmlsoap.org/soap/http";
         mySoapBinding->Style = SoapBindingStyle::Document;

         // Create the operations for the binding.
         OperationBinding^ addOperationBinding = CreateOperationBinding( "Add", myServiceDescription->TargetNamespace );
         OperationBinding^ subtractOperationBinding = CreateOperationBinding( "Subtract", myServiceDescription->TargetNamespace );

         // Add the operations to the Binding.
         myBinding->Operations->Add( subtractOperationBinding );
         myBinding->Operations->Add( addOperationBinding );
         myBinding->Extensions->Add( mySoapBinding );

         // Add the Binding to the Bindings collection.
         myServiceDescription->Bindings->Add( myBinding );
      }
      else
      if ( myType->Equals( System::Web::Services::Description::PortTypeCollection::typeid ) )
      {
         // Remove the PortType at index 0.
         (dynamic_cast<PortTypeCollection^>(myServiceCollection))->Remove( myServiceDescription->PortTypes[ 0 ] );

         // Build a new PortType.
         PortType^ myPortType = gcnew PortType;
         myPortType->Name = "MathServiceSoap";

         // Build an Add Operation for the PortType.
         Operation^ myAddOperation = gcnew Operation;
         myAddOperation->Name = "Add";

         // Build the Input and Output messages for the Operations.
         OperationInput^ myOperationInputMessage1 = gcnew OperationInput;
         XmlQualifiedName^ myXmlQualifiedName1 = gcnew XmlQualifiedName( "s0:AddSoapIn" );
         myOperationInputMessage1->Message = myXmlQualifiedName1;
         OperationOutput^ myOperationOutputMessage1 = gcnew OperationOutput;
         XmlQualifiedName^ myXmlQualifiedName2 = gcnew XmlQualifiedName( "s0:AddSoapOut" );
         myOperationOutputMessage1->Message = myXmlQualifiedName2;

         // Add the messages to the operations.
         myAddOperation->Messages->Add( myOperationInputMessage1 );
         myAddOperation->Messages->Add( myOperationOutputMessage1 );

         // Build an Add Operation for the PortType.
         Operation^ mySubtractOperation = gcnew Operation;
         mySubtractOperation->Name = "Subtract";

         // Build the Input and Output messages for the operations.
         OperationInput^ myOperationInputMessage2 = gcnew OperationInput;
         XmlQualifiedName^ myXmlQualifiedName3 = gcnew XmlQualifiedName( "s0:SubtractSoapIn" );
         myOperationInputMessage2->Message = myXmlQualifiedName3;
         OperationOutput^ myOperationOutputMessage2 = gcnew OperationOutput;
         XmlQualifiedName^ myXmlQualifiedName4 = gcnew XmlQualifiedName( "s0:SubtractSoapOut" );
         myOperationOutputMessage2->Message = myXmlQualifiedName4;

         // Add the messages to the operations.
         mySubtractOperation->Messages->Add( myOperationInputMessage2 );
         mySubtractOperation->Messages->Add( myOperationOutputMessage2 );

         // Add the operations to the PortType.
         myPortType->Operations->Add( myAddOperation );
         myPortType->Operations->Add( mySubtractOperation );

         // Add the PortType to the collection.
         myServiceDescription->PortTypes->Add( myPortType );
      }
   }
   // </Snippet1>   

   static OperationBinding^ CreateOperationBinding( String^ operation, String^ targetNamespace )
   {
      // Create OperationBinding instance for operation.
      OperationBinding^ myOperationBinding = gcnew OperationBinding;
      myOperationBinding->Name = operation;

      // Create InputBinding for operation.
      InputBinding^ myInputBinding = gcnew InputBinding;
      SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
      mySoapBodyBinding->Use = SoapBindingUse::Literal;
      myInputBinding->Extensions->Add( mySoapBodyBinding );

      // Create OutputBinding for operation.
      OutputBinding^ myOutputBinding = gcnew OutputBinding;
      myOutputBinding->Extensions->Add( mySoapBodyBinding );

      // Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'. 
      myOperationBinding->Input = myInputBinding;
      myOperationBinding->Output = myOutputBinding;

      // Create extensibility element for 'SoapOperationBinding'.
      SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
      mySoapOperationBinding->Style = SoapBindingStyle::Document;
      mySoapOperationBinding->SoapAction = String::Concat( targetNamespace, operation );

      // Add extensibility element 'SoapOperationBinding' to 'OperationBinding'.
      myOperationBinding->Extensions->Add( mySoapOperationBinding );
      return myOperationBinding;
   }
};

int main()
{
   ServiceDescription_Sample::Main();
}
