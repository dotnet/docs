/// Class: System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDay
/// Need snippets:
///    10    class 
///    21    #ctor()
///    22    #ctor(DateTime)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType
///    
///    Bugs:
///    
///    1. Documentation bug: according to the XML spec and the code 
///    SoapDay.Parse(string) should accept the format "---ddzzz" and 
///    "---dd"; the documentation states that SoapDay.Parse(string) 
///    accepts "ddzzz" (which it does not). For gDay examples, see 
///    http://books.xmlschemata.org/relaxng/ch17-77066.html.
///    2. Documentation bug: zzz cannot be in this format "08:00". It 
///    must equal "Z" or it must be in one of these formats: "+08:00" 
///    or "-08:00". Without the leading "+" or "-" sign Parse(string) 
///    fails.

//<snippet10>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD gDay to create a SoapDay object.
   // The time zone of this object is +08:00.
   String^ xsdDay = "---30+08:00";
   SoapDay^ day = SoapDay::Parse( xsdDay );
   //</snippet11>

   //<snippet12>
   // Display the day in XSD format. 
   Console::WriteLine( "The day in XSD format is {0}.",
      day );
   //</snippet12>

   //<snippet13>
   // Display the XSD type string of this particular SoapDay object.
   Console::WriteLine( "The XSD type of the SoapDay instance is {0}.",
      day->GetXsdType() );
   //</snippet13>

   //<snippet14>
   // Display the value of the SoapDay object.
   Console::WriteLine( "The value of the SoapDay instance is {0}.",
      day->Value );
   //</snippet14>

   //<snippet16>
   // Display the XSD type string of the SoapDay class.
   Console::WriteLine( "The XSD type of the class SoapDay is {0}.",
      SoapDay::XsdType );
   //</snippet16>
}
//</snippet10>
