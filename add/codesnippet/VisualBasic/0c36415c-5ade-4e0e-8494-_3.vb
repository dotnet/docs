        Dim reader As XmlReader = XmlReader.Create("item1.xml")
        Dim reader1 As XmlReader = XmlReader.Create("item2.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim inference As XmlSchemaInference = New XmlSchemaInference()
        schemaSet = inference.InferSchema(reader)

        ' Display the inferred schema.
        Console.WriteLine("Original schema:\n")
        For Each schema As XmlSchema In schemaSet.Schemas("http://www.contoso.com/items")
            schema.Write(Console.Out)
        Next

        ' Use the additional data in item2.xml to refine the original schema.
        schemaSet = inference.InferSchema(reader1, schemaSet)

        ' Display the refined schema.
        Console.WriteLine("\n\nRefined schema:\n")
        For Each schema As XmlSchema In schemaSet.Schemas("http://www.contoso.com/items")
            schema.Write(Console.Out)
        Next