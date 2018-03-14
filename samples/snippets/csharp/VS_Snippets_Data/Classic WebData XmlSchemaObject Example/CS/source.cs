// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Reflection;

public class ValidXSD
{
    public static int Main()
    {

        string xsd = "example.xsd";

        FileStream fs;
        XmlSchema schema;
        try
        {
            fs = new FileStream(xsd, FileMode.Open);
            schema = XmlSchema.Read(fs, new ValidationEventHandler(ShowCompileError));

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.ValidationEventHandler += new ValidationEventHandler(ShowCompileError);
            schemaSet.Add(schema);
            schemaSet.Compile();

            XmlSchema compiledSchema = null;

            foreach (XmlSchema schema1 in schemaSet.Schemas())
            {
                compiledSchema = schema1;
            }

            schema = compiledSchema;

            if (schema.IsCompiled)
            {
                DisplayObjects(schema);
            }
            return 0;
        }
        catch (XmlSchemaException e)
        {
            Console.WriteLine("LineNumber = {0}", e.LineNumber);
            Console.WriteLine("LinePosition = {0}", e.LinePosition);
            Console.WriteLine("Message = {0}", e.Message);
            Console.WriteLine("Source = {0}", e.Source);
            return -1;
        }
    }

    private static void DisplayObjects(object o)
    {
        DisplayObjects(o, "");
    }
    private static void DisplayObjects(object o, string indent)
    {
        Console.WriteLine("{0}{1}", indent, o);

        foreach (PropertyInfo property in o.GetType().GetProperties())
        {
            if (property.PropertyType.FullName == "System.Xml.Schema.XmlSchemaObjectCollection")
            {

                XmlSchemaObjectCollection childObjectCollection = (XmlSchemaObjectCollection)property.GetValue(o, null);

                foreach (XmlSchemaObject schemaObject in childObjectCollection)
                {
                    DisplayObjects(schemaObject, indent + "\t");
                }
            }
        }
    }
    private static void ShowCompileError(object sender, ValidationEventArgs e)
    {
        Console.WriteLine("Validation Error: {0}", e.Message);
    }
}
// </Snippet1>

