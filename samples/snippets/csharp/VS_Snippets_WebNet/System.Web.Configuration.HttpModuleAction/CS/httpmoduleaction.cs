using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
    // Accesses the System.Web.Configuration.HttpModuleAction 
    // members selected by the user.
    class UsingHttpModuleAction
    {

        public static void Main()
        {
            // <Snippet1>

            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

            // Get the section. 
            HttpModulesSection httpModulesSection = 
                (HttpModulesSection) configuration.GetSection(
                "system.web/httpModules");

            // </Snippet1>


            // <Snippet2>
            // Create a new section object.
            HttpModuleAction newModuleAction =
                new HttpModuleAction("MyModule", 
                "MyModuleType");

            // </Snippet2>


            // <Snippet3>

            // Initialize the module name and type properties.
            newModuleAction.Name = "ModuleName";
            newModuleAction.Type = "ModuleType";

            // </Snippet3>

            // <Snippet4>

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
            // </Snippet4>



            // <Snippet5>

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

            // </Snippet5>

        }

    }


} 
