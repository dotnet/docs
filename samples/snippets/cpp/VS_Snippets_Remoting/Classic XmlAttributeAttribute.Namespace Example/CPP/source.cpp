

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class Car
{
public:

   [XmlAttributeAttribute(Namespace="Make")]
   String^ MakerName;

   [XmlAttributeAttribute(Namespace="Model")]
   String^ ModelName;
};

// </Snippet1>
