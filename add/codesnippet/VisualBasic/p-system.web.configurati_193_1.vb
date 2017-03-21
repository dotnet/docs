      ' Get the modules collection.
        Dim httpModules _
        As HttpModuleActionCollection = httpModulesSection.Modules
        Dim moduleFound As String = _
        "moduleName not found."
      
      ' Find the module with the specified name.
      Dim currentModule As HttpModuleAction
      For Each currentModule In  httpModules
         If currentModule.Name = "moduleName" Then
            moduleFound = "moduleName found."
         End If 
      Next currentModule