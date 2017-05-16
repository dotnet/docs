' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples

    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:element name="generalPrice">
        Dim generalPrice As New XmlSchemaElement()
        generalPrice.Name = "generalPrice"

        ' <xs:complexType>
        Dim ct As New XmlSchemaComplexType()

        ' <xs:simpleContent>
        Dim simpleContent As New XmlSchemaSimpleContent()

        ' <xs:extension base="xs:decimal">
        Dim simpleContent_extension As New XmlSchemaSimpleContentExtension()
        simpleContent_extension.BaseTypeName = New XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema")

        ' <xs:attribute name="currency" type="xs:string" />
        Dim currency As New XmlSchemaAttribute()
        currency.Name = "currency"
        currency.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        simpleContent_extension.Attributes.Add(currency)

        simpleContent.Content = simpleContent_extension
        ct.ContentModel = simpleContent
        generalPrice.SchemaType = ct

        schema.Items.Add(generalPrice)

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
    End Sub 'Main

    Public Shared Sub ValidationCallbackOne(ByVal sender As Object, ByVal args As ValidationEventArgs)

        Console.WriteLine(args.Message)
    End Sub 'ValidationCallbackOne
End Class 'XMLSchemaExamples
' </Snippet1>