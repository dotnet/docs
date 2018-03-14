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

        // <xs:simpleType name="ZipCodeType">
        XmlSchemaSimpleType^ ZipCodeType = gcnew XmlSchemaSimpleType();
        ZipCodeType->Name = "ZipCodeType";

        // <xs:restriction base="xs:string">
        XmlSchemaSimpleTypeRestriction^ restriction = gcnew XmlSchemaSimpleTypeRestriction();
        restriction->BaseTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:minLength value="5"/>
        XmlSchemaMinLengthFacet^ minLength = gcnew XmlSchemaMinLengthFacet();
        minLength->Value = "5";
        restriction->Facets->Add(minLength);

        ZipCodeType->Content = restriction;

        schema->Items->Add(ZipCodeType);

        // <xs:element name="Address">
        XmlSchemaElement^ element = gcnew XmlSchemaElement();
        element->Name = "Address";

        // <xs:complexType>
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();

        // <xs:attribute name="ZipCode" type="ZipCodeType"/>
        XmlSchemaAttribute^ ZipCodeAttribute = gcnew XmlSchemaAttribute();
        ZipCodeAttribute->Name = "ZipCode";
        ZipCodeAttribute->SchemaTypeName = gcnew XmlQualifiedName("ZipCodeType", "");
        complexType->Attributes->Add(ZipCodeAttribute);

        element->SchemaType = complexType;

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