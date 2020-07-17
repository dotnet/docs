'<snippet1>
Imports System.Xml
Imports System.Xml.Schema

Class XmlSchemaEditExample

    Shared Sub Main()

        ' Add the customer schema to a new XmlSchemaSet and compile it.
        ' Any schema validation warnings and errors encountered reading or 
        ' compiling the schema are handled by the ValidationEventHandler delegate.
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        AddHandler schemaSet.ValidationEventHandler, AddressOf ValidationCallback
        schemaSet.Add("http://www.tempuri.org", "customer.xsd")
        schemaSet.Compile()

        ' Retrieve the compiled XmlSchema object from the XmlSchemaSet
        ' by iterating over the Schemas property.
        Dim customerSchema As XmlSchema = Nothing
        For Each schema As XmlSchema In schemaSet.Schemas()
            customerSchema = schema
        Next

        ' Create the PhoneNumber element.
        Dim phoneElement As XmlSchemaElement = New XmlSchemaElement()
        phoneElement.Name = "PhoneNumber"

        ' Create the xs:string simple type restriction.
        Dim phoneType As XmlSchemaSimpleType = New XmlSchemaSimpleType()
        Dim restriction As XmlSchemaSimpleTypeRestriction = _
            New XmlSchemaSimpleTypeRestriction()
        restriction.BaseTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' Add a pattern facet to the restriction.
        Dim phonePattern As XmlSchemaPatternFacet = New XmlSchemaPatternFacet()
        phonePattern.Value = "\\d{3}-\\d{3}-\\d(4)"
        restriction.Facets.Add(phonePattern)

        ' Add the restriction to the Content property of the simple type
        ' and the simple type to the SchemaType of the PhoneNumber element.
        phoneType.Content = restriction
        phoneElement.SchemaType = phoneType

        ' Iterate over each XmlSchemaElement in the Values collection
        ' of the Elements property.
        For Each element As XmlSchemaElement In customerSchema.Elements.Values

            ' If the qualified name of the element is "Customer", 
            ' get the complex type of the Customer element  
            ' and the sequence particle of the complex type.
            If element.QualifiedName.Name.Equals("Customer") Then

                Dim customerType As XmlSchemaComplexType = _
                    CType(element.ElementSchemaType, XmlSchemaComplexType)
                Dim sequence As XmlSchemaSequence = _
                    CType(customerType.Particle, XmlSchemaSequence)

                ' Add the new PhoneNumber element to the sequence.
                sequence.Items.Add(phoneElement)
            End If
        Next

        ' Reprocess and compile the modified XmlSchema object and write it to the console.
        schemaSet.Reprocess(customerSchema)
        schemaSet.Compile()
        customerSchema.Write(Console.Out)
    End Sub

    Shared Sub ValidationCallback(ByVal sender As Object, ByVal args As ValidationEventArgs)
        If args.Severity = XmlSeverityType.Warning Then
            Console.Write("WARNING: ")
        Else
            If args.Severity = XmlSeverityType.Error Then
                Console.Write("ERROR: ")
            End If
        End If
        Console.WriteLine(args.Message)
    End Sub

End Class
'</snippet1>
