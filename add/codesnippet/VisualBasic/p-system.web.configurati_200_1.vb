      ' Get the modules collection.
        Dim httpModules2 _
        As HttpModuleActionCollection = httpModulesSection.Modules
        Dim typeFound As String = _
        "typeName not found."
      
      ' Find the module with the specified type.
        Dim currentModule1 As HttpModuleAction
        For Each currentModule1 In httpModules2
            If currentModule1.Type = "typeName" Then
                typeFound = "typeName found."
            End If
        Next currentModule1