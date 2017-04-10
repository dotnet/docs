' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        ' <xs:element name="selected"/>
        Dim xeSelected As New XmlSchemaElement()
        xeSelected.Name = "selected"
        schema.Items.Add(xeSelected)

        ' <xs:element name="unselected"/>
        Dim xeUnselected As New XmlSchemaElement()
        xeUnselected.Name = "unselected"
        schema.Items.Add(xeUnselected)

        ' <xs:element name="dimpled"/>
        Dim xeDimpled As New XmlSchemaElement()
        xeDimpled.Name = "dimpled"
        schema.Items.Add(xeDimpled)

        ' <xs:element name="perforated"/>
        Dim xePerforated As New XmlSchemaElement()
        xePerforated.Name = "perforated"
        schema.Items.Add(xePerforated)

        ' <xs:complexType name="chadState">
        Dim chadState As New XmlSchemaComplexType()
        schema.Items.Add(chadState)
        chadState.Name = "chadState"

        ' <xs:choice minOccurs="1" maxOccurs="1">
        Dim choice As New XmlSchemaChoice()
        chadState.Particle = choice
        choice.MinOccurs = 1
        choice.MaxOccurs = 1

        ' <xs:element ref="selected"/>
        Dim elementSelected As New XmlSchemaElement()
        choice.Items.Add(elementSelected)
        elementSelected.RefName = New XmlQualifiedName("selected")

        ' <xs:element ref="unselected"/>
        Dim elementUnselected As New XmlSchemaElement()
        choice.Items.Add(elementUnselected)
        elementUnselected.RefName = New XmlQualifiedName("unselected")

        ' <xs:element ref="dimpled"/>
        Dim elementDimpled As New XmlSchemaElement()
        choice.Items.Add(elementDimpled)
        elementDimpled.RefName = New XmlQualifiedName("dimpled")

        ' <xs:element ref="perforated"/>
        Dim elementPerforated As New XmlSchemaElement()
        choice.Items.Add(elementPerforated)
        elementPerforated.RefName = New XmlQualifiedName("perforated")

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