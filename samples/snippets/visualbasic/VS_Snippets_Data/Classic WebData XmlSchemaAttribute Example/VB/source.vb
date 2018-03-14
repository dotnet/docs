' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        ' <xs:attribute name="mybaseattribute">
        Dim attributeBase As New XmlSchemaAttribute()
        schema.Items.Add(attributeBase)
        attributeBase.Name = "mybaseattribute"

        ' <xs:simpleType>
        Dim simpleType As New XmlSchemaSimpleType()
        attributeBase.SchemaType = simpleType

        ' <xs:restriction base="integer">
        Dim restriction As New XmlSchemaSimpleTypeRestriction()
        simpleType.Content = restriction
        restriction.BaseTypeName = New XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema")

        ' <xs:maxInclusive value="1000"/>
        Dim maxInclusive As New XmlSchemaMaxInclusiveFacet()
        restriction.Facets.Add(maxInclusive)
        maxInclusive.Value = "1000"

        ' <xs:complexType name="myComplexType">
        Dim complexType As New XmlSchemaComplexType()
        schema.Items.Add(complexType)
        complexType.Name = "myComplexType"

        ' <xs:attribute ref="mybaseattribute"/>
        Dim attributeBaseRef As New XmlSchemaAttribute()
        complexType.Attributes.Add(attributeBaseRef)
        attributeBaseRef.RefName = New XmlQualifiedName("mybaseattribute")

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