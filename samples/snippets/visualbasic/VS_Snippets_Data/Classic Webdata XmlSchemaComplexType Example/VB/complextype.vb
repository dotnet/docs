'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:element name="stringElementWithAnyAttribute">
        Dim element As New XmlSchemaElement()
        schema.Items.Add(element)
        element.Name = "stringElementWithAnyAttribute"

        ' <xs:complexType>
        Dim complexType As New XmlSchemaComplexType()
        element.SchemaType = complexType

        ' <xs:simpleContent>
        Dim simpleContent As New XmlSchemaSimpleContent()
        complexType.ContentModel = simpleContent

        ' <extension base="xs:string">
        Dim extension As New XmlSchemaSimpleContentExtension()
        simpleContent.Content = extension
        extension.BaseTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:anyAttribute namespace="##targetNamespace"/>
        Dim anyAttribute As New XmlSchemaAnyAttribute()
        extension.AnyAttribute = anyAttribute
        anyAttribute.Namespace = "##targetNamespace"

        Dim schemaSet As New XmlSchemaSet()
        AddHandler schemaSet.ValidationEventHandler, AddressOf ValidationCallbackOne

        schemaSet.Add(schema)
        schemaSet.Compile()

        Dim compiledSchema As XmlSchema = Nothing

        For Each schema1 As XmlSchema In schemaSet.Schemas()
            compiledSchema = schema1
        Next

        Dim nsmgr As New XmlNamespaceManager(New NameTable())
        nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema")
        compiledSchema.Write(Console.Out, nsmgr)

    End Sub

    Public Shared Sub ValidationCallbackOne(ByVal sender As Object, ByVal args As ValidationEventArgs)
        Console.WriteLine(args.Message)
    End Sub

End Class
'</Snippet1>