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

        // <xs:simpleType name="SizeType">
        XmlSchemaSimpleType^ SizeType = gcnew XmlSchemaSimpleType();
        SizeType->Name = "SizeType";

        // <xs:restriction base="xs:string">
        XmlSchemaSimpleTypeRestriction^ restriction = gcnew XmlSchemaSimpleTypeRestriction();
        restriction->BaseTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:enumeration value="Small"/>
        XmlSchemaEnumerationFacet^ enumerationSmall = gcnew XmlSchemaEnumerationFacet();
        enumerationSmall->Value = "Small";
        restriction->Facets->Add(enumerationSmall);

        // <xs:enumeration value="Medium"/>
        XmlSchemaEnumerationFacet^ enumerationMedium = gcnew XmlSchemaEnumerationFacet();
        enumerationMedium->Value = "Medium";
        restriction->Facets->Add(enumerationMedium);

        // <xs:enumeration value="Large"/>
        XmlSchemaEnumerationFacet^ enumerationLarge = gcnew XmlSchemaEnumerationFacet();
        enumerationLarge->Value = "Large";
        restriction->Facets->Add(enumerationLarge);

        SizeType->Content = restriction;

        schema->Items->Add(SizeType);

        // <xs:element name="Item">
        XmlSchemaElement^ elementItem = gcnew XmlSchemaElement();
        elementItem->Name = "Item";

        // <xs:complexType>
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();

        // <xs:attribute name="Size" type="SizeType"/>
        XmlSchemaAttribute^ attributeSize = gcnew XmlSchemaAttribute();
        attributeSize->Name = "Size";
        attributeSize->SchemaTypeName = gcnew XmlQualifiedName("SizeType", "");
        complexType->Attributes->Add(attributeSize);

        elementItem->SchemaType = complexType;

        schema->Items->Add(elementItem);

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