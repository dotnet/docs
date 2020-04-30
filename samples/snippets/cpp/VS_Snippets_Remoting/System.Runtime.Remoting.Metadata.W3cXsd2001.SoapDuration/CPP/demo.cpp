/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDuration
///    10    class
///    !    #ctor
///    11    Parse()
///    12    ToString()
///    13    XsdType
///
///    Bug report:
///    The constructor is unusable since all methods are static.
//<snippet10>
#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD duration to create a TimeSpan object.
   // This is a duration of 2 years, 3 months, 9 days, 12 hours,
   // 35 minutes, 20 seconds, and 10 milliseconds.
   String^ xsdDuration = L"P2Y3M9DT12H35M20.0100000S";
   TimeSpan timeSpan = SoapDuration::Parse( xsdDuration );
   Console::WriteLine( L"The time span contains {0} days.",
      timeSpan.Days );
   Console::WriteLine( L"The time span contains {0} hours.",
      timeSpan.Hours );
   Console::WriteLine( L"The time span contains {0} minutes.",
      timeSpan.Minutes );
   Console::WriteLine( L"The time span contains {0} seconds.",
      timeSpan.Seconds );
   //</snippet11>

   //<snippet12>
   // Serialize a TimeSpan object as an XSD duration string.
   // This object represents a time span of 399 days, 12 hours,
   // 35 minutes, 20 seconds, and 10 milliseconds.
   TimeSpan duration = TimeSpan(399,12,35,20,10);
   Console::WriteLine( L"The duration in XSD format is {0}.",
      SoapDuration::ToString( duration ) );
   //</snippet12>

   //<snippet13>
   // Print the XSD type string of the SoapDuration class.
   Console::WriteLine( L"The XSD type of SoapDuration is {0}.",
      SoapDuration::XsdType );
   //</snippet13>
}
//</snippet10>
