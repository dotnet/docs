

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class Vehicle
{
public:

   [XmlAttributeAttribute(Form=XmlSchemaForm::Qualified)]
   String^ Maker;

   [XmlAttributeAttribute(Form=XmlSchemaForm::Unqualified)]
   String^ ModelID;
};

// </Snippet1>
