/// Class: System.Runtime.Remoting.Metadata.W3cXsd2001.SoapMonthDay
///    10    class
///    21    #ctor()
///    22    #ctor(DateTime)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType
///    Bugs in SoapMonthDay:
///    1. SoapMonthDay.Parse throws exception when the time zone is "Z":
///    SoapMonthDay.Parse throws the following exception,
///        System.FormatException: String was not recognized
///        as a valid DateTime.
/// when invoked as follows,
///        SoapMonthDay.Parse("--02--Z");    // Throws exception.
///    It fails to correctly interpret "Z" as the current time zone.
///
/// 2. SoapMonthDay.Parse documentation incorrect: The documentation
/// does not state how to compose a SoapMonthDay for Parse. It also
/// incorrectly states that "08:00" is a valid time zone (this should
/// be "+08:00").
//<snippet10>
#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD gMonthDay to create a SoapMonthDay object.
   // Parse the representation for February 21, in the UTC+8 time zone.
   String^ xsdMonthDay = L"--02-21+08:00";
   SoapMonthDay^ monthDay = SoapMonthDay::Parse( xsdMonthDay );
   //</snippet11>

   //<snippet12>
   // Print the monthDay in XSD format.
   Console::WriteLine( L"The SoapMonthDay object in XSD format is {0}.",
      monthDay );
   //</snippet12>

   //<snippet13>
   // Print the XSD type string of this particular SoapMonthDay object.
   Console::WriteLine( L"The XSD type of the SoapMonthDay object is {0}.",
      monthDay->GetXsdType() );
   //</snippet13>

   //<snippet14>
   // Print the value of the SoapMonthDay object.
   Console::WriteLine( L"The value of the SoapMonthDay object is {0}.",
      monthDay->Value );
   //</snippet14>

   //<snippet16>
   // Print the XSD type string of the SoapMonthDay class.
   Console::WriteLine( L"The XSD type of the class SoapMonthDay is {0}.",
      SoapMonthDay::XsdType );
   //</snippet16>
}
//</snippet10>
