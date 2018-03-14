using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace Samples.AspNet
{
    class UsingWebControlsSection
    {
      
        static void Main(string[] args)
        {
           
            // <Snippet1>

            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the <webControls> section.
            WebControlsSection webControlsSection =
              (WebControlsSection)configuration.GetSection(
              "system.web/webControls");

            // Read the client script location.
            string clientScriptLocation =
                webControlsSection.ClientScriptsLocation;

            string msg = String.Format(
            "Client script location: {0}\n",
            clientScriptLocation);

            Console.Write(msg);

            // </Snippet1>
        }           
    }
}
