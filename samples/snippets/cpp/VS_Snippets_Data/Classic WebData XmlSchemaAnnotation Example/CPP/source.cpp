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

        // <xs:simpleType name="northwestStates">
        XmlSchemaSimpleType^ simpleType = gcnew XmlSchemaSimpleType();
        simpleType->Name = "northwestStates";
        schema->Items->Add(simpleType);

        // <xs:annotation>
        XmlSchemaAnnotation^ annNorthwestStates = gcnew XmlSchemaAnnotation();
        simpleType->Annotation = annNorthwestStates;

        // <xs:documentation>States in the Pacific Northwest of US</xs:documentation>
        XmlSchemaDocumentation^ docNorthwestStates = gcnew XmlSchemaDocumentation();
        annNorthwestStates->Items->Add(docNorthwestStates);
        docNorthwestStates->Markup = TextToNodeArray("States in the Pacific Northwest of US");

        // <xs:restriction base="xs:string">
        XmlSchemaSimpleTypeRestriction^ restriction = gcnew XmlSchemaSimpleTypeRestriction();
        simpleType->Content = restriction;
        restriction->BaseTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // <xs:enumeration value='WA'>
        XmlSchemaEnumerationFacet^ enumerationWA = gcnew XmlSchemaEnumerationFacet();
        restriction->Facets->Add(enumerationWA);
        enumerationWA->Value = "WA";

        // <xs:annotation>
        XmlSchemaAnnotation^ annWA = gcnew XmlSchemaAnnotation();
        enumerationWA->Annotation = annWA;

        // <xs:documentation>Washington</documentation>
        XmlSchemaDocumentation^ docWA = gcnew XmlSchemaDocumentation();
        annWA->Items->Add(docWA);
        docWA->Markup = TextToNodeArray("Washington");

        // <xs:enumeration value='OR'>
        XmlSchemaEnumerationFacet^ enumerationOR = gcnew XmlSchemaEnumerationFacet();
        restriction->Facets->Add(enumerationOR);
        enumerationOR->Value = "OR";

        // <xs:annotation>
        XmlSchemaAnnotation^ annOR = gcnew XmlSchemaAnnotation();
        enumerationOR->Annotation = annOR;

        // <xs:documentation>Oregon</xs:documentation>
        XmlSchemaDocumentation^ docOR = gcnew XmlSchemaDocumentation();
        annOR->Items->Add(docOR);
        docOR->Markup = TextToNodeArray("Oregon");

        // <xs:enumeration value='ID'>
        XmlSchemaEnumerationFacet^ enumerationID = gcnew XmlSchemaEnumerationFacet();

        restriction->Facets->Add(enumerationID);
        enumerationID->Value = "ID";

        // <xs:annotation>
        XmlSchemaAnnotation^ annID = gcnew XmlSchemaAnnotation();
        enumerationID->Annotation = annID;

        // <xs:documentation>Idaho</xs:documentation>
        XmlSchemaDocumentation^ docID = gcnew XmlSchemaDocumentation();
        annID->Items->Add(docID);
        docID->Markup = TextToNodeArray("Idaho");

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

	static array<XmlNode^>^ TextToNodeArray(String^ text)
    {
        XmlDocument^ doc = gcnew XmlDocument();
		array<XmlNode^>^ temp = {doc->CreateTextNode(text)};
        return temp;
    }

};

int main()
{
	XmlSchemaExamples::Main();
    return 0;
};
//</snippet1>