//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class ImportIncludeSample
{
private:
    static void ValidationCallBack(Object^ sender, ValidationEventArgs^ args)
    {

		if (args->Severity == XmlSeverityType::Warning)
            Console::Write("WARNING: ");
        else if (args->Severity == XmlSeverityType::Error)
            Console::Write("ERROR: ");

        Console::WriteLine(args->Message);
    }

public:
    static void Main()
    {
        XmlSchema^ schema = gcnew XmlSchema();
		schema->ElementFormDefault = XmlSchemaForm::Qualified;
        schema->TargetNamespace = "http://www.w3.org/2001/05/XMLInfoset";

        // <xs:import namespace="http://www.example.com/IPO" />                            
        XmlSchemaImport^ import = gcnew XmlSchemaImport();
        import->Namespace = "http://www.example.com/IPO";
        schema->Includes->Add(import);

        // <xs:include schemaLocation="example.xsd" />               
        XmlSchemaInclude^ include = gcnew XmlSchemaInclude();
        include->SchemaLocation = "example.xsd";
        schema->Includes->Add(include);

        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallBack);
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
	ImportIncludeSample::Main();
	return 0;
}
//</snippet1>