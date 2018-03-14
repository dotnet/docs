Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XSDInference

    Shared Sub Main()

    End Sub

    Shared Sub XSDInference_OverallExample()

        '<snippet1>
        Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim schema As XmlSchemaInference = New XmlSchemaInference()

        schemaSet = schema.InferSchema(reader)

        Dim s As XmlSchema

        For Each s In schemaSet.Schemas()
            s.Write(Console.Out)
        Next
        '</snippet1>

    End Sub

    Shared Sub XSDInference_Occurrence()

        '<snippet2>
        Dim reader As XmlReader = XmlReader.Create("input.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim schema As XmlSchemaInference = New XmlSchemaInference()

        schema.Occurrence = XmlSchemaInference.InferenceOption.Relaxed

        schemaSet = schema.InferSchema(reader)
        '</snippet2>

    End Sub

    Shared Sub XSDInference_TypeInference()

        '<snippet3>
        Dim reader As XmlReader = XmlReader.Create("input.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim schema As XmlSchemaInference = New XmlSchemaInference()

        schema.TypeInference = XmlSchemaInference.InferenceOption.Relaxed

        schemaSet = schema.InferSchema(reader)
        '</snippet3>

    End Sub



    Shared Sub RefinementProcess()

        ' <snippet4>
        Dim reader As XmlReader = XmlReader.Create("item1.xml")
        Dim reader1 As XmlReader = XmlReader.Create("item2.xml")
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        Dim Inference As XmlSchemaInference = New XmlSchemaInference()
        schemaSet = Inference.InferSchema(reader)

        ' Display the inferred schema.
        Console.WriteLine("Original schema:" & vbCrLf)
        Dim schema1 As XmlSchema
        For Each schema1 In schemaSet.Schemas("http://www.contoso.com/items")
            schema1.Write(Console.Out)
        Next

        ' Use the additional data in item2.xml to refine the original schema.
        schemaSet = Inference.InferSchema(reader1)

        ' Display the refined schema.
        Console.WriteLine(vbCrLf & vbCrLf & "Refined schema:" & vbCrLf)
        Dim schema2 As XmlSchema
        For Each schema2 In schemaSet.Schemas("http://www.contoso.com/items")
            schema2.Write(Console.Out)
        Next
        ' </snippet4>

    End Sub

End Class
