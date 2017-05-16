using System;
using System.Configuration;
using System.Web.Configuration;
using System.Text;

namespace Samples.AspNet.Configuration
{
// Exercises the HttpModuleActionCollection members. 
class UsingHttpModuleActionCollection
{

    public static void Main()
    {

        // <Snippet1>
        // Get the Web application configuration.
        System.Configuration.Configuration configuration = 
            WebConfigurationManager.OpenWebConfiguration(
            "/aspnetTest");

        // Get the section.
        HttpModulesSection httpModulesSection = 
            (HttpModulesSection)configuration.GetSection(
            "system.web/httpModules");

        // Get the collection.
        HttpModuleActionCollection modulesCollection = 
            httpModulesSection.Modules;

        // </Snippet1>

        // <Snippet2>
        // Create a new HttpModuleActionCollection object.
        HttpModuleActionCollection newModuleActionCollection = 
            new HttpModuleActionCollection();

        // </Snippet2>

        //<Snippet3>
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

        //</Snippet3>

        //<Snippet4>
        // Set the module object.
        HttpModuleAction ModuleAction1 = 
            new HttpModuleAction("MyModule1Name",
            "MyModule1Type");
        // Get the module collection index.
        int moduleIndex = modulesCollection.IndexOf(ModuleAction1);

        //</Snippet4>


        //<Snippet5>
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

        //</Snippet5>


        //<Snippet6>

        // Remove the module from the collection.
        if (!httpModulesSection.SectionInformation.IsLocked)
        {
            modulesCollection.Remove("TimerModule");
            configuration.Save();
        }

        //</Snippet6>

        //<Snippet7>

        // Remove the module from the collection.
        if (!httpModulesSection.SectionInformation.IsLocked)
        {
            modulesCollection.RemoveAt(0);
            configuration.Save();
        }

        //</Snippet7>

        //<Snippet8>

        // Clear the collection.
        if (!httpModulesSection.SectionInformation.IsLocked)
        {
            modulesCollection.Clear();
            configuration.Save();
        }

        //</Snippet8>

    }

}
}

