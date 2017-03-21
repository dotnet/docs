#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapNonNegativeInteger
   // object.
   String^ xsdIntegerString = L"+13";
   SoapNonNegativeInteger^ xsdInteger = SoapNonNegativeInteger::Parse(
      xsdIntegerString );

   // Print the value of the SoapNonNegativeInteger object
   // in XSD format.
   Console::WriteLine( 
      L"The SoapNonNegativeInteger object in XSD format is {0}.",
      xsdInteger );

   // Print the XSD type string of the SoapNonNegativeInteger object.
   Console::WriteLine( L"The XSD type of the SoapNonNegativeInteger "
   L"object is {0}.", xsdInteger->GetXsdType() );

   // Print the value of the SoapNonNegativeInteger object.
   Console::WriteLine( L"The value of the SoapNonNegativeInteger "
   L"object is {0}.", xsdInteger->Value );

   // Print the XSD type string of the SoapNonNegativeInteger class.
   Console::WriteLine( L"The XSD type of the SoapNonNegativeInteger class "
   L"is {0}.", SoapNonNegativeInteger::XsdType );
}
