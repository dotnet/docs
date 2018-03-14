' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()
        Dim schema As New XmlSchema()

        ' <xs:element name="cat" type="xs:string"/>
        Dim elementCat As New XmlSchemaElement()
        schema.Items.Add(elementCat)
        elementCat.Name = "cat"
        elementCat.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:element name="dog" type="xs:string"/>
        Dim elementDog As New XmlSchemaElement()
        schema.Items.Add(elementDog)
        elementDog.Name = "dog"
        elementDog.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' <xs:element name="redDog" substitutionGroup="dog" />
        Dim elementRedDog As New XmlSchemaElement()
        schema.Items.Add(elementRedDog)
        elementRedDog.Name = "redDog"
        elementRedDog.SubstitutionGroup = New XmlQualifiedName("dog")

        ' <xs:element name="brownDog" substitutionGroup ="dog" />
        Dim elementBrownDog As New XmlSchemaElement()
        schema.Items.Add(elementBrownDog)
        elementBrownDog.Name = "brownDog"
        elementBrownDog.SubstitutionGroup = New XmlQualifiedName("dog")

        ' <xs:element name="pets">
        Dim elementPets As New XmlSchemaElement()
        schema.Items.Add(elementPets)
        elementPets.Name = "pets"

        ' <xs:complexType>
        Dim complexType As New XmlSchemaComplexType()
        elementPets.SchemaType = complexType

        ' <xs:choice minOccurs="0" maxOccurs="unbounded">
        Dim choice As New XmlSchemaChoice()
        complexType.Particle = choice
        choice.MinOccurs = 0
        choice.MaxOccursString = "unbounded"

        ' <xs:element ref="cat"/>
        Dim catRef As New XmlSchemaElement()
        choice.Items.Add(catRef)
        catRef.RefName = New XmlQualifiedName("cat")

        ' <xs:element ref="dog"/>
        Dim dogRef As New XmlSchemaElement()
        choice.Items.Add(dogRef)
        dogRef.RefName = New XmlQualifiedName("dog")

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