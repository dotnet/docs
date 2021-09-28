#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::IO;
using namespace System::Xml::Serialization;

// <Snippet1>
// This is the class that will be serialized.
public ref class XClass
{
public:
   /* The XML element name will be XName
   instead of the default ClassName. */
   [XmlElement(ElementName="XName")]
   String^ ClassName;
};
// </Snippet1>

int main(){}
