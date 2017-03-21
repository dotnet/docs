
        // Remove the module from the collection.
        if (!httpModulesSection.SectionInformation.IsLocked)
        {
            modulesCollection.RemoveAt(0);
            configuration.Save();
        }
