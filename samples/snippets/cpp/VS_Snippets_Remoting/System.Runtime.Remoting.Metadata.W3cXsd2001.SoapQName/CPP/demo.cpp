/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName
///    10    class
///    21    #ctor()
///    22    #ctor(string)
///    23    #ctor(string,string)
///    24    #ctor(string,string,string)
///    13    GetXsdType()
///    17    Key
///    18    Name
///    19    Namespace
///    11    Parse()
///    12    ToString()
///    16    XsdType
///
///    Bugs in SoapQName:
///    1. SoapQName.Namespace is not used anywhere. The field exists but has
///    no clear purpose. It cannot be parsed.
///    2. SoapQName.Name cannot contain a ':', however, this is not validated
///    in the code anywhere. SoapQName.Parse("a:b:c").Name results in "b:c",
///    which is an invalid name.
//<snippet10>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata::W3cXsd2001;

int main()
{
   //<snippet11>
   // Parse an XSD formatted string to create a SoapQName object.
   String^ xsdQName = L"tns:SomeName";
   SoapQName^ qName = SoapQName::Parse( xsdQName );
   //</snippet11>

   //<snippet12>
   // Print the value of the SoapQName object in XSD format.
   Console::WriteLine( L"The SoapQName object in XSD format is {0}.", qName );
   //</snippet12>

   //<snippet13>
   // Print the XSD type string of the SoapQName object.
   Console::WriteLine( L"The XSD type of the SoapQName "
   L"object is {0}.", qName->GetXsdType() );
   //</snippet13>

   //<snippet16>
   // Print the XSD type string of the SoapQName class.
   Console::WriteLine( L"The XSD type of the SoapQName class "
   L"is {0}.", SoapQName::XsdType );
   //</snippet16>

   // Create a QName object.
   SoapQName^ soapQNameInstance = gcnew SoapQName(
      L"tns",L"SomeName",L"http://example.org" );
   
   //<snippet17>
   // Print the key the SoapQName object.
   Console::WriteLine( L"The key of the SoapQName object is {0}.",
      soapQNameInstance->Key );
   //</snippet17>

   //<snippet18>
   // Print the name of the SoapQName object.
   Console::WriteLine( L"The name of the SoapQName "
   L"object is {0}.", soapQNameInstance->Name );
   //</snippet18>

   //<snippet19>
   // Print the namespace of the SoapQName class.
   Console::WriteLine( L"The namespace for this instance of SoapQName is {0}.",
      soapQNameInstance->Namespace );
   //</snippet19>
}
//</snippet10>
