'<snippet1>
Imports System
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

        ' Create a complex type for the FirstName element.
        Dim complexType As XmlSchemaComplexType = New XmlSchemaComplexType()
        complexType.Name = "FirstNameComplexType"

        ' Create a simple content extension with a base type of xs:string.
        Dim simpleContent As XmlSchemaSimpleContent = New XmlSchemaSimpleContent()
        Dim simpleContentExtension As XmlSchemaSimpleContentExtension = _
            New XmlSchemaSimpleContentExtension()
        simpleContentExtension.BaseTypeName = _
            New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' Create the new Title attribute with a SchemaTypeName of xs:string
        ' and add it to the simple content extension.
        Dim attribute As XmlSchemaAttribute = New XmlSchemaAttribute()
        attribute.Name = "Title"
        attribute.SchemaTypeName = _
            New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")
        simpleContentExtension.Attributes.Add(attribute)

        ' Set the content model of the simple content to the simple content extension
        ' and the content model of the complex type to the simple content.
        simpleContent.Content = simpleContentExtension
        complexType.ContentModel = simpleContent

        ' Add the new complex type to the pre-schema-compilation Items collection.
        customerSchema.Items.Add(complexType)

        ' Iterate over each XmlSchemaObject in the pre-schema-compilation
        ' Items collection.
        For Each schemaObject As XmlSchemaObject In customerSchema.Items

            ' If the XmlSchemaObject is an element, whose QualifiedName
            ' is "Customer", get the complex type of the Customer element
            ' and the sequence particle of the complex type.
            If schemaObject.GetType() Is GetType(XmlSchemaElement) Then

                Dim element As XmlSchemaElement = CType(schemaObject, XmlSchemaElement)

                If (element.QualifiedName.Name.Equals("Customer")) Then
                    Dim customerType As XmlSchemaComplexType = _
                        CType(element.ElementSchemaType, XmlSchemaComplexType)

                    Dim sequence As XmlSchemaSequence = _
                       CType(customerType.Particle, XmlSchemaSequence)

                    ' Iterate over each XmlSchemaParticle in the pre-schema-compilation
                    ' Items property.
                    For Each particle As XmlSchemaParticle In sequence.Items

                        ' If the XmlSchemaParticle is an element, who's QualifiedName
                        ' is "FirstName", set the SchemaTypeName of the FirstName element
                        ' to the new FirstName complex type.
                        If particle.GetType() Is GetType(XmlSchemaElement) Then
                            Dim childElement As XmlSchemaElement = _
                                CType(particle, XmlSchemaElement)

                            If childElement.Name.Equals("FirstName") Then
                                childElement.SchemaTypeName = _
                                   New XmlQualifiedName("FirstNameComplexType", _
                                  "http://www.tempuri.org")
                            End If
                        End If
                    Next
                End If
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