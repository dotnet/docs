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

   SoapBinding^ mySoapBinding = gcnew SoapBinding;
   mySoapBinding->Transport = SoapBinding::HttpTransport;
   mySoapBinding->Style = SoapBindingStyle::Document;

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