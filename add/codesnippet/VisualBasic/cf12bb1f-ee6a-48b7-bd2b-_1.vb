      ' Create a new module object.
        Dim ModuleAction As New HttpModuleAction( _
        "MyModuleName", "MyModuleType")
        ' Add the module to the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.Add(ModuleAction)
            configuration.Save()
        End If
