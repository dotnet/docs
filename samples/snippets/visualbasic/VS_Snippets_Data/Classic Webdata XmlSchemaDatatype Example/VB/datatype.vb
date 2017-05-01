' <Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

 _

Class XMLSchemaExamples

    Public Shared Sub Main()
        Dim xtr As New XmlTextReader("example.xsd")
        Dim schema As XmlSchema = XmlSchema.Read(xtr, New ValidationEventHandler(AddressOf ValidationCallbackOne))

        Dim schemaSet As New XmlSchemaSet()
        AddHandler schemaSet.ValidationEventHandler, AddressOf ValidationCallbackOne

        schemaSet.Add(schema)
        schemaSet.Compile()

        Dim compiledSchema As XmlSchema = Nothing

        For Each schema1 As XmlSchema In schemaSet.Schemas()
            compiledSchema = schema1
        Next

        Dim schemaObject As XmlSchemaObject
        For Each schemaObject In compiledSchema.Items
            If schemaObject.GetType() Is GetType(XmlSchemaSimpleType) Then
                Dim simpleType As XmlSchemaSimpleType = CType(schemaObject, XmlSchemaSimpleType)
                Console.WriteLine("{0} {1}", simpleType.Name, simpleType.Datatype.ValueType)
            End If
            If schemaObject.GetType() Is GetType(XmlSchemaComplexType) Then
                Dim complexType As XmlSchemaComplexType = CType(schemaObject, XmlSchemaComplexType)
                Console.WriteLine("{0} {1}", complexType.Name, complexType.Datatype.ValueType)
            End If
        Next schemaObject
        xtr.Close()
    End Sub 'Main


    Public Shared Sub ValidationCallbackOne(ByVal sender As Object, ByVal args As ValidationEventArgs)
        Console.WriteLine(args.Message)
    End Sub 'ValidationCallbackOne
End Class 'XMLSchemaExamples
' </Snippet1>
