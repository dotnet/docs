//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XmlSchemaTraverseExample
{
public:

    static void Main()
    {
        // Add the customer schema to a new XmlSchemaSet and compile it.
        // Any schema validation warnings and errors encountered reading or 
        // compiling the schema are handled by the ValidationEventHandler delegate.
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallback);
        schemaSet->Add("http://www.tempuri.org", "customer.xsd");
        schemaSet->Compile();

        // Retrieve the compiled XmlSchema object from the XmlSchemaSet
        // by iterating over the Schemas property.
        XmlSchema^ customerSchema = nullptr;
        for each (XmlSchema^ schema in schemaSet->Schemas())
        {
            customerSchema = schema;
        }

        // Iterate over each XmlSchemaElement in the Values collection
        // of the Elements property.
        for each (XmlSchemaElement^ element in customerSchema->Elements->Values)
        {

            Console::WriteLine("Element: {0}", element->Name);

            // Get the complex type of the Customer element.
            XmlSchemaComplexType^ complexType = dynamic_cast<XmlSchemaComplexType^>(element->ElementSchemaType);

            // If the complex type has any attributes, get an enumerator 
            // and write each attribute name to the console.
            if (complexType->AttributeUses->Count > 0)
            {
                IDictionaryEnumerator^ enumerator =
                    complexType->AttributeUses->GetEnumerator();

                while (enumerator->MoveNext())
                {
                    XmlSchemaAttribute^ attribute =
                        dynamic_cast<XmlSchemaAttribute^>(enumerator->Value);

                    Console::WriteLine("Attribute: {0}", attribute->Name);
                }
            }

            // Get the sequence particle of the complex type.
            XmlSchemaSequence^ sequence = dynamic_cast<XmlSchemaSequence^>(complexType->ContentTypeParticle);

            // Iterate over each XmlSchemaElement in the Items collection.
            for each (XmlSchemaElement^ childElement in sequence->Items)
            {
                Console::WriteLine("Element: {0}", childElement->Name);
            }
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
	XmlSchemaTraverseExample::Main();
    return 0;
};
//</snippet1>