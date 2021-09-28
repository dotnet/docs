/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNonNegativeInteger
///    10    class
///    21    #ctor()
///    22    #ctor(Decimal)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType
///    Bugs in SoapNonNegativeInteger:
///    No bugs were detected.
//<snippet10>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD formatted string to create a SoapNonNegativeInteger
   // object.
   String^ xsdIntegerString = L"+13";
   SoapNonNegativeInteger^ xsdInteger = SoapNonNegativeInteger::Parse(
      xsdIntegerString );
   //</snippet11>

   //<snippet12>
   // Print the value of the SoapNonNegativeInteger object
   // in XSD format.
   Console::WriteLine( 
      L"The SoapNonNegativeInteger object in XSD format is {0}.",
      xsdInteger );
   //</snippet12>

   //<snippet13>
   // Print the XSD type string of the SoapNonNegativeInteger object.
   Console::WriteLine( L"The XSD type of the SoapNonNegativeInteger "
   L"object is {0}.", xsdInteger->GetXsdType() );
   //</snippet13>

   //<snippet14>
   // Print the value of the SoapNonNegativeInteger object.
   Console::WriteLine( L"The value of the SoapNonNegativeInteger "
   L"object is {0}.", xsdInteger->Value );
   //</snippet14>

   //<snippet16>
   // Print the XSD type string of the SoapNonNegativeInteger class.
   Console::WriteLine( L"The XSD type of the SoapNonNegativeInteger class "
   L"is {0}.", SoapNonNegativeInteger::XsdType );
   //</snippet16>
}

//</snippet10>
