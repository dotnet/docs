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

        // <xs:notation name="jpeg" public="image/jpeg" system="viewer.exe" />
        XmlSchemaNotation^ notation = gcnew XmlSchemaNotation();
        notation->Name = "jpeg";
        notation->Public = "image/jpeg";
        notation->System = "viewer.exe";

        schema->Items->Add(notation);

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