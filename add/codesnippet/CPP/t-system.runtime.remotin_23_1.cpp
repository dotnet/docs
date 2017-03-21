#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD formatted string to create a SoapInteger object.
   String^ xsdIntegerString = L"-13";
   SoapInteger^ xsdInteger = SoapInteger::Parse( xsdIntegerString );

   // Print the value of the SoapInteger object in XSD format.
   Console::WriteLine( L"The SoapInteger object in XSD format is {0}.",
      xsdInteger );

   // Print the XSD type string of the SoapInteger object.
   Console::WriteLine( L"The XSD type of the SoapInteger "
   L"object is {0}.", xsdInteger->GetXsdType() );

   // Print the value of the SoapInteger object.
   Console::WriteLine( L"The value of the SoapInteger object is {0}.",
      xsdInteger->Value );

   // Print the XSD type string of the SoapInteger class.
   Console::WriteLine( L"The XSD type of the SoapInteger class is {0}.",
      SoapInteger::XsdType );
}