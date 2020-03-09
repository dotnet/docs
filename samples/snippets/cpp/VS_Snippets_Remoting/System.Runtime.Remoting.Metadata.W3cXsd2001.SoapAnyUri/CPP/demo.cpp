/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapAnyUri
///    10    class
///    21    #ctor()
///    22    #ctor(string)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType
///
///    Bugs in SoapAnyUri: None found.
//<snippet10>
#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD formatted string to create a SoapAnyUri object.
   String^ xsdAnyUri = L"http://localhost:8080/WebService";
   SoapAnyUri^ anyUri = SoapAnyUri::Parse( xsdAnyUri );
   //</snippet11>

   //<snippet12>
   // Print the value of the SoapAnyUri object in XSD format.
   Console::WriteLine( L"The SoapAnyUri object in XSD format is {0}.", anyUri );
   //</snippet12>

   //<snippet13>
   // Print the XSD type string of the SoapAnyUri object.
   Console::WriteLine( L"The XSD type of the SoapAnyUri "
   L"object is {0}.", anyUri->GetXsdType() );
   //</snippet13>

   //<snippet14>
   // Print the value of the SoapAnyUri object.
   Console::WriteLine( L"The value of the SoapAnyUri object is {0}.", anyUri->Value );
   
   //</snippet14>
   //<snippet16>
   // Print the XSD type string of the SoapAnyUri class.
   Console::WriteLine( L"The XSD type of the SoapAnyUri class "
   L"is {0}.", SoapAnyUri::XsdType );
   //</snippet16>

   return 1;
}
//</snippet10>
