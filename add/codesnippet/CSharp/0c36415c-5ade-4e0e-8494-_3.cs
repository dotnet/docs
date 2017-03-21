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