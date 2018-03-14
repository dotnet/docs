//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XmlSchemaEditExample
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

        // Create a complex type for the FirstName element.
        XmlSchemaComplexType^ complexType = gcnew XmlSchemaComplexType();
        complexType->Name = "FirstNameComplexType";
        
        // Create a simple content extension with a base type of xs:string.
        XmlSchemaSimpleContent^ simpleContent = gcnew XmlSchemaSimpleContent();
        XmlSchemaSimpleContentExtension^ simpleContentExtension =
            gcnew XmlSchemaSimpleContentExtension();
        simpleContentExtension->BaseTypeName =
            gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // Create the new Title attribute with a SchemaTypeName of xs:string
        // and add it to the simple content extension.
        XmlSchemaAttribute^ attribute = gcnew XmlSchemaAttribute();
        attribute->Name = "Title";
        attribute->SchemaTypeName =
            gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        simpleContentExtension->Attributes->Add(attribute);

        // Set the content model of the simple content to the simple content extension
        // and the content model of the complex type to the simple content.
        simpleContent->Content = simpleContentExtension;
        complexType->ContentModel = simpleContent;

        // Add the new complex type to the pre-schema-compilation Items collection.
        customerSchema->Items->Add(complexType);

        // Iterate over each XmlSchemaObject in the pre-schema-compilation
        // Items collection.
        for each (XmlSchemaObject^ schemaObject in customerSchema->Items)
        {
            // If the XmlSchemaObject is an element, whose QualifiedName
            // is "Customer", get the complex type of the Customer element
            // and the sequence particle of the complex type.
			if (schemaObject::typeid == XmlSchemaElement::typeid)
            {
                XmlSchemaElement^ element = dynamic_cast<XmlSchemaElement^>(schemaObject);

                if (element->QualifiedName->Name->Equals("Customer"))
                {
                    XmlSchemaComplexType^ customerType =
                        dynamic_cast<XmlSchemaComplexType^>(element->ElementSchemaType);

                    XmlSchemaSequence^ sequence =
                        dynamic_cast<XmlSchemaSequence^>(customerType->Particle);

                    // Iterate over each XmlSchemaParticle in the pre-schema-compilation
                    // Items property.
                    for each (XmlSchemaParticle^ particle in sequence->Items)
                    {
                        // If the XmlSchemaParticle is an element, who's QualifiedName
                        // is "FirstName", set the SchemaTypeName of the FirstName element
                        // to the new FirstName complex type.
						if (particle::typeid == XmlSchemaElement::typeid)
                        {
                            XmlSchemaElement^ childElement =
                                dynamic_cast<XmlSchemaElement^>(particle);

                            if (childElement->Name->Equals("FirstName"))
                            {
                                childElement->SchemaTypeName =
                                    gcnew XmlQualifiedName("FirstNameComplexType",
                                    "http://www.tempuri.org");
                            }
                        }
                    }
                }
            }
        }

        // Reprocess and compile the modified XmlSchema object and write it to the console.
        schemaSet->Reprocess(customerSchema);
        schemaSet->Compile();
        customerSchema->Write(Console::Out);
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
	XmlSchemaEditExample::Main();
    return 0;
}
//</snippet1>