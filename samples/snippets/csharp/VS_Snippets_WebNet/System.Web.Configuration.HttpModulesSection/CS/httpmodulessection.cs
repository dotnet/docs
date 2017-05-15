using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Samples.Aspnet.SystemWebConfiguration
{
// Exercises the HttpModulesSection members selected by the user. 
class UsingHttpModulesSection
{
 
public UsingHttpModulesSection()
{
 
 // <Snippet1>
 
// Get the Web application configuration.
Configuration configuration = WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

// Get the HttpModulesSection.
HttpModulesSection httpModulesSection = (HttpModulesSection) configuration.GetSection("system.web/httpModules");

// </Snippet1>

 

// <Snippet2>

// Create a new HttpModulesSection object.
HttpModulesSection newHttpModulesSection = new HttpModulesSection();

// </Snippet2>


// <Snippet3>

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
// </Snippet3>

}
 
} // UsingHttpModulesSection class end.

} // Samples.Aspnet.SystemWebManagement namespace end.

