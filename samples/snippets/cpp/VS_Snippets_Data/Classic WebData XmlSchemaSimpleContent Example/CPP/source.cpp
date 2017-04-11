//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

class XMLSchemaExamples
{

private:
	static void ValidationCallbackOne(Object^ sender, ValidationEventArgs^ args)
    {
		Console::WriteLine(args->Message);
    }

public:
    static void Main()
    {
        XmlSchema^ schema = gcnew XmlSchema();

        // <xs:element name="generalPrice">
        XmlSchemaElement^ generalPrice = gcnew XmlSchemaElement();
        generalPrice->Name = "generalPrice";

        // <xs:complexType>
        XmlSchemaComplexType^ ct = gcnew XmlSchemaComplexType();

        // <xs:simpleContent>
        XmlSchemaSimpleContent^ simpleContent = gcnew XmlSchemaSimpleContent();

        // <xs:extension base="xs:decimal">
        XmlSchemaSimpleContentExtension^ simpleContent_extension = gcnew XmlSchemaSimpleContentExtension();
        simpleContent_extension->BaseTypeName = gcnew XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema");

        // <xs:attribute name="currency" type="xs:string" />
        XmlSchemaAttribute^ currency = gcnew XmlSchemaAttribute();
        currency->Name = "currency";
        currency->SchemaTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        simpleContent_extension->Attributes->Add(currency);

        simpleContent->Content = simpleContent_extension;
        ct->ContentModel = simpleContent;
        generalPrice->SchemaType = ct;

        schema->Items->Add(generalPrice);

        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallbackOne);
        schemaSet->Add(schema);
        schemaSet->Compile();

        XmlSchema^ compiledSchema = nullptr;

        for each (XmlSchema^ schema1 in schemaSet->Schemas())
        {
            compiledSchema = schema1;
        }

        XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager(gcnew NameTable());
        nsmgr->AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
		compiledSchema->Write(Console::Out, nsmgr);
    }
};

int main()
{
	XMLSchemaExamples::Main();
	return 0;
}
//</snippet1>