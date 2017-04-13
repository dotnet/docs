//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XMLSchemaExamples
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

        // <xs:simpleType name="NameType">
        XmlSchemaSimpleType^ NameType = gcnew XmlSchemaSimpleType();
        NameType->Name = "NameType";

        // <xs:restriction base="xs:string">
        XmlSchemaSimpleTypeRestriction^ restriction = gcnew XmlSchemaSimpleTypeRestriction();
        restriction->BaseTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:whiteSpace value="collapse"/>
        XmlSchemaWhiteSpaceFacet^ whiteSpace = gcnew XmlSchemaWhiteSpaceFacet();
        whiteSpace->Value = "collapse";
        restriction->Facets->Add(whiteSpace);

        NameType->Content = restriction;

        schema->Items->Add(NameType);

        // <xs:element name="LastName" type="NameType"/>
        XmlSchemaElement^ element = gcnew XmlSchemaElement();
        element->Name = "LastName";
        element->SchemaTypeName = gcnew XmlQualifiedName("NameType", "");

        schema->Items->Add(element);

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