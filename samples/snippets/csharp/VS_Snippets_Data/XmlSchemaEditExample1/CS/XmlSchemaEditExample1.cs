//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaEditExample
{
    static void Main(string[] args)
    {
        // Add the customer schema to a new XmlSchemaSet and compile it.
        // Any schema validation warnings and errors encountered reading or
        // compiling the schema are handled by the ValidationEventHandler delegate.
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
        schemaSet.Add("http://www.tempuri.org", "customer.xsd");
        schemaSet.Compile();

        // Retrieve the compiled XmlSchema object from the XmlSchemaSet
        // by iterating over the Schemas property.
        XmlSchema customerSchema = null;
        foreach (XmlSchema schema in schemaSet.Schemas())
        {
            customerSchema = schema;
        }

        // Create the PhoneNumber element.
        XmlSchemaElement phoneElement = new XmlSchemaElement();
        phoneElement.Name = "PhoneNumber";

        // Create the xs:string simple type restriction.
        XmlSchemaSimpleType phoneType = new XmlSchemaSimpleType();
        XmlSchemaSimpleTypeRestriction restriction =
            new XmlSchemaSimpleTypeRestriction();
        restriction.BaseTypeName = new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");

        // Add a pattern facet to the restriction.
        XmlSchemaPatternFacet phonePattern = new XmlSchemaPatternFacet();
        phonePattern.Value = "\\d{3}-\\d{3}-\\d(4)";
        restriction.Facets.Add(phonePattern);

        // Add the restriction to the Content property of the simple type
        // and the simple type to the SchemaType of the PhoneNumber element.
        phoneType.Content = restriction;
        phoneElement.SchemaType = phoneType;

        // Iterate over each XmlSchemaElement in the Values collection
        // of the Elements property.
        foreach (XmlSchemaElement element in customerSchema.Elements.Values)
        {
            // If the qualified name of the element is "Customer",
            // get the complex type of the Customer element
            // and the sequence particle of the complex type.
            if (element.QualifiedName.Name.Equals("Customer"))
            {
                XmlSchemaComplexType customerType =
                    element.ElementSchemaType as XmlSchemaComplexType;
                XmlSchemaSequence sequence =
                    customerType.Particle as XmlSchemaSequence;

                // Add the new PhoneNumber element to the sequence.
                sequence.Items.Add(phoneElement);
            }
        }

        // Reprocess and compile the modified XmlSchema object and write it to the console.
        schemaSet.Reprocess(customerSchema);
        schemaSet.Compile();
        customerSchema.Write(Console.Out);
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