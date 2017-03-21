        Dim reader As XmlReader = XmlReader.Create("input.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim schema As XmlSchemaInference = New XmlSchemaInference()

        schema.TypeInference = XmlSchemaInference.InferenceOption.Relaxed

        schemaSet = schema.InferSchema(reader)

        For Each s As XmlSchema In schemaSet.Schemas()
            s.Write(Console.Out)
        Next