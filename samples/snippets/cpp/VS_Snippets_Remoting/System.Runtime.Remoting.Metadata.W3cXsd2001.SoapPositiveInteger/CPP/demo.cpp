/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapPositiveInteger
///    10    class
///    21    #ctor()
///    22    #ctor(Decimal)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType
///    Bugs in SoapPositiveInteger:
///    No bugs were detected.
//<snippet10>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD formatted string to create a SoapPositiveInteger
   // object.
   String^ xsdIntegerString = L"+13";
   SoapPositiveInteger^ xsdInteger =
      SoapPositiveInteger::Parse( xsdIntegerString );
   //</snippet11>

   //<snippet12>
   // Print the value of the SoapPositiveInteger object in XSD format.
   Console::WriteLine( L"The SoapPositiveInteger object in XSD format is {0}.",
      xsdInteger );
   //</snippet12>

   //<snippet13>
   // Print the XSD type string of the SoapPositiveInteger object.
   Console::WriteLine( L"The XSD type of the SoapPositiveInteger "
   L"object is {0}.", xsdInteger->GetXsdType() );
   //</snippet13>

   //<snippet14>
   // Print the value of the SoapPositiveInteger object.
   Console::WriteLine( L"The value of the SoapPositiveInteger object is {0}.",
      xsdInteger->Value );
   //</snippet14>

   //<snippet16>
   // Print the XSD type string of the SoapPositiveInteger class.
   Console::WriteLine( L"The XSD type of the SoapPositiveInteger class "
   L"is {0}.", SoapPositiveInteger::XsdType );
   //</snippet16>
}
//</snippet10>
