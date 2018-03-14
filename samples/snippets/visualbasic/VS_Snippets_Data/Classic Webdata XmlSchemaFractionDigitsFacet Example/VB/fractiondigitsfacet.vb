'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        '<xs:simpleType name="RatingType">
        Dim RatingType As New XmlSchemaSimpleType()
        RatingType.Name = "RatingType"

        '<xs:restriction base="xs:number">
        Dim restriction As New XmlSchemaSimpleTypeRestriction()
        restriction.BaseTypeName = New XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema")

        '<xs:totalDigits value="2"/>
        Dim totalDigits As New XmlSchemaTotalDigitsFacet()
        totalDigits.Value = "2"
        restriction.Facets.Add(totalDigits)

        '<xs:fractionDigits value="1"/>
        Dim fractionDigits As New XmlSchemaFractionDigitsFacet()
        fractionDigits.Value = "1"
        restriction.Facets.Add(fractionDigits)

        RatingType.Content = restriction
        schema.Items.Add(RatingType)

        '<xs:element name="movie">
        Dim element As New XmlSchemaElement()
        element.Name = "movie"

        '<xs:complexType>
        Dim complexType As New XmlSchemaComplexType()

        '<xs:attribute name="rating" type="RatingType"/>
        Dim ratingAttribute As New XmlSchemaAttribute()
        ratingAttribute.Name = "rating"
        ratingAttribute.SchemaTypeName = New XmlQualifiedName("RatingType", "")
        complexType.Attributes.Add(ratingAttribute)

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