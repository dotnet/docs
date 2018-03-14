' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples

    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        ' <xs:complexType name="address">
        Dim address As New XmlSchemaComplexType()
        schema.Items.Add(address)
        address.Name = "address"

        ' <xs:sequence>
        Dim sequence As New XmlSchemaSequence()
        address.Particle = sequence

        ' <xs:element name="name"   type="xs:string"/>
        Dim elementName As New XmlSchemaElement()
        sequence.Items.Add(elementName)
        elementName.Name = "name"
        elementName.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:element name="street"   type="xs:string"/>
        Dim elementStreet As New XmlSchemaElement()
        sequence.Items.Add(elementStreet)
        elementStreet.Name = "street"
        elementStreet.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:element name="city"   type="xs:string"/>
        Dim elementCity As New XmlSchemaElement()
        sequence.Items.Add(elementCity)
        elementCity.Name = "city"
        elementCity.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:complexType name="USAddress">
        Dim USAddress As New XmlSchemaComplexType()
        schema.Items.Add(USAddress)
        USAddress.Name = "USAddress"

        ' <xs:complexContent>
        Dim complexContent As New XmlSchemaComplexContent()
        USAddress.ContentModel = complexContent

        ' <xs:extension base="address">
        Dim extensionAddress As New XmlSchemaComplexContentExtension()
        complexContent.Content = extensionAddress
        extensionAddress.BaseTypeName = New XmlQualifiedName("address")

        ' <xs:sequence>
        Dim sequence2 As New XmlSchemaSequence()
        extensionAddress.Particle = sequence2

        ' <xs:element name="state" type="xs:string"/>
        Dim elementUSState As New XmlSchemaElement()
        sequence2.Items.Add(elementUSState)
        elementUSState.Name = "state"
        elementUSState.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")


        ' <xs:element name="zipcode" type="xs:positiveInteger"/>
        Dim elementZipcode As New XmlSchemaElement()
        sequence2.Items.Add(elementZipcode)
        elementZipcode.Name = "zipcode"
        elementZipcode.SchemaTypeName = New XmlQualifiedName("positiveInteger", "http://www.w3.org/2001/XMLSchema")

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