

// System.Web.Services.Description.SoapBinding
// System.Web.Services.Description.SoapOperationBinding
// System.Web.Services.Description.SoapBodyBinding
// System.Web.Services.Description.SoapAddressBinding
// System.Web.Services.Description.SoapBinding.HttpTransport;
/*
The following example demonstrates the 'SoapBinding', 'SoapOperationBinding' ,
'SoapBodyBinding' , SoapAddressBinding'  classes and 'HttpTransport' field of 'SoapBinding' class.

It takes a wsdl file which supports two protocols 'HttpGet' and 'HttpPost' as input. By using the
'Read' method of 'ServiceDescription' class it gets the 'ServiceDescription' object. It uses
the SOAP protocol related classes  and  creates 'Binding','Port' and 'PortType' elements of
'SOAP' protocol. It adds all the elements to the 'ServiceDescription' object. The 'ServiceDescription'
object creates another wsdl file which supports 'SOAP' also. This wsdl file is used to generate a proxy
which is used by the .aspx file.
*/
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;
int main()
{
   ServiceDescription^ myDescription = ServiceDescription::Read( "AddNumbersInput_cs.wsdl" );

   // Create a 'Binding' object for the 'SOAP' protocol.
   Binding^ myBinding = gcnew Binding;
   myBinding->Name = "Service1Soap";
   XmlQualifiedName^ qualifiedName = gcnew XmlQualifiedName( "s0:Service1Soap" );
   myBinding->Type = qualifiedName;

   // <Snippet5>
   SoapBinding^ mySoapBinding = gcnew SoapBinding;
   mySoapBinding->Transport = SoapBinding::HttpTransport;
   mySoapBinding->Style = SoapBindingStyle::Document;
   // </Snippet5>

   // Add the 'SoapBinding' object to the 'Binding' object.
   myBinding->Extensions->Add( mySoapBinding );

   // Create the 'OperationBinding' object for the 'SOAP' protocol.
   OperationBinding^ myOperationBinding = gcnew OperationBinding;
   myOperationBinding->Name = "AddNumbers";

   // Create the 'SoapOperationBinding' object for the 'SOAP' protocol.
   SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
   mySoapOperationBinding->SoapAction = "http://tempuri.org/AddNumbers";
   mySoapOperationBinding->Style = SoapBindingStyle::Document;

   // Add the 'SoapOperationBinding' object to 'OperationBinding' object.
   myOperationBinding->Extensions->Add( mySoapOperationBinding );

   // Create the 'InputBinding' object for the 'SOAP' protocol.
   InputBinding^ myInput = gcnew InputBinding;
   SoapBodyBinding^ mySoapBinding1 = gcnew SoapBodyBinding;
   mySoapBinding1->Use = SoapBindingUse::Literal;
   myInput->Extensions->Add( mySoapBinding1 );

   // Assign the 'InputBinding' to 'OperationBinding'.
   myOperationBinding->Input = myInput;

   // Create the 'OutputBinding' object' for the 'SOAP' protocol..
   OutputBinding^ myOutput = gcnew OutputBinding;
   myOutput->Extensions->Add( mySoapBinding1 );

   // Assign the 'OutPutBinding' to 'OperationBinding'.
   myOperationBinding->Output = myOutput;

   // Add the 'OperationBinding' to 'Binding'.
   myBinding->Operations->Add( myOperationBinding );

   // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
   myDescription->Bindings->Add( myBinding );
   Port^ soapPort = gcnew Port;
   soapPort->Name = "Service1Soap";
   soapPort->Binding = gcnew XmlQualifiedName( "s0:Service1Soap" );

   // Create a 'SoapAddressBinding' object for the 'SOAP' protocol.
   SoapAddressBinding^ mySoapAddressBinding = gcnew SoapAddressBinding;
   mySoapAddressBinding->Location = "http://localhost/AddNumbers.cs.asmx";

   // Add the 'SoapAddressBinding' to the 'Port'.
   soapPort->Extensions->Add( mySoapAddressBinding );

   // Add the 'Port' to 'PortCollection' of 'ServiceDescription'.
   myDescription->Services[ 0 ]->Ports->Add( soapPort );

   // Write the 'ServiceDescription' as a WSDL file.
   myDescription->Write( "AddNumbersOut_cs.wsdl" );
   Console::WriteLine( " 'AddNumbersOut_cs.Wsdl' file was generated" );
}
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>
