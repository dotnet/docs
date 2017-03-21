
        // Remove the module from the collection.
        if (!httpModulesSection.SectionInformation.IsLocked)
        {
            modulesCollection.Remove("TimerModule");
            configuration.Save();
        }
