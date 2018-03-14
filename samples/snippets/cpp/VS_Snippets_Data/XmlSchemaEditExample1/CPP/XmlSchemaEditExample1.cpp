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

        // Create the PhoneNumber element.
        XmlSchemaElement^ phoneElement = gcnew XmlSchemaElement();
        phoneElement->Name = "PhoneNumber";

        // Create the xs:string simple type restriction.
        XmlSchemaSimpleType^ phoneType = gcnew XmlSchemaSimpleType();
        XmlSchemaSimpleTypeRestriction^ restriction =
            gcnew XmlSchemaSimpleTypeRestriction();
        restriction->BaseTypeName = gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // Add a pattern facet to the restriction.
        XmlSchemaPatternFacet^ phonePattern = gcnew XmlSchemaPatternFacet();
        phonePattern->Value = "\\d{3}-\\d{3}-\\d(4)";
        restriction->Facets->Add(phonePattern);

        // Add the restriction to the Content property of the simple type
        // and the simple type to the SchemaType of the PhoneNumber element.
        phoneType->Content = restriction;
        phoneElement->SchemaType = phoneType;

        // Iterate over each XmlSchemaElement in the Values collection
        // of the Elements property.
        for each (XmlSchemaElement^ element in customerSchema->Elements->Values)
        {
            // If the qualified name of the element is "Customer", 
            // get the complex type of the Customer element  
            // and the sequence particle of the complex type.
            if (element->QualifiedName->Name->Equals("Customer"))
            {
                XmlSchemaComplexType^ customerType =
                    dynamic_cast<XmlSchemaComplexType^>(element->ElementSchemaType);
                XmlSchemaSequence^ sequence =
                    dynamic_cast<XmlSchemaSequence^>(customerType->Particle);

                // Add the new PhoneNumber element to the sequence.
                sequence->Items->Add(phoneElement);
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