        ' Clear the collection.
        If Not httpModulesSection.SectionInformation.IsLocked Then
            modulesCollection.Clear()
            configuration.Save()
        End If