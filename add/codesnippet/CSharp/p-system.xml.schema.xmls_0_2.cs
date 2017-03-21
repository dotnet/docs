        XmlReader reader = XmlReader.Create("input.xml");
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        XmlSchemaInference schema = new XmlSchemaInference();

        schema.TypeInference = XmlSchemaInference.InferenceOption.Relaxed;

        schemaSet = schema.InferSchema(reader);

        foreach (XmlSchema s in schemaSet.Schemas())
        {
            s.Write(Console.Out);
        }