'<snippet1>
Imports System.Xml
Imports System.Xml.Schema

Public Class PsciSample

    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' Create an element of type integer and add it to the schema.
        Dim priceElem As New XmlSchemaElement()
        priceElem.Name = "Price"
        priceElem.SchemaTypeName = New XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema")
        schema.Items.Add(priceElem)

        ' Print the pre-compilation value of the ElementSchemaType property
        ' of the XmlSchemaElement which is a PSCI property.
        Console.WriteLine("Before compilation the ElementSchemaType of Price is {0}", priceElem.ElementSchemaType)

        ' Compile the schema which validates the schema and
        ' if valid will place the PSCI values in certain properties.
        Dim schemaSet As New XmlSchemaSet()
        AddHandler schemaSet.ValidationEventHandler, AddressOf ValidationCallbackOne
        schemaSet.Add(schema)
        schemaSet.Compile()

        For Each compiledSchema As XmlSchema In schemaSet.Schemas()
            schema = compiledSchema
        Next

        ' After compilation of the schema, the ElementSchemaType property of the
        ' XmlSchemaElement will contain a reference to a valid object because the
        ' SchemaTypeName referred to a valid type.
        Console.WriteLine("After compilation the ElementSchemaType of Price is {0}", _
                priceElem.ElementSchemaType)

    End Sub

    Private Shared Sub ValidationCallbackOne(ByVal sender As Object, ByVal args As ValidationEventArgs)
        Console.WriteLine(args.Message)
    End Sub

End Class
'</snippet1>
