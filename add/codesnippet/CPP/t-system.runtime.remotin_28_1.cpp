#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapAnyUri object.
   String^ xsdAnyUri = L"http://localhost:8080/WebService";
   SoapAnyUri^ anyUri = SoapAnyUri::Parse( xsdAnyUri );

   // Print the value of the SoapAnyUri object in XSD format.
   Console::WriteLine( L"The SoapAnyUri object in XSD format is {0}.", anyUri );

   // Print the XSD type string of the SoapAnyUri object.
   Console::WriteLine( L"The XSD type of the SoapAnyUri "
   L"object is {0}.", anyUri->GetXsdType() );

   // Print the value of the SoapAnyUri object.
   Console::WriteLine( L"The value of the SoapAnyUri object is {0}.", anyUri->Value );
   
   // Print the XSD type string of the SoapAnyUri class.
   Console::WriteLine( L"The XSD type of the SoapAnyUri class "
   L"is {0}.", SoapAnyUri::XsdType );

   return 1;
}