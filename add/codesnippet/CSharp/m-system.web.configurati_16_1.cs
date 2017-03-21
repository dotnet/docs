
        // Clear the collection.
        if (!httpModulesSection.SectionInformation.IsLocked)
        {
            modulesCollection.Clear();
            configuration.Save();
        }
