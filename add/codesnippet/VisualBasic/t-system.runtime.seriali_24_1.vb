    Shared Function Import(ByVal schemas As XmlSchemaSet) As CodeCompileUnit 

        Dim imp As New XsdDataContractImporter()
       ' The EnableDataBinding option adds a RaisePropertyChanged method to
       ' the generated code. The GenerateInternal causes code access to be
       ' set to internal.
       Dim iOptions As New ImportOptions()
       iOptions.EnableDataBinding = true
       iOptions.GenerateInternal = true
       imp.Options = IOptions

        If imp.CanImport(schemas) Then
            imp.Import(schemas)
            Return imp.CodeCompileUnit
        Else
            Return Nothing
        End If
    End Function