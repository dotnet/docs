#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;

int main()
{
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "SoapHeaderBindingInput_cpp.wsdl" );
   Binding^ myBinding = gcnew Binding;
   myBinding->Name = "MyWebServiceSoap";
   myBinding->Type = gcnew XmlQualifiedName( "s0:MyWebServiceSoap" );
   SoapBinding^ mySoapBinding = gcnew SoapBinding;
   mySoapBinding->Transport = "http://schemas.xmlsoap.org/soap/http";
   mySoapBinding->Style = SoapBindingStyle::Document;
   myBinding->Extensions->Add( mySoapBinding );
   OperationBinding^ myOperationBinding = gcnew OperationBinding;
   myOperationBinding->Name = "Hello";
   SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
   mySoapOperationBinding->SoapAction = "http://tempuri.org/Hello";
   mySoapOperationBinding->Style = SoapBindingStyle::Document;
   myOperationBinding->Extensions->Add( mySoapOperationBinding );

   // Create InputBinding for operation for the 'SOAP' protocol.
   InputBinding^ myInputBinding = gcnew InputBinding;
   SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
   mySoapBodyBinding->Use = SoapBindingUse::Literal;
   myInputBinding->Extensions->Add( mySoapBodyBinding );
   SoapHeaderBinding^ mySoapHeaderBinding = gcnew SoapHeaderBinding;
   mySoapHeaderBinding->Message = gcnew XmlQualifiedName( "s0:HelloMyHeader" );
   mySoapHeaderBinding->Part = "MyHeader";
   mySoapHeaderBinding->Use = SoapBindingUse::Literal;

   // Add mySoapHeaderBinding to 'myInputBinding' object.
   myInputBinding->Extensions->Add( mySoapHeaderBinding );

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
   Console::WriteLine( "Proxy could be created using 'wsdl SoapHeaderBindingOut_cpp.wsdl'." );
}