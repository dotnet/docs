//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

public class Sample
{

    public static void Main()
    {
        //Load the XmlSchemaSet.
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.Add("urn:bookstore-schema", "books.xsd");

        //Validate the file using the schema stored in the schema set.
        //Any elements belonging to the namespace "urn:cd-schema" generate
        //a warning because there is no schema matching that namespace.
        Validate("store.xml", schemaSet);
        Console.ReadLine();
    }

    private static void Validate(String filename, XmlSchemaSet schemaSet)
    {
        Console.WriteLine();
        Console.WriteLine("\r\nValidating XML file {0}...", filename.ToString());

        XmlSchema compiledSchema = null;

        foreach (XmlSchema schema in schemaSet.Schemas())
        {
            compiledSchema = schema;
        }

        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add(compiledSchema);
        settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
        settings.ValidationType = ValidationType.Schema;

        //Create the schema validating reader.
        XmlReader vreader = XmlReader.Create(filename, settings);

        while (vreader.Read()) { }

        //Close the reader.
        vreader.Close();
    }

    //Display any warnings or errors.
    private static void ValidationCallBack(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
        else
            Console.WriteLine("\tValidation error: " + args.Message);

    }
}
//</snippet1>



