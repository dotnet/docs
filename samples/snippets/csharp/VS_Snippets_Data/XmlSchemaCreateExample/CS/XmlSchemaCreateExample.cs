//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaCreateExample
{
    static void Main(string[] args)
    {
        //<snippet2>
        // Create the FirstName and LastName elements.
        XmlSchemaElement firstNameElement = new XmlSchemaElement();
        firstNameElement.Name = "FirstName";
        XmlSchemaElement lastNameElement = new XmlSchemaElement();
        lastNameElement.Name = "LastName";

        // Create CustomerId attribute.
        XmlSchemaAttribute idAttribute = new XmlSchemaAttribute();
        idAttribute.Name = "CustomerId";
        idAttribute.Use = XmlSchemaUse.Required;
        //</snippet2>

        //<snippet3>
        // Create the simple type for the LastName element.
        XmlSchemaSimpleType lastNameType = new XmlSchemaSimpleType();
        lastNameType.Name = "LastNameType";
        XmlSchemaSimpleTypeRestriction lastNameRestriction =
            new XmlSchemaSimpleTypeRestriction();
        lastNameRestriction.BaseTypeName =
            new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        XmlSchemaMaxLengthFacet maxLength = new XmlSchemaMaxLengthFacet();
        maxLength.Value = "20";
        lastNameRestriction.Facets.Add(maxLength);
        lastNameType.Content = lastNameRestriction;

        // Associate the elements and attributes with their types.
        // Built-in type.
        firstNameElement.SchemaTypeName =
            new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
        // User-defined type.
        lastNameElement.SchemaTypeName =
            new XmlQualifiedName("LastNameType", "http://www.tempuri.org");
        // Built-in type.
        idAttribute.SchemaTypeName = new XmlQualifiedName("positiveInteger",
            "http://www.w3.org/2001/XMLSchema");

        // Create the top-level Customer element.
        XmlSchemaElement customerElement = new XmlSchemaElement();
        customerElement.Name = "Customer";

        // Create an anonymous complex type for the Customer element.
        XmlSchemaComplexType customerType = new XmlSchemaComplexType();
        XmlSchemaSequence sequence = new XmlSchemaSequence();
        sequence.Items.Add(firstNameElement);
        sequence.Items.Add(lastNameElement);
        customerType.Particle = sequence;

        // Add the CustomerId attribute to the complex type.
        customerType.Attributes.Add(idAttribute);

        // Set the SchemaType of the Customer element to
        // the anonymous complex type created above.
        customerElement.SchemaType = customerType;
        //</snippet3>

        //<snippet4>
        // Create an empty schema.
        XmlSchema customerSchema = new XmlSchema();
        customerSchema.TargetNamespace = "http://www.tempuri.org";

        // Add all top-level element and types to the schema
        customerSchema.Items.Add(customerElement);
        customerSchema.Items.Add(lastNameType);

        // Create an XmlSchemaSet to compile the customer schema.
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
        schemaSet.Add(customerSchema);
        schemaSet.Compile();

        foreach (XmlSchema schema in schemaSet.Schemas())
        {
            customerSchema = schema;
        }

        // Write the complete schema to the Console.
        customerSchema.Write(Console.Out);
        //</snippet4>
    }

    static void ValidationCallback(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.Write("WARNING: ");
        else if (args.Severity == XmlSeverityType.Error)
            Console.Write("ERROR: ");

        Console.WriteLine(args.Message);
    }
}
//</snippet1>