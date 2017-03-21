#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   // Parse an XSD gMonthDay to create a SoapMonthDay object.
   // Parse the representation for February 21, in the UTC+8 time zone.
   String^ xsdMonthDay = L"--02-21+08:00";
   SoapMonthDay^ monthDay = SoapMonthDay::Parse( xsdMonthDay );

   // Print the monthDay in XSD format.
   Console::WriteLine( L"The SoapMonthDay object in XSD format is {0}.",
      monthDay );

   // Print the XSD type string of this particular SoapMonthDay object.
   Console::WriteLine( L"The XSD type of the SoapMonthDay object is {0}.",
      monthDay->GetXsdType() );

   // Print the value of the SoapMonthDay object.
   Console::WriteLine( L"The value of the SoapMonthDay object is {0}.",
      monthDay->Value );

   // Print the XSD type string of the SoapMonthDay class.
   Console::WriteLine( L"The XSD type of the class SoapMonthDay is {0}.",
      SoapMonthDay::XsdType );
}