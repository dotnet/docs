#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapPositiveInteger
   // object.
   String^ xsdIntegerString = L"+13";
   SoapPositiveInteger^ xsdInteger =
      SoapPositiveInteger::Parse( xsdIntegerString );

   // Print the value of the SoapPositiveInteger object in XSD format.
   Console::WriteLine( L"The SoapPositiveInteger object in XSD format is {0}.",
      xsdInteger );

   // Print the XSD type string of the SoapPositiveInteger object.
   Console::WriteLine( L"The XSD type of the SoapPositiveInteger "
   L"object is {0}.", xsdInteger->GetXsdType() );

   // Print the value of the SoapPositiveInteger object.
   Console::WriteLine( L"The value of the SoapPositiveInteger object is {0}.",
      xsdInteger->Value );

   // Print the XSD type string of the SoapPositiveInteger class.
   Console::WriteLine( L"The XSD type of the SoapPositiveInteger class "
   L"is {0}.", SoapPositiveInteger::XsdType );
}