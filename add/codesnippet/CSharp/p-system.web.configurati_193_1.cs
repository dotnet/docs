
            // Get the modules collection.
            HttpModuleActionCollection httpModules = 
                httpModulesSection.Modules;
            string moduleFound = "moduleName not found.";

            // Find the module with the specified name.
            foreach (HttpModuleAction currentModule in httpModules)
            {
                if (currentModule.Name == "moduleName")
                    moduleFound = "moduleName found.";

            }