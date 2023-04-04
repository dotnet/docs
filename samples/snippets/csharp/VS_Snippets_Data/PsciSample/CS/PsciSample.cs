//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

public class PsciSample
{
    public static void Main(string[] args)
    {
        XmlSchema schema = new XmlSchema();

        // Create an element of type integer and add it to the schema.
        XmlSchemaElement priceElem = new XmlSchemaElement();
        priceElem.Name = "Price";
        priceElem.SchemaTypeName = new XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema");
        schema.Items.Add(priceElem);

        // Print the pre-compilation value of the ElementSchemaType property
        // of the XmlSchemaElement which is a PSCI property.
        Console.WriteLine("Before compilation the ElementSchemaType of Price is " + priceElem.ElementSchemaType);

        //Compile the schema which validates the schema and
        // if valid will place the PSCI values in certain properties.
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += ValidationCallbackOne;
        schemaSet.Add(schema);
        schemaSet.Compile();

        foreach (XmlSchema compiledSchema in schemaSet.Schemas())
        {
            schema = compiledSchema;
        }

        // After compilation of the schema, the ElementSchemaType property of the
        // XmlSchemaElement will contain a reference to a valid object because the
        // SchemaTypeName referred to a valid type.
        Console.WriteLine("After compilation the ElementSchemaType of Price is "
           + priceElem.ElementSchemaType);
    }

    private static void ValidationCallbackOne(object sender, ValidationEventArgs args)
    {
        Console.WriteLine(args.Message);
    }
}
//</snippet1>
