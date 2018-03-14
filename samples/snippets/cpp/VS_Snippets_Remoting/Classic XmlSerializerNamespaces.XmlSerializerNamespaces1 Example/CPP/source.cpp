#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Sample
{
   // <Snippet1>
private:
   XmlSerializerNamespaces^ CreateFromQNames()
   {
      XmlQualifiedName^ q1 =
         gcnew XmlQualifiedName( "money","http://www.cohowinery.com" );

      XmlQualifiedName^ q2 =
         gcnew XmlQualifiedName( "books","http://www.cpandl.com" );

      array<XmlQualifiedName^>^ names = { q1, q2 };

      return gcnew XmlSerializerNamespaces( names );
   }
   // </Snippet1>
};
