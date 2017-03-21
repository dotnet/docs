#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapNonPositiveInteger
   // object.
   String^ xsdIntegerString = L"-13";
   SoapNonPositiveInteger^ xsdInteger =
      SoapNonPositiveInteger::Parse( xsdIntegerString );

   // Print the value of the SoapNonPositiveInteger object
   // in XSD format.
   Console::WriteLine( L"The SoapNonPositiveInteger object in XSD format is {0}.",
      xsdInteger );

   // Print the XSD type string of the SoapNonPositiveInteger object.
   Console::WriteLine( L"The XSD type of the SoapNonPositiveInteger object is {0}.",
      xsdInteger->GetXsdType() );

   // Print the value of the SoapNonPositiveInteger object.
   Console::WriteLine( L"The value of the SoapNonPositiveInteger object is {0}.",
      xsdInteger->Value );

   // Print the XSD type string of the SoapNonPositiveInteger class.
   Console::WriteLine( L"The XSD type of the SoapNonPositiveInteger class is {0}.",
      SoapNonPositiveInteger::XsdType );
}
