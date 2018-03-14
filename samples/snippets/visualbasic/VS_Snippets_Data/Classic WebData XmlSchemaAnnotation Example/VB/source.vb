' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        ' <xs:simpleType name="northwestStates">
        Dim simpleType As New XmlSchemaSimpleType()
        simpleType.Name = "northwestStates"
        schema.Items.Add(simpleType)

        ' <xs:annotation>
        Dim annNorthwestStates As New XmlSchemaAnnotation()
        simpleType.Annotation = annNorthwestStates

        ' <xs:documentation>States in the Pacific Northwest of US</xs:documentation>
        Dim docNorthwestStates As New XmlSchemaDocumentation()
        annNorthwestStates.Items.Add(docNorthwestStates)
        docNorthwestStates.Markup = TextToNodeArray("States in the Pacific Northwest of US")

        ' <xs:restriction base="xs:string">
        Dim restriction As New XmlSchemaSimpleTypeRestriction()
        simpleType.Content = restriction
        restriction.BaseTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:enumeration value='WA'>
        Dim enumerationWA As New XmlSchemaEnumerationFacet()
        restriction.Facets.Add(enumerationWA)
        enumerationWA.Value = "WA"

        ' <xs:annotation>
        Dim annWA As New XmlSchemaAnnotation()
        enumerationWA.Annotation = annWA

        ' <xs:documentation>Washington</documentation>
        Dim docWA As New XmlSchemaDocumentation()
        annWA.Items.Add(docWA)
        docWA.Markup = TextToNodeArray("Washington")

        ' <xs:enumeration value='OR'>
        Dim enumerationOR As New XmlSchemaEnumerationFacet()
        restriction.Facets.Add(enumerationOR)
        enumerationOR.Value = "OR"

        ' <xs:annotation>
        Dim annOR As New XmlSchemaAnnotation()
        enumerationOR.Annotation = annOR

        ' <xs:documentation>Oregon</xs:documentation>
        Dim docOR As New XmlSchemaDocumentation()
        annOR.Items.Add(docOR)
        docOR.Markup = TextToNodeArray("Oregon")

        ' <xs:enumeration value='ID'>
        Dim enumerationID As New XmlSchemaEnumerationFacet()
        restriction.Facets.Add(enumerationID)
        enumerationID.Value = "ID"

        ' <xs:annotation>
        Dim annID As New XmlSchemaAnnotation()
        enumerationID.Annotation = annID

        ' <xs:documentation>Idaho</xs:documentation>
        Dim docID As New XmlSchemaDocumentation()
        annID.Items.Add(docID)
        docID.Markup = TextToNodeArray("Idaho")

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


    Public Shared Function TextToNodeArray(ByVal text As String) As XmlNode()
        Dim doc As New XmlDocument()
        Return New XmlNode(0) {doc.CreateTextNode(text)}
    End Function 'TextToNodeArray
End Class 'XMLSchemaExamples 
' </Snippet1>