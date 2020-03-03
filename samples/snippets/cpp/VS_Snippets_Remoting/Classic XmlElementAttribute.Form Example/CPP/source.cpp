

#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Xml::Serialization;

// <Snippet1>
public ref class MyClass
{
public:

   [XmlElement(Form=XmlSchemaForm::Unqualified)]
   String^ ClassName;
};

// </Snippet1>
