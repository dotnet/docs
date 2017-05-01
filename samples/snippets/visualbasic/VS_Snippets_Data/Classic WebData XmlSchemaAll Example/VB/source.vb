' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Public Class Sample

    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        Dim thing1 As New XmlSchemaElement()
        thing1.Name = "thing1"
        thing1.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        schema.Items.Add(thing1)

        Dim thing2 As New XmlSchemaElement()
        thing2.Name = "thing2"
        thing2.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        schema.Items.Add(thing2)

        Dim thing3 As New XmlSchemaElement()
        thing3.Name = "thing3"
        thing3.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        schema.Items.Add(thing3)

        Dim thing4 As New XmlSchemaElement()
        thing4.Name = "thing4"
        thing4.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        schema.Items.Add(thing4)

        Dim myAttribute As New XmlSchemaAttribute()
        myAttribute.Name = "myAttribute"
        myAttribute.SchemaTypeName = New XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema")
        schema.Items.Add(myAttribute)

        Dim myComplexType As New XmlSchemaComplexType()
        myComplexType.Name = "myComplexType"

        Dim complexType_all As New XmlSchemaAll()

        Dim complexType_all_thing1 As New XmlSchemaElement()
        complexType_all_thing1.RefName = New XmlQualifiedName("thing1", "")
        complexType_all.Items.Add(complexType_all_thing1)

        Dim complexType_all_thing2 As New XmlSchemaElement()
        complexType_all_thing2.RefName = New XmlQualifiedName("thing2", "")
        complexType_all.Items.Add(complexType_all_thing2)

        Dim complexType_all_thing3 As New XmlSchemaElement()
        complexType_all_thing3.RefName = New XmlQualifiedName("thing3", "")
        complexType_all.Items.Add(complexType_all_thing3)

        Dim complexType_all_thing4 As New XmlSchemaElement()
        complexType_all_thing4.RefName = New XmlQualifiedName("thing4", "")
        complexType_all.Items.Add(complexType_all_thing4)

        myComplexType.Particle = complexType_all

        Dim complexType_myAttribute As New XmlSchemaAttribute()
        complexType_myAttribute.RefName = New XmlQualifiedName("myAttribute", "")
        myComplexType.Attributes.Add(complexType_myAttribute)

        schema.Items.Add(myComplexType)

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


    Private Shared Sub ValidationCallbackOne(ByVal sender As Object, ByVal args As ValidationEventArgs)
        Console.WriteLine(args.Message)
    End Sub 'ValidationCallbackOne
End Class 'Sample 
' </Snippet1>