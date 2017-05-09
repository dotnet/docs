' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        ' <xs:attributeGroup name="myAttributeGroup">
        Dim myAttributeGroup As New XmlSchemaAttributeGroup()
        schema.Items.Add(myAttributeGroup)
        myAttributeGroup.Name = "myAttributeGroup"

        ' <xs:attribute name="someattribute1" type="xs:integer"/>
        Dim someattribute1 As New XmlSchemaAttribute()
        myAttributeGroup.Attributes.Add(someattribute1)
        someattribute1.Name = "someattribute1"
        someattribute1.SchemaTypeName = New XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema")

        ' <xs:attribute name="someattribute2" type="xs:string"/>
        Dim someattribute2 As New XmlSchemaAttribute()
        myAttributeGroup.Attributes.Add(someattribute2)
        someattribute2.Name = "someattribute2"
        someattribute2.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:complexType name="myElementType">
        Dim myElementType As New XmlSchemaComplexType()
        schema.Items.Add(myElementType)
        myElementType.Name = "myElementType"

        ' <xs:attributeGroup ref="myAttributeGroup"/>
        Dim myAttributeGroupRef As New XmlSchemaAttributeGroupRef()
        myElementType.Attributes.Add(myAttributeGroupRef)
        myAttributeGroupRef.RefName = New XmlQualifiedName("myAttributeGroup")

        ' <xs:attributeGroup name="myAttributeGroupA">
        Dim myAttributeGroupA As New XmlSchemaAttributeGroup()
        schema.Items.Add(myAttributeGroupA)
        myAttributeGroupA.Name = "myAttributeGroupA"

        ' <xs:attribute name="someattribute10" type="xs:integer"/>
        Dim someattribute10 As New XmlSchemaAttribute()
        myAttributeGroupA.Attributes.Add(someattribute10)
        someattribute10.Name = "someattribute10"
        someattribute10.SchemaTypeName = New XmlQualifiedName("integer", "http://www.w3.org/2001/XMLSchema")

        ' <xs:attribute name="someattribute11" type="xs:string"/>
        Dim someattribute11 As New XmlSchemaAttribute()
        myAttributeGroupA.Attributes.Add(someattribute11)
        someattribute11.Name = "someattribute11"
        someattribute11.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:attributeGroup name="myAttributeGroupB">
        Dim myAttributeGroupB As New XmlSchemaAttributeGroup()
        schema.Items.Add(myAttributeGroupB)
        myAttributeGroupB.Name = "myAttributeGroupB"

        ' <xs:attribute name="someattribute20" type="xs:date"/>
        Dim someattribute20 As New XmlSchemaAttribute()
        myAttributeGroupB.Attributes.Add(someattribute20)
        someattribute20.Name = "someattribute20"
        someattribute20.SchemaTypeName = New XmlQualifiedName("date", "http://www.w3.org/2001/XMLSchema")

        ' <xs:attributeGroup ref="myAttributeGroupA"/>
        Dim myAttributeGroupRefA As New XmlSchemaAttributeGroupRef()
        myAttributeGroupB.Attributes.Add(myAttributeGroupRefA)
        myAttributeGroupRefA.RefName = New XmlQualifiedName("myAttributeGroupA")

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