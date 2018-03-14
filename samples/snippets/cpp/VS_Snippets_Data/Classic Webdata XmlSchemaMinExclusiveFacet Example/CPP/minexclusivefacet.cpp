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

        // <xs:simpleType name="OrderQuantityType">
        XmlSchemaSimpleType^ OrderQuantityType = gcnew XmlSchemaSimpleType();
        OrderQuantityType->Name = "OrderQuantityType";

        // <xs:restriction base="xs:int">
        XmlSchemaSimpleTypeRestriction^ restriction = gcnew XmlSchemaSimpleTypeRestriction();
        restriction->BaseTypeName = gcnew XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");

        // <xs:minExclusive value="5"/>
        XmlSchemaMinExclusiveFacet^ MinExclusive = gcnew XmlSchemaMinExclusiveFacet();
        MinExclusive->Value = "5";
        restriction->Facets->Add(MinExclusive);

        OrderQuantityType->Content = restriction;

        schema->Items->Add(OrderQuantityType);

        // <xs:element name="item">
        XmlSchemaElement^ element = gcnew XmlSchemaElement();
        element->Name = "item";

        // <xs:complexType>
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();

        // <xs:attribute name="OrderQuantity" type="OrderQuantityType"/>
        XmlSchemaAttribute^ OrderQuantityAttribute = gcnew XmlSchemaAttribute();
        OrderQuantityAttribute->Name = "OrderQuantity";
        OrderQuantityAttribute->SchemaTypeName = gcnew XmlQualifiedName("OrderQuantityType", "");
        complexType->Attributes->Add(OrderQuantityAttribute);

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