    Shared Sub ExportXSD() 

        Dim exporter As New XsdDataContractExporter()

        ' Use the ExportOptions to add the Possessions type to the 
        ' collection of KnownTypes. 
        Dim eOptions As New ExportOptions()
        eOptions.KnownTypes.Add(GetType(Possessions))        
        exporter.Options = eOptions

        If exporter.CanExport(GetType(Employee)) Then
            exporter.Export(GetType(Employee))
            Console.WriteLine("number of schemas: {0}", exporter.Schemas.Count)
            Console.WriteLine()
            Dim mySchemas As XmlSchemaSet = exporter.Schemas
            
            Dim XmlNameValue As XmlQualifiedName = _
               exporter.GetRootElementName(GetType(Employee))
            Dim EmployeeNameSpace As String = XmlNameValue.Namespace
            
            Dim schema As XmlSchema
            For Each schema In  mySchemas.Schemas(EmployeeNameSpace)
                schema.Write(Console.Out)
            Next schema
        End If
    
    End Sub 
    