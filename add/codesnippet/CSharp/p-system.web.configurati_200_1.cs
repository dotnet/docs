
            // Get the modules collection.
            HttpModuleActionCollection httpModules2 = 
                httpModulesSection.Modules;
            string typeFound = "typeName not found.";

            // Find the module with the specified type.
            foreach (HttpModuleAction currentModule in httpModules2)
            {
                if (currentModule.Type == "typeName")
                    typeFound = "typeName found.";
            }
