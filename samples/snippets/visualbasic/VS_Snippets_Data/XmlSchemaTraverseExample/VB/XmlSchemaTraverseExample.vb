'<snippet1>
Imports System
Imports System.Collections
Imports System.Xml
Imports System.Xml.Schema

Class XmlSchemaTraverseExample

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

        ' Iterate over each XmlSchemaElement in the Values collection
        ' of the Elements property.
        For Each element As XmlSchemaElement In customerSchema.Elements.Values

            Console.WriteLine("Element: {0}", element.Name)

            ' Get the complex type of the Customer element.
            Dim complexType As XmlSchemaComplexType = CType(element.ElementSchemaType, XmlSchemaComplexType)

            ' If the complex type has any attributes, get an enumerator 
            ' and write each attribute name to the console.
            If complexType.AttributeUses.Count > 0 Then

                Dim enumerator As IDictionaryEnumerator = _
                    complexType.AttributeUses.GetEnumerator()

                While enumerator.MoveNext()

                    Dim attribute As XmlSchemaAttribute = _
                        CType(enumerator.Value, XmlSchemaAttribute)

                    Console.WriteLine("Attribute: {0}", Attribute.Name)
                End While
            End If

            ' Get the sequence particle of the complex type.
            Dim sequence As XmlSchemaSequence = CType(complexType.ContentTypeParticle, XmlSchemaSequence)

            For Each childElement As XmlSchemaElement In sequence.Items
                Console.WriteLine("Element: {0}", childElement.Name)
            Next
        Next

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