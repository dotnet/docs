//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XmlSchemaReadWriteExample
{
public:

    static void Main()
    {
        try
        {
            XmlTextReader^ reader = gcnew XmlTextReader("example.xsd");
			ValidationEventHandler^ eventHandler = gcnew ValidationEventHandler(ValidationCallback);
			XmlSchema^ myschema = XmlSchema::Read(reader, eventHandler);
            myschema->Write(Console::Out);
            FileStream^ file = gcnew FileStream("new.xsd", FileMode::Create, FileAccess::ReadWrite);
            XmlTextWriter^ xwriter = gcnew XmlTextWriter(file, gcnew UTF8Encoding());
            xwriter->Formatting = Formatting::Indented;
            myschema->Write(xwriter);
        }
        catch(Exception^ e)
        {
            Console::WriteLine(e);
        }
    }

    static void ValidationCallback(Object^ sender, ValidationEventArgs^ args)
    {
        if (args->Severity == XmlSeverityType::Warning)
            Console::Write("WARNING: ");
        else if (args->Severity == XmlSeverityType::Error)
			Console::Write("ERROR: ");

		Console::WriteLine(args->Message);
    }
};

int main()
{
	XmlSchemaReadWriteExample::Main();
    return 0;
};
//</snippet1>