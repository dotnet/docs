'<snippet1>
Imports System.Xml
Imports System.Xml.Schema

Class XmlSchemaImportExample

    Shared Sub Main()
        ' Add the customer and address schemas to a new XmlSchemaSet and compile them.
        ' Any schema validation warnings and errors encountered reading or 
        ' compiling the schemas are handled by the ValidationEventHandler delegate.
        Dim schemaSet As XmlSchemaSet = New XmlSchemaSet()
        AddHandler schemaSet.ValidationEventHandler, AddressOf ValidationCallback
        schemaSet.Add("http://www.tempuri.org", "customer.xsd")
        schemaSet.Add("http://www.example.com/IPO", "address.xsd")
        schemaSet.Compile()

        ' Retrieve the compiled XmlSchema objects for the customer and
        ' address schema from the XmlSchemaSet by iterating over 
        ' the Schemas property.
        Dim customerSchema As XmlSchema = Nothing
        Dim addressSchema As XmlSchema = Nothing
        For Each schema As XmlSchema In schemaSet.Schemas()
            If schema.TargetNamespace = "http://www.tempuri.org" Then
                customerSchema = schema
            ElseIf schema.TargetNamespace = "http://www.example.com/IPO" Then
                addressSchema = schema
            End If
        Next

        ' Create an XmlSchemaImport object, set the Namespace property
        ' to the namespace of the address schema, the Schema property 
        ' to the address schema, and add it to the Includes property
        ' of the customer schema.
        Dim import As XmlSchemaImport = New XmlSchemaImport()
        import.Namespace = "http://www.example.com/IPO"
        import.Schema = addressSchema
        customerSchema.Includes.Add(import)

        ' Reprocess and compile the modified XmlSchema object 
        ' of the customer schema and write it to the console.    
        schemaSet.Reprocess(customerSchema)
        schemaSet.Compile()
        customerSchema.Write(Console.Out)

        ' Recursively write all of the schemas imported into the
        ' customer schema to the console using the Includes 
        ' property of the customer schema.
        RecurseExternals(customerSchema)
    End Sub

    Shared Sub RecurseExternals(ByVal schema As XmlSchema)
        For Each external As XmlSchemaExternal In Schema.Includes

            If Not external.SchemaLocation = Nothing Then
                Console.WriteLine("External SchemaLocation: {0}", external.SchemaLocation)
            End If

            If external.GetType() Is GetType(XmlSchemaImport) Then
                Dim import As XmlSchemaImport = CType(external, XmlSchemaImport)
                Console.WriteLine("Imported namespace: {0}", import.Namespace)
            End If

            If Not external.Schema Is Nothing Then
                external.Schema.Write(Console.Out)
                RecurseExternals(external.Schema)
            End If
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
