' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        ' <xs:element name="State">
        Dim element As New XmlSchemaElement()
        schema.Items.Add(element)
        element.Name = "State"

        ' <xs:annotation>
        Dim annNorthwestStates As New XmlSchemaAnnotation()
        element.Annotation = annNorthwestStates

        ' <xs:documentation>State Name</xs:documentation>
        Dim docNorthwestStates As New XmlSchemaDocumentation()
        annNorthwestStates.Items.Add(docNorthwestStates)
        docNorthwestStates.Markup = TextToNodeArray("State Name")

        ' <xs:appInfo>Application Information</xs:appInfo>
        Dim appInfo As New XmlSchemaAppInfo()
        annNorthwestStates.Items.Add(appInfo)
        appInfo.Markup = TextToNodeArray("Application Information")

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