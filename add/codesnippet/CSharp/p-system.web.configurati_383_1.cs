
// Get the modules collection.
HttpModuleActionCollection httpModules = httpModulesSection.Modules;

// Read the modules information.
StringBuilder modulesInfo = new StringBuilder();
for (int i = 0; i < httpModules.Count; i++)
{
  modulesInfo.Append(
   string.Format("Name: {0}\nType: {1}\n\n", httpModules[i].Name, 
   httpModules[i].Type));
}