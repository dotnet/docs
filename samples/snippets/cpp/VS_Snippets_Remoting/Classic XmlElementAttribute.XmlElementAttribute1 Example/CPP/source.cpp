

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class Transportation
{
public:

   [XmlElement("Cars")]
   String^ Vehicles;
};

// </Snippet1>
