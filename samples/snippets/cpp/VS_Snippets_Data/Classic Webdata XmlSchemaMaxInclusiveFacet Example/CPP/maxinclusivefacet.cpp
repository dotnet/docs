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

        // <xs:simpleType name="WaitQueueLengthType">
        XmlSchemaSimpleType^ WaitQueueLengthType = gcnew XmlSchemaSimpleType();
        WaitQueueLengthType->Name = "WaitQueueLengthType";

        // <xs:restriction base="xs:int">
        XmlSchemaSimpleTypeRestriction^ restriction = gcnew XmlSchemaSimpleTypeRestriction();
        restriction->BaseTypeName = gcnew XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");

        // <xs:maxInclusive value="5"/>
        XmlSchemaMaxInclusiveFacet^ maxInclusive = gcnew XmlSchemaMaxInclusiveFacet();
        maxInclusive->Value = "5";
        restriction->Facets->Add(maxInclusive);

        WaitQueueLengthType->Content = restriction;

        schema->Items->Add(WaitQueueLengthType);

        // <xs:element name="Lobby">
        XmlSchemaElement^ element = gcnew XmlSchemaElement();
        element->Name = "Lobby";

        // <xs:complexType>
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();

        // <xs:attribute name="WaitQueueLength" type="WaitQueueLengthType"/>
        XmlSchemaAttribute^ WaitQueueLengthAttribute = gcnew XmlSchemaAttribute();
        WaitQueueLengthAttribute->Name = "WaitQueueLength";
        WaitQueueLengthAttribute->SchemaTypeName = gcnew XmlQualifiedName("WaitQueueLengthType", "");
        complexType->Attributes->Add(WaitQueueLengthAttribute);

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