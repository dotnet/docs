#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XmlSchemaInferenceExamples
{
public:

    static void Main()
    {

    }

    static void XmlSchemaInference_OverallExample()
    {
        //<snippet1>
		XmlReader^ reader = XmlReader::Create("contosoBooks.xml");
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        XmlSchemaInference^ schema = gcnew XmlSchemaInference();

        schemaSet = schema->InferSchema(reader);

        for each (XmlSchema^ s in schemaSet->Schemas())
        {
            s->Write(Console::Out);
        }
        //</snippet1>
    }

    static void XmlSchemaInference_Occurrence()
    {
        //<snippet2>
		XmlReader^ reader = XmlReader::Create("input.xml");
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        XmlSchemaInference^ schema = gcnew XmlSchemaInference();

		schema->Occurrence = XmlSchemaInference::InferenceOption::Relaxed;

        schemaSet = schema->InferSchema(reader);

        for each (XmlSchema^ s in schemaSet->Schemas())
        {
            s->Write(Console::Out);
        }
        //</snippet2>
    }

    static void XmlSchemaInference_TypeInference()
    {
        //<snippet3>
		XmlReader^ reader = XmlReader::Create("input.xml");
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        XmlSchemaInference^ schema = gcnew XmlSchemaInference();

		schema->TypeInference = XmlSchemaInference::InferenceOption::Relaxed;

        schemaSet = schema->InferSchema(reader);

        for each (XmlSchema^ s in schemaSet->Schemas())
        {
            s->Write(Console::Out);
        }
        //</snippet3>
    }

    static void XmlSchemaInference_RefinementProcess()
    {
        //<snippet4>
		XmlReader^ reader = XmlReader::Create("item1.xml");
        XmlReader^ reader1 = XmlReader::Create("item2.xml");
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        XmlSchemaInference^ inference = gcnew XmlSchemaInference();
        schemaSet = inference->InferSchema(reader);

        // Display the inferred schema.
        Console::WriteLine("Original schema:\n");
        for each (XmlSchema^ schema in schemaSet->Schemas("http://www.contoso.com/items"))
        {
            schema->Write(Console::Out);
        }

        // Use the additional data in item2.xml to refine the original schema.
        schemaSet = inference->InferSchema(reader1, schemaSet);

        // Display the refined schema.
        Console::WriteLine("\n\nRefined schema:\n");
        for each (XmlSchema^ schema in schemaSet->Schemas("http://www.contoso.com/items"))
        {
            schema->Write(Console::Out);
        }
        //</snippet4>
    }
};

int main()
{
	XmlSchemaInferenceExamples::Main();
    return 0;
}
