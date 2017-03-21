        ' Set the module object.
        Dim ModuleAction2 As New HttpModuleAction( _
        "MyModule2Name", "MyModule2Type")
        ' Remove the module from the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.Remove(ModuleAction2)
            configuration.Save()
        End If
