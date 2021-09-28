

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class MyClass
{
public:

   [XmlArray(IsNullable=true)]
   array<String^>^IsNullableIsTrueArray;

   [XmlArray(IsNullable=false)]
   array<String^>^IsNullableIsFalseArray;
};

// </Snippet1>
