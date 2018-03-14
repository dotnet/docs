'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:simpleType name="ZipCodeType">
        Dim ZipCodeType As New XmlSchemaSimpleType()
        ZipCodeType.Name = "ZipCodeType"

        ' <xs:restriction base="xs:string">
        Dim restriction As New XmlSchemaSimpleTypeRestriction()
        restriction.BaseTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:maxLength value="10"/>
        Dim maxLength As New XmlSchemaMaxLengthFacet()
        maxLength.Value = "10"
        restriction.Facets.Add(maxLength)

        ZipCodeType.Content = restriction

        schema.Items.Add(ZipCodeType)

        ' <xs:element name="Address">
        Dim element As New XmlSchemaElement()
        element.Name = "Address"

        ' <xs:complexType>
        Dim complexType As New XmlSchemaComplexType()

        ' <xs:attribute name="ZipCode" type="ZipCodeType"/>
        Dim ZipCodeAttribute As New XmlSchemaAttribute()
        ZipCodeAttribute.Name = "ZipCode"
        ZipCodeAttribute.SchemaTypeName = New XmlQualifiedName("ZipCodeType", "")

        complexType.Attributes.Add(ZipCodeAttribute)

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