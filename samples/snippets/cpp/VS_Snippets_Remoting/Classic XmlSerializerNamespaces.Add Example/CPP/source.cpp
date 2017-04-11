#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Sample
{
   // <Snippet1>
private:
   XmlSerializerNamespaces^ AddNamespaces()
   {
      XmlSerializerNamespaces^ xmlNamespaces =
         gcnew XmlSerializerNamespaces;
      
      // Add three prefix-namespace pairs.
      xmlNamespaces->Add( "money", "http://www.cpandl.com" );
      xmlNamespaces->Add( "books", "http://www.cohowinery.com" );
      xmlNamespaces->Add( "software", "http://www.microsoft.com" );

      return xmlNamespaces;
   }
   // </Snippet1>
};
