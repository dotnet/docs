

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>

[XmlType(IncludeInSchema=false)]
public ref class ExtraneousInfo{};

// </Snippet1>
