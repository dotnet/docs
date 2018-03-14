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

        // <element name='htmlText'>
        XmlSchemaElement^ xeHtmlText = gcnew XmlSchemaElement();
        xeHtmlText->Name = "htmlText";

        // <complexType>
        XmlSchemaComplexType^ ct = gcnew XmlSchemaComplexType();

        // <sequence>
        XmlSchemaSequence^ sequence = gcnew XmlSchemaSequence();

        // <any namespace='http://www.w3.org/1999/xhtml'
        //    minOccurs='1' maxOccurs='unbounded'
        //    processContents='lax'/>
        XmlSchemaAny^ any = gcnew XmlSchemaAny();
        any->MinOccurs = 1;
        any->MaxOccursString = "unbounded";
        any->Namespace = "http://www.w3.org/1999/xhtml";
		any->ProcessContents = XmlSchemaContentProcessing::Lax;
        sequence->Items->Add(any);

        ct->Particle = sequence;
        xeHtmlText->SchemaType = ct;

        schema->Items->Add(xeHtmlText);

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
		schema->Write(Console::Out, nsmgr);
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