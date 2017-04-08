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

        //<xs:simpleType name="StringOrIntType">
        XmlSchemaSimpleType^ StringOrIntType = gcnew XmlSchemaSimpleType();
        StringOrIntType->Name = "StringOrIntType";
        schema->Items->Add(StringOrIntType);

        // <xs:union>
        XmlSchemaSimpleTypeUnion^ union1 = gcnew XmlSchemaSimpleTypeUnion();
        StringOrIntType->Content = union1;

        // <xs:simpleType>
        XmlSchemaSimpleType^ simpleType1 = gcnew XmlSchemaSimpleType();
        union1->BaseTypes->Add(simpleType1);

        // <xs:restriction base="xs:string"/>
        XmlSchemaSimpleTypeRestriction^ restriction1 = gcnew XmlSchemaSimpleTypeRestriction();
        restriction1->BaseTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        simpleType1->Content = restriction1;

        // <xs:simpleType>
        XmlSchemaSimpleType^ simpleType2 = gcnew XmlSchemaSimpleType();
        union1->BaseTypes->Add(simpleType2);

        // <xs:restriction base="xs:int"/>
        XmlSchemaSimpleTypeRestriction^ restriction2 = gcnew XmlSchemaSimpleTypeRestriction();
        restriction2->BaseTypeName = gcnew XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");
        simpleType2->Content = restriction2;


        // <xs:element name="size" type="StringOrIntType"/>
        XmlSchemaElement^ elementSize = gcnew XmlSchemaElement();
        elementSize->Name = "size";
        elementSize->SchemaTypeName = gcnew XmlQualifiedName("StringOrIntType");
        schema->Items->Add(elementSize);

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