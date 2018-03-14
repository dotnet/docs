' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples

    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <element name='htmlText'>
        Dim xeHtmlText As New XmlSchemaElement()
        xeHtmlText.Name = "htmlText"

        ' <complexType>
        Dim ct As New XmlSchemaComplexType()

        ' <sequence>
        Dim sequence As New XmlSchemaSequence()

        ' <any namespace='http://www.w3.org/1999/xhtml'
        '    minOccurs='1' maxOccurs='unbounded'
        '    processContents='lax'/>
        Dim any As New XmlSchemaAny()
        any.MinOccurs = 1
        any.MaxOccursString = "unbounded"
        any.Namespace = "http://www.w3.org/1999/xhtml"
        any.ProcessContents = XmlSchemaContentProcessing.Lax
        sequence.Items.Add(any)

        ct.Particle = sequence
        xeHtmlText.SchemaType = ct

        schema.Items.Add(xeHtmlText)

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