//<snippet1>
#using <mscorlib.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

class XmlSchemaExamples
{
public:

    static void Main()
    {
        XmlSchema^ schema = gcnew XmlSchema();

        // <xs:element name="stringElementWithAnyAttribute">
        XmlSchemaElement^ element = gcnew XmlSchemaElement();
        schema->Items->Add(element);
        element->Name = "stringElementWithAnyAttribute";

        // <xs:complexType>
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();
        element->SchemaType = complexType;

        // <xs:simpleContent>
        XmlSchemaSimpleContent^ simpleContent = gcnew XmlSchemaSimpleContent();
        complexType->ContentModel = simpleContent;

        // <extension base= "xs:string">
        XmlSchemaSimpleContentExtension^ extension = gcnew XmlSchemaSimpleContentExtension();
        simpleContent->Content = extension;
        extension->BaseTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:anyAttribute namespace="##targetNamespace"/>
        XmlSchemaAnyAttribute^ anyAttribute = gcnew XmlSchemaAnyAttribute();
        extension->AnyAttribute = anyAttribute;
        anyAttribute->Namespace = "##targetNamespace";

        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallbackOne);
        schemaSet->Add(schema);
        schemaSet->Compile();

        XmlSchema^ compiledSchema;

        for each (XmlSchema^ schema1 in schemaSet->Schemas())
        {
            compiledSchema = schema1;
        }

        XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager(gcnew NameTable());
        nsmgr->AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
		compiledSchema->Write(Console::Out, nsmgr);
    }

    static void ValidationCallbackOne(Object^ sender, ValidationEventArgs^ args)
    {
		Console::WriteLine(args->Message);
    }
};

int main()
{
	XmlSchemaExamples::Main();
    return 0;
};
//</snippet1>