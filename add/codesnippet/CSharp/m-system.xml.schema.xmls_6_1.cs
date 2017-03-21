        XmlReader reader = XmlReader.Create("contosoBooks.xml");
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        XmlSchemaInference schema = new XmlSchemaInference();

        schemaSet = schema.InferSchema(reader);

        foreach (XmlSchema s in schemaSet.Schemas())
        {
            s.Write(Console.Out);
        }