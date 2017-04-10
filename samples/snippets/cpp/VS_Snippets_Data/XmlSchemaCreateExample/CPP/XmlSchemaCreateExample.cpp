//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

ref class XmlSchemaCreateExample
{
public:

    static void Main()
    {
        //<snippet2>
        // Create the FirstName and LastName elements.
        XmlSchemaElement^ firstNameElement = gcnew XmlSchemaElement();
        firstNameElement->Name = "FirstName";
        XmlSchemaElement^ lastNameElement = gcnew XmlSchemaElement();
        lastNameElement->Name = "LastName";

        // Create CustomerId attribute.
        XmlSchemaAttribute^ idAttribute = gcnew XmlSchemaAttribute();
        idAttribute->Name = "CustomerId";
		idAttribute->Use = XmlSchemaUse::Required;
        //</snippet2>

        //<snippet3>
        // Create the simple type for the LastName element.
        XmlSchemaSimpleType^ lastNameType = gcnew XmlSchemaSimpleType();
        lastNameType->Name = "LastNameType";
        XmlSchemaSimpleTypeRestriction^ lastNameRestriction =
            gcnew XmlSchemaSimpleTypeRestriction();
        lastNameRestriction->BaseTypeName =
            gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        XmlSchemaMaxLengthFacet^ maxLength = gcnew XmlSchemaMaxLengthFacet();
        maxLength->Value = "20";
        lastNameRestriction->Facets->Add(maxLength);
        lastNameType->Content = lastNameRestriction;

        // Associate the elements and attributes with their types.
        // Built-in type.
        firstNameElement->SchemaTypeName =
            gcnew XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        // User-defined type.
        lastNameElement->SchemaTypeName =
            gcnew XmlQualifiedName("LastNameType", "http://www.tempuri.org");
        // Built-in type.
        idAttribute->SchemaTypeName = gcnew XmlQualifiedName("positiveInteger",
            "http://www.w3.org/2001/XMLSchema");
        
        // Create the top-level Customer element.
        XmlSchemaElement^ customerElement = gcnew XmlSchemaElement();
        customerElement->Name = "Customer";

        // Create an anonymous complex type for the Customer element.
        XmlSchemaComplexType^ customerType = gcnew XmlSchemaComplexType();
        XmlSchemaSequence^ sequence = gcnew XmlSchemaSequence();
        sequence->Items->Add(firstNameElement);
        sequence->Items->Add(lastNameElement);
        customerType->Particle = sequence;
        
        // Add the CustomerId attribute to the complex type.
        customerType->Attributes->Add(idAttribute);

        // Set the SchemaType of the Customer element to
        // the anonymous complex type created above.
        customerElement->SchemaType = customerType;
        //</snippet3>
        
        //<snippet4>
        // Create an empty schema.
        XmlSchema^ customerSchema = gcnew XmlSchema();
        customerSchema->TargetNamespace = "http://www.tempuri.org";

        // Add all top-level element and types to the schema
        customerSchema->Items->Add(customerElement);
        customerSchema->Items->Add(lastNameType);

        // Create an XmlSchemaSet to compile the customer schema.
        XmlSchemaSet^ schemaSet = gcnew XmlSchemaSet();
        schemaSet->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallback);
        schemaSet->Add(customerSchema);
        schemaSet->Compile();
        
        for each (XmlSchema^ schema in schemaSet->Schemas())
        {
            customerSchema = schema;
        }

        // Write the complete schema to the Console.
        customerSchema->Write(Console::Out);
        //</snippet4>
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
	XmlSchemaCreateExample::Main();
    return 0;
}
//</snippet1>