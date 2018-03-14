// System::Web::Services::Description.SoapFaultBinding

/*
The following example demonstrates 'SoapFaultBinding' class.
It creates an instance of 'ServiceDescription' class by reading  an existing
wsdl file. Then it creates an instance of 'SoapFaultBinding' and adds it to
the collection object of 'Binding' class. It generates a new wsdl file where
the properties of 'SoapFaultBinding' objects are reflected and which could be
used for generating a proxy.
*/

// <Snippet1>
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;

int main()
{
   try
   {
      // Input wsdl file.
      String^ myInputWsdlFile = "SoapFaultBindingInput_cpp.wsdl";

      // Output wsdl file.
      String^ myOutputWsdlFile = "SoapFaultBindingOutput_cpp.wsdl";

      // Initialize an instance of a 'ServiceDescription' object.
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( myInputWsdlFile );

      // Get a SOAP binding object with binding name S"MyService1Soap".
      Binding^ myBinding = myServiceDescription->Bindings[ "MyService1Soap" ];

      // Create a new instance of 'SoapFaultBinding' class.
      SoapFaultBinding^ mySoapFaultBinding = gcnew SoapFaultBinding;

      // Encode fault message using rules specified by 'Encoding' property.
      mySoapFaultBinding->Use = SoapBindingUse::Encoded;

      // Set the URI representing the encoding style.
      mySoapFaultBinding->Encoding = "http://tempuri.org/stockquote";

      // Set the URI representing the location of the specification
      // for encoding of content not defined by 'Encoding' property'.
      mySoapFaultBinding->Namespace = "http://tempuri.org/stockquote";

      // Create a new instance of 'FaultBinding'.
      FaultBinding^ myFaultBinding = gcnew FaultBinding;
      myFaultBinding->Name = "AddFaultbinding";
      myFaultBinding->Extensions->Add( mySoapFaultBinding );

      // Get existing 'OperationBinding' object.
      OperationBinding^ myOperationBinding = myBinding->Operations[ 0 ];
      myOperationBinding->Faults->Add( myFaultBinding );

      // Create a new wsdl file.
      myServiceDescription->Write( myOutputWsdlFile );
      Console::WriteLine( "The new wsdl file created is : {0}", myOutputWsdlFile );
      Console::WriteLine( "Proxy could be created using command : wsdl {0}", myOutputWsdlFile );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Error occured : {0}", e->Message );
   }
}
// </Snippet1>
