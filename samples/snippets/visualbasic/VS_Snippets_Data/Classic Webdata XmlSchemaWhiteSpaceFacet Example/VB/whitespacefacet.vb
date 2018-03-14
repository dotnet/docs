'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:simpleType name="NameType">
        Dim NameType As New XmlSchemaSimpleType()
        NameType.Name = "NameType"

        ' <xs:restriction base="xs:string">
        Dim restriction As New XmlSchemaSimpleTypeRestriction()
        restriction.BaseTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:whiteSpace value="collapse"/>
        Dim whiteSpace As New XmlSchemaWhiteSpaceFacet()
        whiteSpace.Value = "collapse"
        restriction.Facets.Add(whiteSpace)

        NameType.Content = restriction

        schema.Items.Add(NameType)

        ' <xs:element name="LastName" type="NameType"/>
        Dim element As New XmlSchemaElement()
        element.Name = "LastName"
        element.SchemaTypeName = New XmlQualifiedName("NameType", "")

        schema.Items.Add(element)

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