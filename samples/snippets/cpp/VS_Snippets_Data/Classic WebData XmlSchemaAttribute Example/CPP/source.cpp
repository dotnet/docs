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

        // <xs:attribute name="mybaseattribute">
        XmlSchemaAttribute^ attributeBase = gcnew XmlSchemaAttribute();
        schema->Items->Add(attributeBase);
        attributeBase->Name = "mybaseattribute";

        // <xs:simpleType>
        XmlSchemaSimpleType^ simpleType = gcnew XmlSchemaSimpleType();
        attributeBase->SchemaType = simpleType;

        // <xs:restriction base="integer">
        XmlSchemaSimpleTypeRestriction^ restriction = gcnew XmlSchemaSimpleTypeRestriction();
        simpleType->Content = restriction;
        restriction->BaseTypeName = gcnew XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");

        // <xs:maxInclusive value="1000"/>
        XmlSchemaMaxInclusiveFacet^ maxInclusive = gcnew XmlSchemaMaxInclusiveFacet();
        restriction->Facets->Add(maxInclusive);
        maxInclusive->Value = "1000";

        // <xs:complexType name="myComplexType">
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();
        schema->Items->Add(complexType);
        complexType->Name = "myComplexType";

        // <xs:attribute ref="mybaseattribute"/>
        XmlSchemaAttribute^ attributeBaseRef = gcnew XmlSchemaAttribute();
        complexType->Attributes->Add(attributeBaseRef);
        attributeBaseRef->RefName = gcnew XmlQualifiedName("mybaseattribute");

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