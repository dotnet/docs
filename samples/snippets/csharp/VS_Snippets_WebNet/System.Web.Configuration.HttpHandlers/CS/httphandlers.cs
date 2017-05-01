using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
    // Accesses the System.Web.Configuration.HttpHandlersSection
    // members selected by the user.
    class UsingHttpHandlersSection
    {
        public UsingHttpHandlersSection()
        {
            // Process the
            // System.Web.Configuration.HttpHandlersSectionobject.
            try
            {
// <Snippet1>

     // Get the Web application configuration.
     System.Configuration.Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnetTest");
                
     // Get the section.
     System.Web.Configuration.HttpHandlersSection httpHandlersSection = (System.Web.Configuration.HttpHandlersSection) configuration.GetSection("system.web/httphandlers");


// </Snippet1>

// <Snippet2>

     // Get the handlers.
     System.Web.Configuration.HttpHandlerActionCollection httpHandlers = httpHandlersSection.Handlers;

// </Snippet2>


// <Snippet3>
// Add a new HttpHandlerAction to the Handlers property HttpHandlerAction collection.
httpHandlersSection.Handlers.Add(new HttpHandlerAction(
    "Calculator.custom", 
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler", 
    "GET", 
    true));
// </Snippet3>

// <Snippet4>
// Get a HttpHandlerAction in the Handlers property HttpHandlerAction collection.
HttpHandlerAction httpHandler = httpHandlers[0];

// </Snippet4>

// <Snippet5>
// Change the Path for the HttpHandlerAction.
httpHandler.Path = "Calculator.custom";
// </Snippet5>

// <Snippet6>
// Change the Type for the HttpHandlerAction.
httpHandler.Type = 
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler";
// </Snippet6>

// <Snippet7>
// Change the Verb for the HttpHandlerAction.
httpHandler.Verb = "POST";
// </Snippet7>

// <Snippet8>
// Change the Validate for the HttpHandlerAction.
httpHandler.Validate = false;
// </Snippet8>

// <Snippet9>

    // Get the specified handler's index.
    HttpHandlerAction httpHandler2 = new HttpHandlerAction(
    "Calculator.custom",
    "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler",
    "GET", true);
    int handlerIndex = httpHandlers.IndexOf(httpHandler2);

// </Snippet9>


// <Snippet10>

// Remove a HttpHandlerAction object 
    HttpHandlerAction httpHandler3 = new HttpHandlerAction(
     "Calculator.custom",
     "Samples.Aspnet.SystemWebConfiguration.Calculator, CalculatorHandler",
     "GET", true);
    httpHandlers.Remove(httpHandler3);
// </Snippet10>

// <Snippet11>

    // Remove a HttpHandlerAction object with 0 index.
    httpHandlers.RemoveAt(0);

// </Snippet11>

// <Snippet12>
    // Clear all CustomError objects from the Handlers property HttpHandlerAction collection.
    httpHandlers.Clear();

// </Snippet12>

// <Snippet13>

    // Remove the handler with the specified verb and path.
    httpHandlers.Remove("GET", "*.custom");

// </Snippet13>

Console.WriteLine("List the Errors collection:");
int handlerActionCtr = 0;
foreach (HttpHandlerAction handlerAction in httpHandlersSection.Handlers)
{

// <Snippet14>
  string type = handlerAction.Type;
// </Snippet14>
// <Snippet15>
  string verb = handlerAction.Verb;
// </Snippet15>
// <Snippet16>
  bool validation = handlerAction.Validate;
// </Snippet16>
  
  Console.WriteLine("  {0}: message", ++handlerActionCtr);
}

              // Update if not locked.
                if (! httpHandlersSection.SectionInformation.IsLocked)
                {
                    configuration.Save();
                    Console.WriteLine("** Configuration updated.");
                }
                else
                    Console.WriteLine("** Could not update, section is locked.");
            }
            catch (System.ArgumentException e)
            {
                // Unknown error.
                Console.WriteLine(e.ToString());
            }
        }
    } // UsingHttpHandlersSection class end.
    
} // Samples.Aspnet.SystemWebConfiguration namespace end.

