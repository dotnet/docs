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

        // <xs:element name="State">
        XmlSchemaElement^ element = gcnew XmlSchemaElement();
        schema->Items->Add(element);
        element->Name = "State";

        // <xs:annotation>
        XmlSchemaAnnotation^ annNorthwestStates = gcnew XmlSchemaAnnotation();
        element->Annotation = annNorthwestStates;

        // <xs:documentation>State Name</xs:documentation>
        XmlSchemaDocumentation^ docNorthwestStates = gcnew XmlSchemaDocumentation();
        annNorthwestStates->Items->Add(docNorthwestStates);
        docNorthwestStates->Markup = TextToNodeArray("State Name");

        // <xs:appInfo>Application Information</xs:appInfo>
        XmlSchemaAppInfo^ appInfo = gcnew XmlSchemaAppInfo();
        annNorthwestStates->Items->Add(appInfo);
        appInfo->Markup = TextToNodeArray("Application Information");

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
		array<XmlNode^>^ nodes = {doc->CreateTextNode(text)};
		return nodes;
    }
};

int main()
{
	XmlSchemaExamples::Main();
    return 0;
};
//</snippet1>
