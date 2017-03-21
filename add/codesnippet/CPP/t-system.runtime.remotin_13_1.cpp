using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD date to create a SoapDate object.
   String^ xsdDate = "2003-02-04";
   SoapDate^ date = SoapDate::Parse( xsdDate );

   // Serialize a DateTime object as an XSD date string.
   Console::WriteLine( "The date in XSD format is {0}.",
      date );

   // Print out the XSD type string of this particular SoapDate object.
   Console::WriteLine( "The XSD type of the SoapDate instance is {0}.",
      date->GetXsdType() );

   // Print out the value of the SoapDate object.
   Console::WriteLine( "The value of the SoapDate instance is {0}.",
      date->Value );

   // Print out the sign of the SoapDate object.
   Console::WriteLine( "The sign of the SoapDate instance is {0}.",
      date->Sign );

   // Print out the XSD type string of the SoapDate class.
   Console::WriteLine( "The XSD type of SoapDate is {0}.",
      SoapDate::XsdType );
}