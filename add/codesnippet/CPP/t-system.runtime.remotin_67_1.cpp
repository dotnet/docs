#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapNegativeInteger
   // object.
   String^ xsdIntegerString = L"-13";
   SoapNegativeInteger^ xsdInteger = SoapNegativeInteger::Parse(
      xsdIntegerString );

   // Print the value of the SoapNegativeInteger object in XSD format.
   Console::WriteLine( L"The SoapNegativeInteger object in XSD format is {0}.",
      xsdInteger );

   // Print the XSD type string of the SoapNegativeInteger object.
   Console::WriteLine( L"The XSD type of the SoapNegativeInteger "
   L"object is {0}.", xsdInteger->GetXsdType() );

   // Print the value of the SoapNegativeInteger object.
   Console::WriteLine( L"The value of the SoapNegativeInteger "
   L"object is {0}.", xsdInteger->Value );

   // Print the XSD type string of the SoapNegativeInteger class.
   Console::WriteLine( L"The XSD type of the SoapNegativeInteger class "
   L"is {0}.", SoapNegativeInteger::XsdType );
}