using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD date to create a SoapYear object.
   String^ xsdDate = "2003";
   SoapYear^ date = SoapYear::Parse( xsdDate );

   // Serialize a DateTime object as an XSD date string.
   Console::WriteLine( "The date in XSD format is {0}.",
      date );

   // Print out the XSD type string of this particular SoapYear object.
   Console::WriteLine( "The XSD type of the SoapYear instance is {0}.",
      date->GetXsdType() );

   // Print out the value of the SoapYear object.
   Console::WriteLine( "The value of the SoapYear instance is {0}.",
      date->Value );

   // Print out the sign of the SoapYear object.
   Console::WriteLine( "The sign of the SoapYear instance is {0}.",
      date->Sign );

   // Print out the XSD type string of the SoapYear class.
   Console::WriteLine( "The XSD type of SoapYear is {0}.",
      SoapYear::XsdType );
}