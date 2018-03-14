'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:simpleType name="WaitQueueLengthType">
        Dim WaitQueueLengthType As New XmlSchemaSimpleType()
        WaitQueueLengthType.Name = "WaitQueueLengthType"

        ' <xs:restriction base="xs:int">
        Dim restriction As New XmlSchemaSimpleTypeRestriction()
        restriction.BaseTypeName = New XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema")

        ' <xs:maxExclusive value="5"/>
        Dim maxExclusive As New XmlSchemaMaxExclusiveFacet()
        maxExclusive.Value = "5"
        restriction.Facets.Add(maxExclusive)

        WaitQueueLengthType.Content = restriction

        schema.Items.Add(WaitQueueLengthType)

        ' <xs:element name="Lobby">
        Dim element As New XmlSchemaElement()
        element.Name = "Lobby"

        ' <xs:complexType>
        Dim complexType As New XmlSchemaComplexType()

        ' <xs:attribute name="WaitQueueLength" type="WaitQueueLengthType"/>
        Dim WaitQueueLengthAttribute As New XmlSchemaAttribute()
        WaitQueueLengthAttribute.Name = "WaitQueueLength"
        WaitQueueLengthAttribute.SchemaTypeName = New XmlQualifiedName("WaitQueueLengthType", "")
        complexType.Attributes.Add(WaitQueueLengthAttribute)

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