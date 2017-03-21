    Public Overrides Function ImportSchemaType(ByVal name As String, ByVal ns As String, ByVal context As XmlSchemaObject, ByVal schemas As XmlSchemas, ByVal importer As XmlSchemaImporter, ByVal compileUnit As CodeCompileUnit, ByVal codeNamespace As CodeNamespace, ByVal options As CodeGenerationOptions, ByVal codeGenerator As CodeDomProvider) As String 
        If name.Equals("Order") AndAlso ns.Equals("http://orders/") Then
            compileUnit.ReferencedAssemblies.Add("Order.dll")
            codeNamespace.Imports.Add(New CodeNamespaceImport("Microsoft.Samples"))           
            Return "Order"
        End If 
        
        Return Nothing
    
    End Function 'ImportSchemaType 