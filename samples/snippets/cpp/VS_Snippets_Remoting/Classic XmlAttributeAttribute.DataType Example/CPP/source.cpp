

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class Group
{
public:

   [XmlAttributeAttribute(DataType="string")]
   String^ Name;

   [XmlAttributeAttribute(DataType="base64Binary")]
   array<Byte>^Hex64Code;
};

// </Snippet1>
