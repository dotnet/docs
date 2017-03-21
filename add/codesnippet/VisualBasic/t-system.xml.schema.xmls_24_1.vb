        Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim schema As XmlSchemaInference = New XmlSchemaInference()

        schemaSet = schema.InferSchema(reader)

        For Each s As XmlSchema In schemaSet.Schemas()
            s.Write(Console.Out)
        Next