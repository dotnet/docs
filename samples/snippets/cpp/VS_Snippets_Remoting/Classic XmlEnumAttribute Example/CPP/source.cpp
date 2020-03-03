

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public enum class EmployeeStatus
{
   [XmlEnum(Name = "Single")]
   One,
   [XmlEnum(Name = "Double")]
   Two,
   [XmlEnum(Name = "Triple")]
   Three
};

// </Snippet1>
