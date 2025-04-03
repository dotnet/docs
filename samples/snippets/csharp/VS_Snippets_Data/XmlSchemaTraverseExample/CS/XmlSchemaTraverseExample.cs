//<snippet1>
using System;
using System.Collections;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaTraverseExample
{
    static void Main()
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

        // Iterate over each XmlSchemaElement in the Values collection
        // of the Elements property.
        foreach (XmlSchemaElement element in customerSchema.Elements.Values)
        {

            Console.WriteLine($"Element: {element.Name}");

            // Get the complex type of the Customer element.
            XmlSchemaComplexType complexType = element.ElementSchemaType as XmlSchemaComplexType;

            // If the complex type has any attributes, get an enumerator
            // and write each attribute name to the console.
            if (complexType.AttributeUses.Count > 0)
            {
                IDictionaryEnumerator enumerator =
                    complexType.AttributeUses.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    XmlSchemaAttribute attribute =
                        (XmlSchemaAttribute)enumerator.Value;

                    Console.WriteLine($"Attribute: {attribute.Name}");
                }
            }

            // Get the sequence particle of the complex type.
            XmlSchemaSequence sequence = complexType.ContentTypeParticle as XmlSchemaSequence;

            // Iterate over each XmlSchemaElement in the Items collection.
            foreach (XmlSchemaElement childElement in sequence.Items)
            {
                Console.WriteLine($"Element: {childElement.Name}");
            }
        }
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