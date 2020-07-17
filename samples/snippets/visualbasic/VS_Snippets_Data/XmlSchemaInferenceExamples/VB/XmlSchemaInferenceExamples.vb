Imports System.Xml
Imports System.Xml.Schema

Class XmlSchemaInferenceExamples

    Shared Sub Main()

    End Sub

    Shared Sub XmlSchemaInference_OverallExample()

        '<snippet1>
        Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim schema As XmlSchemaInference = New XmlSchemaInference()

        schemaSet = schema.InferSchema(reader)

        For Each s As XmlSchema In schemaSet.Schemas()
            s.Write(Console.Out)
        Next
        '</snippet1>

    End Sub

    Shared Sub XmlSchemaInference_Occurrence()

        '<snippet2>
        Dim reader As XmlReader = XmlReader.Create("input.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim schema As XmlSchemaInference = New XmlSchemaInference()

        schema.Occurrence = XmlSchemaInference.InferenceOption.Relaxed

        schemaSet = schema.InferSchema(reader)

        For Each s As XmlSchema In schemaSet.Schemas()
            s.Write(Console.Out)
        Next
        '</snippet2>

    End Sub

    Shared Sub XmlSchemaInference_TypeInference()

        '<snippet3>
        Dim reader As XmlReader = XmlReader.Create("input.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim schema As XmlSchemaInference = New XmlSchemaInference()

        schema.TypeInference = XmlSchemaInference.InferenceOption.Relaxed

        schemaSet = schema.InferSchema(reader)

        For Each s As XmlSchema In schemaSet.Schemas()
            s.Write(Console.Out)
        Next
        '</snippet3>

    End Sub

    Shared Sub XmlSchemaInference_RefinementProcess()

        '<snippet4>
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
        '</snippet4>

    End Sub
End Class

