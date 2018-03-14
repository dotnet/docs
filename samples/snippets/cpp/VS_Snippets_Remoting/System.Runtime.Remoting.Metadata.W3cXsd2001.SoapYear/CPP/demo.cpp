/// Need snippets:
///    10    class 
///    21    #ctor()
///    22    #ctor(DateTime)
///    23    #ctor(DateTime,int)
///    13    GetXsdType
///    11    Parse
///    15    Sign
///    12    ToString
///    14    Value
///    16    XsdType

//<snippet10>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD date to create a SoapYear object.
   String^ xsdDate = "2003";
   SoapYear^ date = SoapYear::Parse( xsdDate );
   //</snippet11>

   //<snippet12>
   // Serialize a DateTime object as an XSD date string.
   Console::WriteLine( "The date in XSD format is {0}.",
      date );
   //</snippet12>

   //<snippet13>
   // Print out the XSD type string of this particular SoapYear object.
   Console::WriteLine( "The XSD type of the SoapYear instance is {0}.",
      date->GetXsdType() );
   //</snippet13>

   //<snippet14>
   // Print out the value of the SoapYear object.
   Console::WriteLine( "The value of the SoapYear instance is {0}.",
      date->Value );
   //</snippet14>

   //<snippet15>
   // Print out the sign of the SoapYear object.
   Console::WriteLine( "The sign of the SoapYear instance is {0}.",
      date->Sign );
   //</snippet15>

   //<snippet16>
   // Print out the XSD type string of the SoapYear class.
   Console::WriteLine( "The XSD type of SoapYear is {0}.",
      SoapYear::XsdType );
   //</snippet16>
}
//</snippet10>
