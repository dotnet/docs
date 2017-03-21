        ' Remove the module from the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.Remove("MyModule2Name")
            configuration.Save()
        End If
