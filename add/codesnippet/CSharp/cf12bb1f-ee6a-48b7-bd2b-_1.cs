        // Create a new module object.
        
        HttpModuleAction ModuleAction = 
            new HttpModuleAction("MyModuleName", 
            "MyModuleType");
        // Add the module to the collection.
        if (!httpModulesSection.SectionInformation.IsLocked)
        {
            modulesCollection.Add(ModuleAction);
            configuration.Save();
        }
