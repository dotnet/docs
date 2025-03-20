//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaImportExample
{
    static void Main(string[] args)
    {
        // Add the customer and address schemas to a new XmlSchemaSet and compile them.
        // Any schema validation warnings and errors encountered reading or
        // compiling the schemas are handled by the ValidationEventHandler delegate.
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
        schemaSet.Add("http://www.tempuri.org", "customer.xsd");
        schemaSet.Add("http://www.example.com/IPO", "address.xsd");
        schemaSet.Compile();

        // Retrieve the compiled XmlSchema objects for the customer and
        // address schema from the XmlSchemaSet by iterating over
        // the Schemas property.
        XmlSchema customerSchema = null;
        XmlSchema addressSchema = null;
        foreach (XmlSchema schema in schemaSet.Schemas())
        {
            if (schema.TargetNamespace == "http://www.tempuri.org")
                customerSchema = schema;
            else if (schema.TargetNamespace == "http://www.example.com/IPO")
                addressSchema = schema;
        }

        // Create an XmlSchemaImport object, set the Namespace property
        // to the namespace of the address schema, the Schema property
        // to the address schema, and add it to the Includes property
        // of the customer schema.
        XmlSchemaImport import = new XmlSchemaImport();
        import.Namespace = "http://www.example.com/IPO";
        import.Schema = addressSchema;
        customerSchema.Includes.Add(import);

        // Reprocess and compile the modified XmlSchema object
        // of the customer schema and write it to the console.
        schemaSet.Reprocess(customerSchema);
        schemaSet.Compile();
        customerSchema.Write(Console.Out);

        // Recursively write all of the schemas imported into the
        // customer schema to the console using the Includes
        // property of the customer schema.
        RecurseExternals(customerSchema);
    }

    static void RecurseExternals(XmlSchema schema)
    {
        foreach (XmlSchemaExternal external in schema.Includes)
        {
            if (external.SchemaLocation != null)
            {
                Console.WriteLine($"External SchemaLocation: {external.SchemaLocation}");
            }

            if (external is XmlSchemaImport)
            {
                XmlSchemaImport import = external as XmlSchemaImport;
                Console.WriteLine($"Imported namespace: {import.Namespace}");
            }

            if (external.Schema != null)
            {
                external.Schema.Write(Console.Out);
                RecurseExternals(external.Schema);
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