'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        ' <xs:simpleType name="StringOrIntType">
        Dim StringOrIntType As New XmlSchemaSimpleType()
        StringOrIntType.Name = "StringOrIntType"
        schema.Items.Add(StringOrIntType)

        ' <xs:union>
        Dim union As New XmlSchemaSimpleTypeUnion
        StringOrIntType.Content = union

        ' <xs:simpleType>
        Dim simpleType1 As New XmlSchemaSimpleType
        union.BaseTypes.Add(simpleType1)

        ' <xs:restriction base="xs:string"/>
        Dim restriction1 As New XmlSchemaSimpleTypeRestriction()
        restriction1.BaseTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        simpleType1.Content = restriction1

        ' <xs:simpleType>
        Dim simpleType2 As New XmlSchemaSimpleType()
        union.BaseTypes.Add(simpleType2)

        ' <xs:restriction base="xs:int"/>
        Dim restriction2 As New XmlSchemaSimpleTypeRestriction()
        restriction2.BaseTypeName = New XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema")
        simpleType2.Content = restriction2


        ' <xs:element name="size" type="StringOrIntType"/>
        Dim elementSize As New XmlSchemaElement()
        elementSize.Name = "size"
        elementSize.SchemaTypeName = New XmlQualifiedName("StringOrIntType")
        schema.Items.Add(elementSize)

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