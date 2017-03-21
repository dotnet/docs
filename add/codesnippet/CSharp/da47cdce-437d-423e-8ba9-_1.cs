        // Set the module object.
        HttpModuleAction ModuleAction2 = 
            new HttpModuleAction("MyModule2Name",
            "MyModule2Type");

        // Remove the module from the collection.
        if (!httpModulesSection.SectionInformation.IsLocked)
        {
            modulesCollection.Remove(ModuleAction2);
            configuration.Save();
        }
