'<snippet1>
Imports System.Xml
Imports System.Xml.Schema

Class XmlSchemaCreateExample

    Shared Sub Main()

        '<snippet2>
        ' Create the FirstName and LastName elements.
        Dim firstNameElement As XmlSchemaElement = New XmlSchemaElement()
        firstNameElement.Name = "FirstName"
        Dim lastNameElement As XmlSchemaElement = New XmlSchemaElement()
        lastNameElement.Name = "LastName"

        ' Create CustomerId attribute.
        Dim idAttribute As XmlSchemaAttribute = New XmlSchemaAttribute()
        idAttribute.Name = "CustomerId"
        idAttribute.Use = XmlSchemaUse.Required
        '</snippet2>

        '<snippet3>
        ' Create the simple type for the LastName element.
        Dim lastNameType As XmlSchemaSimpleType = New XmlSchemaSimpleType()
        lastNameType.Name = "LastNameType"
        Dim lastNameRestriction As XmlSchemaSimpleTypeRestriction = _
            New XmlSchemaSimpleTypeRestriction()
        lastNameRestriction.BaseTypeName = _
            New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        Dim maxLength As XmlSchemaMaxLengthFacet = New XmlSchemaMaxLengthFacet()
        maxLength.Value = "20"
        lastNameRestriction.Facets.Add(maxLength)
        lastNameType.Content = lastNameRestriction

        ' Associate the elements and attributes with their types.
        ' Built-in type.
        firstNameElement.SchemaTypeName = _
            New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        ' User-defined type.
        lastNameElement.SchemaTypeName = _
            New XmlQualifiedName("LastNameType", "http://www.tempuri.org")
        ' Built-in type.
        idAttribute.SchemaTypeName = New XmlQualifiedName("positiveInteger", _
            "http://www.w3.org/2001/XMLSchema")

        ' Create the top-level Customer element.
        Dim customerElement As XmlSchemaElement = New XmlSchemaElement()
        customerElement.Name = "Customer"

        ' Create an anonymous complex type for the Customer element.
        Dim customerType As XmlSchemaComplexType = New XmlSchemaComplexType()
        Dim sequence As XmlSchemaSequence = New XmlSchemaSequence()
        sequence.Items.Add(firstNameElement)
        sequence.Items.Add(lastNameElement)
        customerType.Particle = sequence

        ' Add the CustomerId attribute to the complex type.
        customerType.Attributes.Add(idAttribute)

        ' Set the SchemaType of the Customer element to
        ' the anonymous complex type created above.
        customerElement.SchemaType = customerType
        '</snippet3>

        '<snippet4>
        ' Create an empty schema.
        Dim customerSchema As XmlSchema = New XmlSchema()
        customerSchema.TargetNamespace = "http://www.tempuri.org"

        ' Add all top-level element and types to the schema
        customerSchema.Items.Add(customerElement)
        customerSchema.Items.Add(lastNameType)

        ' Create an XmlSchemaSet to compile the customer schema.
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        AddHandler schemaSet.ValidationEventHandler, AddressOf ValidationCallback
        schemaSet.Add(customerSchema)
        schemaSet.Compile()

        For Each schema As XmlSchema In schemaSet.Schemas()
            customerSchema = schema
        Next

        ' Write the complete schema to the Console.
        customerSchema.Write(Console.Out)
        '</snippet4>
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
