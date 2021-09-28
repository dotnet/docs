using System;
using System.Xml;
using System.Xml.Schema;

class XmlSchemaInferenceExamples
{
    static void Main()
    {
        XmlSchemaInference_RefinementProcess();

        Console.ReadLine();
    }

    static void XmlSchemaInference_OverallExample()
    {
        //<snippet1>
        XmlReader reader = XmlReader.Create("contosoBooks.xml");
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        XmlSchemaInference schema = new XmlSchemaInference();

        schemaSet = schema.InferSchema(reader);

        foreach (XmlSchema s in schemaSet.Schemas())
        {
            s.Write(Console.Out);
        }
        //</snippet1>
    }

    static void XmlSchemaInference_Occurrence()
    {
        //<snippet2>
        XmlReader reader = XmlReader.Create("input.xml");
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        XmlSchemaInference schema = new XmlSchemaInference();

        schema.Occurrence = XmlSchemaInference.InferenceOption.Relaxed;

        schemaSet = schema.InferSchema(reader);

        foreach (XmlSchema s in schemaSet.Schemas())
        {
            s.Write(Console.Out);
        }
        //</snippet2>
    }

    static void XmlSchemaInference_TypeInference()
    {
        //<snippet3>
        XmlReader reader = XmlReader.Create("input.xml");
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        XmlSchemaInference schema = new XmlSchemaInference();

        schema.TypeInference = XmlSchemaInference.InferenceOption.Relaxed;

        schemaSet = schema.InferSchema(reader);

        foreach (XmlSchema s in schemaSet.Schemas())
        {
            s.Write(Console.Out);
        }
        //</snippet3>
    }

    static void XmlSchemaInference_RefinementProcess()
    {
        //<snippet4>
        XmlReader reader = XmlReader.Create("item1.xml");
        XmlReader reader1 = XmlReader.Create("item2.xml");
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        XmlSchemaInference inference = new XmlSchemaInference();
        schemaSet = inference.InferSchema(reader);

        // Display the inferred schema.
        Console.WriteLine("Original schema:\n");
        foreach (XmlSchema schema in schemaSet.Schemas("http://www.contoso.com/items"))
        {
            schema.Write(Console.Out);
        }

        // Use the additional data in item2.xml to refine the original schema.
        schemaSet = inference.InferSchema(reader1, schemaSet);

        // Display the refined schema.
        Console.WriteLine("\n\nRefined schema:\n");
        foreach (XmlSchema schema in schemaSet.Schemas("http://www.contoso.com/items"))
        {
            schema.Write(Console.Out);
        }
        //</snippet4>
    }
}
