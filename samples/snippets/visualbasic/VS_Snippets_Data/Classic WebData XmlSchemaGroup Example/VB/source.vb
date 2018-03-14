' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples

    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:element name="thing1" type="xs:string"/>
        Dim elementThing1 As New XmlSchemaElement()
        schema.Items.Add(elementThing1)
        elementThing1.Name = "thing1"
        elementThing1.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:element name="thing2" type="xs:string"/>
        Dim elementThing2 As New XmlSchemaElement()
        schema.Items.Add(elementThing2)
        elementThing2.Name = "thing2"
        elementThing2.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:element name="thing3" type="xs:string"/>
        Dim elementThing3 As New XmlSchemaElement()
        schema.Items.Add(elementThing3)
        elementThing3.Name = "thing3"
        elementThing3.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:attribute name="myAttribute" type="xs:decimal"/>
        Dim myAttribute As New XmlSchemaAttribute()
        schema.Items.Add(myAttribute)
        myAttribute.Name = "myAttribute"
        myAttribute.SchemaTypeName = New XmlQualifiedName("decimal", "http://www.w3.org/2001/XMLSchema")

        ' <xs:group name="myGroupOfThings">
        Dim myGroupOfThings As New XmlSchemaGroup()
        schema.Items.Add(myGroupOfThings)
        myGroupOfThings.Name = "myGroupOfThings"

        ' <xs:sequence>
        Dim sequence As New XmlSchemaSequence()
        myGroupOfThings.Particle = sequence

        ' <xs:element ref="thing1"/>
        Dim elementThing1Ref As New XmlSchemaElement()
        sequence.Items.Add(elementThing1Ref)
        elementThing1Ref.RefName = New XmlQualifiedName("thing1")

        ' <xs:element ref="thing2"/>
        Dim elementThing2Ref As New XmlSchemaElement()
        sequence.Items.Add(elementThing2Ref)
        elementThing2Ref.RefName = New XmlQualifiedName("thing2")

        ' <xs:element ref="thing3"/>
        Dim elementThing3Ref As New XmlSchemaElement()
        sequence.Items.Add(elementThing3Ref)
        elementThing3Ref.RefName = New XmlQualifiedName("thing3")

        ' <xs:complexType name="myComplexType">
        Dim myComplexType As New XmlSchemaComplexType()
        schema.Items.Add(myComplexType)
        myComplexType.Name = "myComplexType"

        ' <xs:group ref="myGroupOfThings"/>
        Dim myGroupOfThingsRef As New XmlSchemaGroupRef()
        myComplexType.Particle = myGroupOfThingsRef
        myGroupOfThingsRef.RefName = New XmlQualifiedName("myGroupOfThings")

        ' <xs:attribute ref="myAttribute"/>
        Dim myAttributeRef As New XmlSchemaAttribute()
        myComplexType.Attributes.Add(myAttributeRef)
        myAttributeRef.RefName = New XmlQualifiedName("myAttribute")

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