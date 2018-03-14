// System::Web::Services::Description.SoapBodyBinding::PartsString
// System::Web::Services::Description.SoapFaultBinding::ctor
// System::Web::Services::Description.SoapFaultBinding::Use
// System::Web::Services::Description.SoapFaultBinding::Encoding
// System::Web::Services::Description.SoapFaultBinding::NameSpace

/*
The following example demonstrates the 'PartsString' property of 'SoapBodyBinding' class
and constructor, 'Encoding', 'NameSpace' and 'Use'properties of 'SoapFaultBinding' class.

It creates an instance of 'ServiceDescription' class by reading  an existing
wsdl file. Then it creates an instance of 'SoapFaultBinding' and adds it to
the collection object of 'Binding' class. It generates a new wsdl file where
the properties of 'SoapFaultBinding' objects are reflected and which could be
used for generating a proxy.
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Description;
int main()
{
   try
   {
      // Input wsdl file.
      String^ myInputWsdlFile = "SoapFaultInput_cpp.wsdl";

      // Output wsdl file.
      String^ myOutputWsdlFile = "SoapFaultOutput_cpp.wsdl";

      // Initialize an instance of a 'ServiceDescription' object.
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( myInputWsdlFile );

      // Get a SOAP binding object with binding name S"MyService1Soap".
      Binding^ myBinding = myServiceDescription->Bindings[ "MyService1Soap" ];

      // Create the 'OperationBinding' object for the 'SOAP' protocol.
      OperationBinding^ myOperationBinding = gcnew OperationBinding;
      myOperationBinding->Name = "Add";

      // Create the 'SoapOperationBinding' object for the 'SOAP' protocol.
      SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
      mySoapOperationBinding->SoapAction = "http://tempuri.org/Add";
      mySoapOperationBinding->Style = SoapBindingStyle::Document;

      // Add the 'SoapOperationBinding' object to 'OperationBinding' object.
      myOperationBinding->Extensions->Add( mySoapOperationBinding );

      // <Snippet1>
      // Create the 'InputBinding' object for the 'SOAP' protocol.
      InputBinding^ myInput = gcnew InputBinding;
      SoapBodyBinding^ mySoapBinding1 = gcnew SoapBodyBinding;
      mySoapBinding1->PartsString = "parameters";
      mySoapBinding1->Use = SoapBindingUse::Literal;
      myInput->Extensions->Add( mySoapBinding1 );

      // Assign the 'InputBinding' to 'OperationBinding'.
      myOperationBinding->Input = myInput;

      // Create the 'OutputBinding' object' for the 'SOAP' protocol..
      OutputBinding^ myOutput = gcnew OutputBinding;
      myOutput->Extensions->Add( mySoapBinding1 );

      // Assign the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding->Output = myOutput;
      // </Snippet1>

      // <Snippet2>
      // <Snippet3>
      // <Snippet4>
      // <Snippet5>
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
      myOperationBinding->Faults->Add( myFaultBinding );
      myBinding->Operations->Add( myOperationBinding );
      
      // </Snippet5>
      // </Snippet4>
      // </Snippet3>
      // </Snippet2>
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
