#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapQName object.
   String^ xsdQName = L"tns:SomeName";
   SoapQName^ qName = SoapQName::Parse( xsdQName );

   // Print the value of the SoapQName object in XSD format.
   Console::WriteLine( L"The SoapQName object in XSD format is {0}.", qName );

   // Print the XSD type string of the SoapQName object.
   Console::WriteLine( L"The XSD type of the SoapQName "
   L"object is {0}.", qName->GetXsdType() );

   // Print the XSD type string of the SoapQName class.
   Console::WriteLine( L"The XSD type of the SoapQName class "
   L"is {0}.", SoapQName::XsdType );

   // Create a QName object.
   SoapQName^ soapQNameInstance = gcnew SoapQName(
      L"tns",L"SomeName",L"http://example.org" );
   
   // Print the key the SoapQName object.
   Console::WriteLine( L"The key of the SoapQName object is {0}.",
      soapQNameInstance->Key );

   // Print the name of the SoapQName object.
   Console::WriteLine( L"The name of the SoapQName "
   L"object is {0}.", soapQNameInstance->Name );

   // Print the namespace of the SoapQName class.
   Console::WriteLine( L"The namespace for this instance of SoapQName is {0}.",
      soapQNameInstance->Namespace );
}