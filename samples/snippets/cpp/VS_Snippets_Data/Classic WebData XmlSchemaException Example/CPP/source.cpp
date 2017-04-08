//<snippet1>
#using <mscorlib.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;

class ValidXsd
{
public:

    static void Main()
    {
        FileStream^ fs;
        XmlSchema^ schema;

        try
        {
			fs = gcnew FileStream("example.xsd", FileMode::Open);
			schema = XmlSchema::Read(fs, gcnew ValidationEventHandler(ShowCompileError));

            XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
            schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ShowCompileError);
            schemaSet->Add(schema);
            schemaSet->Compile();

            XmlSchema^ compiledSchema;

            for each (XmlSchema^ schema1 in schemaSet->Schemas())
            {
                compiledSchema = schema1;
            }

            schema = compiledSchema;

            if (schema->IsCompiled)
            {
                // Schema is successfully compiled. 
                // Do something with it here.

            }
        }
        catch (XmlSchemaException^ e)
        {
			Console::WriteLine("LineNumber = {0}", e->LineNumber);
			Console::WriteLine("LinePosition = {0}", e->LinePosition);
			Console::WriteLine("Message = {0}", e->Message);
        }

    }

    static void ShowCompileError(Object^ sender, ValidationEventArgs^ e)
    {
		Console::WriteLine("Validation Error: {0}", e->Message);
    }
};

int main()
{
	ValidXsd::Main();
	Console::ReadLine();
    return 0;
};
//</snippet1>