using System;
using System.Xml;
using System.Xml.Schema;

class XSDInference
{
	static void Main()
	{
        
    }

    static void XSDInference_OverallExample()
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

    static void XSDInference_Occurrence()
    {
        //<snippet2>
        XmlReader reader = XmlReader.Create("input.xml");
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        XmlSchemaInference schema = new XmlSchemaInference();

        schema.Occurrence = XmlSchemaInference.InferenceOption.Relaxed;

        schemaSet = schema.InferSchema(reader);
        //</snippet2>
    }

    static void XSDInference_TypeInference()
    {
        //<snippet3>
        XmlReader reader = XmlReader.Create("input.xml");
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        XmlSchemaInference schema = new XmlSchemaInference();

        schema.TypeInference = XmlSchemaInference.InferenceOption.Relaxed;

        schemaSet = schema.InferSchema(reader);
        //</snippet3>
    }

    static void RefinementProcess()
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
		schemaSet = inference.InferSchema(reader1);

		// Display the refined schema.
		Console.WriteLine("\n\nRefined schema:\n");
		foreach (XmlSchema schema in schemaSet.Schemas("http://www.contoso.com/items"))
		{
			schema.Write(Console.Out);
		}
        //</snippet4>
	}  
}

