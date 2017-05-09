'<snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema
Module Module1

    Sub Main()

        Dim schema As XmlSchema = New XmlSchema()
        Dim stringType As XmlSchemaSimpleType = New XmlSchemaSimpleType()
        stringType.Name = "myString"
        schema.Items.Add(stringType)
        Dim stringRestriction As XmlSchemaSimpleTypeRestriction = _
                                 New XmlSchemaSimpleTypeRestriction()
        stringRestriction.BaseTypeName = _
                                 New XmlQualifiedName("string", _
                                 "http://www.w3.org/2001/XMLSchema")
        stringType.Content = stringRestriction
        schema.Write(Console.Out)

    End Sub

End Module

'</snippet1>