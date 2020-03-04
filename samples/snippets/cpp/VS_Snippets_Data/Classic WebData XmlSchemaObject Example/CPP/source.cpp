//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Reflection;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class ValidXSD
{
private:
	static void DisplayObjects(Object^ o)
    {
        DisplayObjects(o, "");
    }

    static void DisplayObjects(Object^ o, String^ indent)
    {
        Console::WriteLine("{0}{1}", indent, o);

        for each (PropertyInfo^ property1 in o->GetType()->GetProperties())
        {
            if (property1->PropertyType->FullName == "System.Xml.Schema.XmlSchemaObjectCollection")
            {
                XmlSchemaObjectCollection^ childObjectCollection = dynamic_cast<XmlSchemaObjectCollection^>(property1->GetValue(o, nullptr));

                for each (XmlSchemaObject^ schemaObject in childObjectCollection)
                {
                    DisplayObjects(schemaObject, indent + "\t");
                }
            }
        }
    }

    static void ShowCompileError(Object^ sender, ValidationEventArgs^ e)
    {
        Console::WriteLine("Validation Error: {0}", e->Message);
    }

public:
	static int Main()
    {
        String^ xsd = "example.xsd";

        FileStream^ fs;
        XmlSchema^ schema;
        try
        {
			fs = gcnew FileStream(xsd, FileMode::Open);
			schema = XmlSchema::Read(fs, gcnew ValidationEventHandler(ShowCompileError));

            XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
            schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ShowCompileError);
            schemaSet->Add(schema);
            schemaSet->Compile();

            XmlSchema^ compiledSchema = nullptr;

            for each (XmlSchema^ schema1 in schemaSet->Schemas())
            {
                compiledSchema = schema1;
            }

            schema = compiledSchema;

            if (schema->IsCompiled)
            {
                DisplayObjects(schema);
            }
            return 0;
        }
        catch (XmlSchemaException^ e)
        {
            Console::WriteLine("LineNumber = {0}", e->LineNumber);
            Console::WriteLine("LinePosition = {0}", e->LinePosition);
            Console::WriteLine("Message = {0}", e->Message);
            Console::WriteLine("Source = {0}", e->Source);
            return -1;
        }
    }
};

int main()
{
	ValidXSD::Main();
	return 0;
}
//</snippet1>