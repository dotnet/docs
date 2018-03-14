'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:simpleType name="OrderQuantityType">
        Dim OrderQuantityType As New XmlSchemaSimpleType()
        OrderQuantityType.Name = "OrderQuantityType"

        ' <xs:restriction base="xs:int">
        Dim restriction As New XmlSchemaSimpleTypeRestriction()
        restriction.BaseTypeName = New XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema")

        ' <xs:minInclusive value="5"/>
        Dim minInclusive As New XmlSchemaMinInclusiveFacet()
        minInclusive.Value = "5"
        restriction.Facets.Add(minInclusive)

        OrderQuantityType.Content = restriction

        schema.Items.Add(OrderQuantityType)

        ' <xs:element name="item">
        Dim element As New XmlSchemaElement()
        element.Name = "item"

        ' <xs:complexType>
        Dim complexType As New XmlSchemaComplexType()

        ' <xs:attribute name="OrderQuantity" type="OrderQuantityType"/>
        Dim OrderQuantityAttribute As New XmlSchemaAttribute()
        OrderQuantityAttribute.Name = "OrderQuantity"
        OrderQuantityAttribute.SchemaTypeName = New XmlQualifiedName("OrderQuantityType", "")
        complexType.Attributes.Add(OrderQuantityAttribute)

        element.SchemaType = complexType

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