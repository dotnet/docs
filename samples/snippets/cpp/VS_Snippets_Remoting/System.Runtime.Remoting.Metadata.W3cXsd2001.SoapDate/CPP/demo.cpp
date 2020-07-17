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
   // Parse an XSD date to create a SoapDate object.
   String^ xsdDate = "2003-02-04";
   SoapDate^ date = SoapDate::Parse( xsdDate );
   //</snippet11>

   //<snippet12>
   // Serialize a DateTime object as an XSD date string.
   Console::WriteLine( "The date in XSD format is {0}.",
      date );
   //</snippet12>

   //<snippet13>
   // Print out the XSD type string of this particular SoapDate object.
   Console::WriteLine( "The XSD type of the SoapDate instance is {0}.",
      date->GetXsdType() );
   //</snippet13>

   //<snippet14>
   // Print out the value of the SoapDate object.
   Console::WriteLine( "The value of the SoapDate instance is {0}.",
      date->Value );
   //</snippet14>

   //<snippet15>
   // Print out the sign of the SoapDate object.
   Console::WriteLine( "The sign of the SoapDate instance is {0}.",
      date->Sign );
   //</snippet15>

   //<snippet16>
   // Print out the XSD type string of the SoapDate class.
   Console::WriteLine( "The XSD type of SoapDate is {0}.",
      SoapDate::XsdType );
   //</snippet16>
}
//</snippet10>
