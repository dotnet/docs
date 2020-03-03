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
        XmlTextReader^ xtr = gcnew XmlTextReader("example.xsd");
		XmlSchema^ schema = XmlSchema::Read(xtr, gcnew ValidationEventHandler(ValidationCallbackOne));

        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallbackOne);
        schemaSet->Add(schema);
        schemaSet->Compile();

        XmlSchema^ compiledSchema;

        for each (XmlSchema^ schema1 in schemaSet->Schemas())
        {
            compiledSchema = schema1;
        }

        for each (XmlSchemaObject^ schemaObject in compiledSchema->Items)
        {
			if (schemaObject->GetType() == XmlSchemaSimpleType::typeid)
            {
                XmlSchemaSimpleType^ simpleType = dynamic_cast<XmlSchemaSimpleType^>(schemaObject);
				Console::WriteLine("{0} {1}", simpleType->Name, simpleType->Datatype->ValueType);
            }
			if (schemaObject->GetType() == XmlSchemaComplexType::typeid)
            {
                XmlSchemaComplexType^ complexType = dynamic_cast<XmlSchemaComplexType^>(schemaObject);
				Console::WriteLine("{0} {1}", complexType->Name, complexType->Datatype->ValueType);
            }
        }
        xtr->Close();
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