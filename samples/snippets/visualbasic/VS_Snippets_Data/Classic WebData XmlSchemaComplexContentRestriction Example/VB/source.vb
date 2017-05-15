' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples

    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:complexType name="phoneNumber">
        Dim phoneNumber As New XmlSchemaComplexType()
        phoneNumber.Name = "phoneNumber"

        ' <xs:sequence>
        Dim phoneNumberSequence As New XmlSchemaSequence()

        ' <xs:element name="areaCode"/>
        Dim areaCode1 As New XmlSchemaElement()
        areaCode1.MinOccurs = 0
        areaCode1.MaxOccursString = "1"
        areaCode1.Name = "areaCode"
        phoneNumberSequence.Items.Add(areaCode1)

        ' <xs:element name="prefix"/>
        Dim prefix1 As New XmlSchemaElement()
        prefix1.MinOccurs = 1
        prefix1.MaxOccursString = "1"
        prefix1.Name = "prefix"
        phoneNumberSequence.Items.Add(prefix1)

        ' <xs:element name="number"/>
        Dim number1 As New XmlSchemaElement()
        number1.MinOccurs = 1
        number1.MaxOccursString = "1"
        number1.Name = "number"
        phoneNumberSequence.Items.Add(number1)

        phoneNumber.Particle = phoneNumberSequence

        schema.Items.Add(phoneNumber)

        ' <xs:complexType name="localPhoneNumber">
        Dim localPhoneNumber As New XmlSchemaComplexType()
        localPhoneNumber.Name = "localPhoneNumber"

        ' <xs:complexContent>
        Dim complexContent As New XmlSchemaComplexContent()

        ' <xs:restriction base="phoneNumber">
        Dim restriction As New XmlSchemaComplexContentRestriction()
        restriction.BaseTypeName = New XmlQualifiedName("phoneNumber", "")

        ' <xs:sequence>
        Dim sequence2 As New XmlSchemaSequence()

        ' <xs:element name="areaCode" minOccurs="0"/>
        Dim areaCode2 As New XmlSchemaElement()
        areaCode2.MinOccurs = 0
        areaCode2.MaxOccursString = "1"
        areaCode2.Name = "areaCode"
        sequence2.Items.Add(areaCode2)

        ' <xs:element name="prefix"/>
        Dim prefix2 As New XmlSchemaElement()
        prefix2.MinOccurs = 1
        prefix2.MaxOccursString = "1"
        prefix2.Name = "prefix"
        sequence2.Items.Add(prefix2)

        ' <xs:element name="number"/>
        Dim number2 As New XmlSchemaElement()
        number2.MinOccurs = 1
        number2.MaxOccursString = "1"
        number2.Name = "number"
        sequence2.Items.Add(number2)

        restriction.Particle = sequence2
        complexContent.Content = restriction
        localPhoneNumber.ContentModel = complexContent

        schema.Items.Add(localPhoneNumber)

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