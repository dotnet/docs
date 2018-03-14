

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class MyClass
{
public:

   [XmlElement(IsNullable=false)]
   String^ Group;
};

// </Snippet1>
