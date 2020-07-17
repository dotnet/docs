/// Class: System.Runtime.Remoting.Metadata.W3cXsd2001.SoapMonth
///    10    class 
///    21    #ctor()
///    22    #ctor(DateTime)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType
///    
///    Bugs in SoapMonth:
///    
///    1. SoapMonth.Parse interprets timezone inconsistently: The 
///    following both reduce the month by 1. Either they should not 
///    alter the month. Or the first one should reduce but the second 
///    one should not:
///      SoapMonth.Parse("--02--+08:00").ToString() // Prints "--01--".
///      SoapMonth.Parse("--02---07:00").ToString() // Prints "--01--".
/// 
///    2. SoapMonth.Parse throws exception when the timezone is "Z": 
///    SoapMonth.Parse throws the following exception,
///      System.FormatException: String was not recognized as a valid DateTime.
/// when invoked as follows,
///      SoapMonth.Parse("--02--Z");    // Throws exception.
///    It fails to correctly interpret Z as the current timezone.
///    
/// 3. SoapMonth.Parse documentation incorrect: The documentation 
/// states that Parse can accept months formatted as "05", "01".
/// This is incorrect. The acceptable formats (according to the code
/// and according to the XML spec) are: "--MM--" and "--MM--zzz".

//<snippet10>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD gMonth to create a SoapMonth object.
   // The timezone of this object is +08:00.
   String^ xsdMonth = "--02--+08:00";
   SoapMonth^ month = SoapMonth::Parse( xsdMonth );
   //</snippet11>

   //<snippet12>
   // Print the month in XSD format. 
   Console::WriteLine( "The month in XSD format is {0}.",
      month );
   //</snippet12>

   //<snippet13>
   // Print the XSD type string of this particular SoapMonth object.
   Console::WriteLine( "The XSD type of the SoapMonth instance is {0}.",
      month->GetXsdType() );
   //</snippet13>

   //<snippet14>
   // Print the value of the SoapMonth object.
   Console::WriteLine( "The value of the SoapMonth instance is {0}.",
      month->Value );
   //</snippet14>

   //<snippet16>
   // Print the XSD type string of the SoapMonth class.
   Console::WriteLine( "The XSD type of the class SoapMonth is {0}.",
      SoapMonth::XsdType );
   //</snippet16>
}
//</snippet10>
