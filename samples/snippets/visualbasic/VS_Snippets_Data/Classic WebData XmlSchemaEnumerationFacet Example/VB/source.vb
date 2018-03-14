' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples

    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:simpleType name="SizeType">
        Dim SizeType As New XmlSchemaSimpleType()
        SizeType.Name = "SizeType"

        ' <xs:restriction base="xs:string">
        Dim restriction As New XmlSchemaSimpleTypeRestriction()
        restriction.BaseTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:enumeration value="Small"/>
        Dim enumerationSmall As New XmlSchemaEnumerationFacet()
        enumerationSmall.Value = "Small"
        restriction.Facets.Add(enumerationSmall)

        ' <xs:enumeration value="Medium"/>
        Dim enumerationMedium As New XmlSchemaEnumerationFacet()
        enumerationMedium.Value = "Medium"
        restriction.Facets.Add(enumerationMedium)

        ' <xs:enumeration value="Large"/>
        Dim enumerationLarge As New XmlSchemaEnumerationFacet()
        enumerationLarge.Value = "Large"
        restriction.Facets.Add(enumerationLarge)

        SizeType.Content = restriction

        schema.Items.Add(SizeType)

        ' <xs:element name="Item">
        Dim elementItem As New XmlSchemaElement()
        elementItem.Name = "Item"

        ' <xs:complexType>
        Dim complexType As New XmlSchemaComplexType()

        ' <xs:attribute name="Size" type="SizeType"/>
        Dim attributeSize As New XmlSchemaAttribute()
        attributeSize.Name = "Size"
        attributeSize.SchemaTypeName = New XmlQualifiedName("SizeType", "")
        complexType.Attributes.Add(attributeSize)

        elementItem.SchemaType = complexType

        schema.Items.Add(elementItem)

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