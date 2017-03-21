        ' Remove the module from the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.RemoveAt(0)
            configuration.Save()
        End If
