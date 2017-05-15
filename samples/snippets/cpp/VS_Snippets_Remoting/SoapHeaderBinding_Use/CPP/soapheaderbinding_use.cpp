// System::Web::Services::Description.SoapHeaderBinding::ctor
// System::Web::Services::Description.SoapHeaderBinding::Message
// System::Web::Services::Description.SoapHeaderBinding::Part
// System::Web::Services::Description.SoapHeaderBinding::Use

/*
The following example demonstrates the constructor, 'Message' , 'Part'
and 'Use' properties of the class 'SoapHeaderBinding'.
It takes as input a wsdl file. The binding element corresponding to
SOAP protocol is removed from the input file. By using the 'Read' method
of 'ServiceDescription' class it gets a 'ServiceDescription' Object*.
It uses the SOAP protocol related classes  and  creates 'Binding' element
of 'SOAP' protocol which are then added to the 'ServiceDescription' Object*.
An output wsdl file is generated from 'ServiceDescription' Object* which
could be used for generating a proxy.
*/

#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Web::Services::Description;
using namespace System::Xml;

int main()
{
   ServiceDescription^ myServiceDescription =
      ServiceDescription::Read( "SoapHeaderBindingInput_cpp.wsdl" );
   Binding^ myBinding = gcnew Binding;
   myBinding->Name = "MyWebServiceSoap";
   myBinding->Type = gcnew XmlQualifiedName( "s0:MyWebServiceSoap" );

   SoapBinding^ mySoapBinding = gcnew SoapBinding;
   mySoapBinding->Transport = "http://schemas.xmlsoap.org/soap/http";
   mySoapBinding->Style = SoapBindingStyle::Document;
   myBinding->Extensions->Add( mySoapBinding );

   OperationBinding^ myOperationBinding = gcnew OperationBinding;
   myOperationBinding->Name = "Hello";

   SoapOperationBinding^ mySoapOperationBinding =
      gcnew SoapOperationBinding;
   mySoapOperationBinding->SoapAction = "http://tempuri.org/Hello";
   mySoapOperationBinding->Style = SoapBindingStyle::Document;
   myOperationBinding->Extensions->Add( mySoapOperationBinding );
   
   // Create InputBinding for operation for the 'SOAP' protocol.
   InputBinding^ myInputBinding = gcnew InputBinding;
   SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
   mySoapBodyBinding->Use = SoapBindingUse::Literal;
   myInputBinding->Extensions->Add( mySoapBodyBinding );
   
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
   SoapHeaderBinding^ mySoapHeaderBinding = gcnew SoapHeaderBinding;
   // Set the Message within the XML Web service to which the
   // 'SoapHeaderBinding' applies.
   mySoapHeaderBinding->Message =
      gcnew XmlQualifiedName( "s0:HelloMyHeader" );
   mySoapHeaderBinding->Part = "MyHeader";
   mySoapHeaderBinding->Use = SoapBindingUse::Literal;
   // Add mySoapHeaderBinding to the 'myInputBinding' object.
   myInputBinding->Extensions->Add( mySoapHeaderBinding );
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>

   // Create OutputBinding for operation for the 'SOAP' protocol.
   OutputBinding^ myOutputBinding = gcnew OutputBinding;
   myOutputBinding->Extensions->Add( mySoapBodyBinding );
   
   // Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'.
   myOperationBinding->Input = myInputBinding;
   myOperationBinding->Output = myOutputBinding;
   myBinding->Operations->Add( myOperationBinding );

   myServiceDescription->Bindings->Add( myBinding );
   myServiceDescription->Write( "SoapHeaderBindingOut_cpp.wsdl" );
   Console::WriteLine( "'SoapHeaderBindingOut_cpp.wsdl' file is generated." );
   Console::WriteLine( "Proxy could be created using " +
      "'wsdl SoapHeaderBindingOut_cpp.wsdl'." );
}
