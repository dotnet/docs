using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Services.Configuration;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace Samples.AspNet
{
    class UsingSystemWebSectionGroup
    {

        private static string name, type, declared, msg;
        private static SectionInformation info;


        [STAThread]
        static void Main(string[] args)
        {

            string inputStr = String.Empty;
            string option = String.Empty;

            // Define a regular expression to allow only 
            // alphanumeric inputs that are at most 20 character 
            // long. For instance "/iii:".
            Regex rex = new Regex(@"[^\/w]{1,20}:");

            // Parse the user's input.      
            if (args.Length < 1)
            {
                // No option entered.
                Console.Write("Input parameter missing.");
                return;
            }
            else
            {
                // Get the user's option.
                inputStr = args[0].ToLower();
                if (!(rex.Match(inputStr)).Success)
                {
                    // Wrong option format used.
                    Console.Write("Input parameter format not allowed.");
                    return;
                }
            }

            // <Snippet1>

            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the <system.web> group.
            SystemWebSectionGroup systemWeb =
              (SystemWebSectionGroup)configuration.GetSectionGroup("system.web");

            // </Snippet1>


            try
            {

                switch (inputStr)
                {

                    case "/anonymous:":
                        // <Snippet2>
                        // Get the anonymousIdentification section.
                        AnonymousIdentificationSection
                            anonymousIdentification =
                            systemWeb.AnonymousIdentification;
                        // Read section information.
                        info =
                            anonymousIdentification.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                          "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                          name, declared, type);
                        // </Snippet2>

                        Console.Write(msg);
                        break;

                    case "/authentication:":

                        // <Snippet3>
                        // Get the authentication section.
                        AuthenticationSection authentication =
                            systemWeb.Authentication;
                        // Read section information.
                        info =
                            authentication.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                          "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                          name, declared, type);
                        // </Snippet3>

                        Console.Write(msg);
                        break;

                    case "/authorization:":

                        // <Snippet4>
                        // Get the authorization section.
                        AuthorizationSection authorization =
                            systemWeb.Authorization;
                        // Read section information.
                        info =
                            authorization.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet4>

                        Console.Write(msg);
                        break;

                    case "/compilation:":

                        // <Snippet5>
                        // Get the compilation section.
                        CompilationSection compilation =
                            systemWeb.Compilation;
                        // Read section information.
                        info =
                            compilation.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet5>

                        Console.Write(msg);
                        break;


                    case "/customerrors:":

                        // <Snippet6>
                        // Get the customerrors section.
                        CustomErrorsSection customerrors =
                            systemWeb.CustomErrors;
                        // Read section information.
                        info =
                            customerrors.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet6>

                        Console.Write(msg);
                        break;

                    case "/globalization:":

                        // <Snippet7>
                        // Get the globalization section.
                        GlobalizationSection globalization =
                            systemWeb.Globalization;
                        // Read section information.
                        info =
                            globalization.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet7>

                        Console.Write(msg);
                        break;

                    case "/httpcookies:":
                        // <Snippet8>
                        // Get the httpCookies section.
                        HttpCookiesSection httpCookies =
                            systemWeb.HttpCookies;
                        // Read section information.
                        info =
                            httpCookies.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet8>

                        Console.Write(msg);
                        break;

                    case "/httphandlers:":

                        // <Snippet9>
                        // Get the httpHandlers section.
                        HttpHandlersSection httpHandlers =
                            systemWeb.HttpHandlers;
                        // Read section information.
                        info =
                            httpHandlers.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet9>

                        Console.Write(msg);
                        break;

                    case "/httpmodules:":

                        // <Snippet10>
                        // Get the httpModules section.
                        HttpModulesSection httpModules =
                            systemWeb.HttpModules;
                        // Read section information.
                        info =
                            httpModules.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet10>

                        Console.Write(msg);
                        break;

                    case "/httpruntime:":

                        // <Snippet11>
                        // Get the httpRuntime section.
                        HttpRuntimeSection httpRuntime =
                            systemWeb.HttpRuntime;
                        // Read section information.
                        info =
                            httpRuntime.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet11>

                        Console.Write(msg);
                        break;

                    case "/identity:":

                        // <Snippet12>
                        // Get the identity section.
                        IdentitySection identity =
                            systemWeb.Identity;
                        // Read section information.
                        info =
                            identity.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet12>

                        Console.Write(msg);
                        break;

                    case "/machinekey:":

                        // <Snippet13>
                        // Get the machineKey section.
                        MachineKeySection machineKey =
                            systemWeb.MachineKey;
                        // Read section information.
                        info =
                            machineKey.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet13>

                        Console.Write(msg);
                        break;

                    case "/membership:":
                        // <Snippet14>
                        // Get the membership section.
                        MembershipSection membership =
                            systemWeb.Membership;
                        // Read section information.
                        info =
                            membership.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet14>

                        Console.Write(msg);
                        break;

                    case "/pages:":
                        // <Snippet15>
                        // Get the pages section.
                        PagesSection pages =
                            systemWeb.Pages;
                        // Read section information.
                        info =
                            pages.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet15>

                        Console.Write(msg);
                        break;

                    case "/processModel:":
                        // <Snippet16>
                        // Get the processModel section.
                        ProcessModelSection processModel =
                            systemWeb.ProcessModel;
                        // Read section information.
                        info =
                            processModel.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet16>

                        Console.Write(msg);
                        break;

                    case "/profile:":
                        // <Snippet17>
                        // Get the profile section.
                        ProfileSection profile =
                            systemWeb.Profile;
                        // Read section information.
                        info =
                            profile.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet17>

                        Console.Write(msg);
                        break;

                    case "/roleManager:":
                        // <Snippet18>
                        // Get the roleManager section.
                        RoleManagerSection roleManager =
                            systemWeb.RoleManager;
                        // Read section information.
                        info =
                            roleManager.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet18>

                        Console.Write(msg);
                        break;

                    case "/securityPolicy:":
                        // <Snippet19>
                        // Get the securityPolicy section.
                        SecurityPolicySection securityPolicy =
                            systemWeb.SecurityPolicy;
                        // Read section information.
                        info =
                            securityPolicy.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet19>

                        Console.Write(msg);
                        break;

                    case "/sessionState:":
                        // <Snippet20>
                        // Get the sessionState section.
                        SessionStateSection sessionState =
                            systemWeb.SessionState;
                        // Read section information.
                        info =
                            sessionState.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet20>

                        Console.Write(msg);
                        break;

                    case "/sitemap:":
                        // <Snippet21>
                        // Get the siteMap section.
                        SiteMapSection siteMap =
                            systemWeb.SiteMap;
                        // Read section information.
                        info =
                            siteMap.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet21>

                        Console.Write(msg);
                        break;

                    case "/trace:":
                        // <Snippet22>
                        // Get the trace section.
                        TraceSection trace =
                            systemWeb.Trace;
                        // Read section information.
                        info =
                            trace.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet22>

                        Console.Write(msg);
                        break;

                    case "/trust:":
                        // <Snippet23>
                        // Get the trust section.
                        TrustSection trust =
                            systemWeb.Trust;
                        // Read section information.
                        info =
                            trust.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet23>

                        Console.Write(msg);
                        break;

                    case "/browserCaps:":
                        // <Snippet24>
                        // Get the browserCaps section.
                        DefaultSection browserCaps =
                            systemWeb.BrowserCaps;
                        // Read section information.
                        info = 
                            browserCaps.SectionInformation;
                        
                        name = info.SectionName ;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet24>

                        Console.Write(msg);
                        break;

                    case "/clientTarget:":
                        // <Snippet25>
                        // Get the clientTarget section.
                        ClientTargetSection clientTarget =
                            systemWeb.ClientTarget ;
                        // Read section information.
                        info =
                            clientTarget.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet25>

                        Console.Write(msg);
                        break;


                    case "/deployment:":
                        // <Snippet26>
                        // Get the deployment section.
                        DeploymentSection deployment =
                            systemWeb.Deployment;
                        // Read section information.
                        info =
                            deployment.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet26>

                        Console.Write(msg);
                        break;


                    case "/deviceFilters:":
                        // <Snippet27>
                        // Get the deviceFilters section.
                        DefaultSection deviceFilters =
                            systemWeb.DeviceFilters;
                        // Read section information.
                        info =
                            deviceFilters.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet27>

                        Console.Write(msg);
                        break;

                    case "/healthMonitoring:":
                        // <Snippet28>
                        // Get the healthMonitoring section.
                        HealthMonitoringSection healthMonitoring =
                            systemWeb.HealthMonitoring;
                        // Read section information.
                        info =
                            healthMonitoring.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet28>

                        Console.Write(msg);
                        break;

                    case "/hostingEnvironment:":
                        // <Snippet29>
                        // Get the hostingEnvironment section.
                        HostingEnvironmentSection hostingEnvironment =
                            systemWeb.HostingEnvironment;
                        // Read section information.
                        info =
                            hostingEnvironment.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet29>

                        Console.Write(msg);
                        break;

                    case "/mobileControls:":
                        // <Snippet30>
                        // Get the mobileControls section.
                        ConfigurationSection mobileControls =
                            systemWeb.MobileControls;
                        // Read section information.
                        info =
                            mobileControls.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet30>

                        Console.Write(msg);
                        break;

                    case "/protocols:":
                        // <Snippet31>
                        // Get the protocols section.
                        DefaultSection protocols =
                            systemWeb.Protocols;
                        // Read section information.
                        info =
                            protocols.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet31>

                        Console.Write(msg);
                        break;

                    case "/urlMappings:":
                        // <Snippet32>
                        // Get the urlMappings section.
                        UrlMappingsSection urlMappings =
                            systemWeb.UrlMappings;
                        // Read section information.
                        info =
                            urlMappings.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet32>

                        Console.Write(msg);
                        break;

                    case "/webControls:":
                        // <Snippet33>
                        // Get the webControls section.
                        WebControlsSection webControls =
                            systemWeb.WebControls;
                        // Read section information.
                        info =
                            webControls.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet33>

                        Console.Write(msg);
                        break;

                    case "/webParts:":
                        // <Snippet34>
                        // Get the webParts section.
                        WebPartsSection webParts =
                            systemWeb.WebParts;
                        // Read section information.
                        info =
                            webParts.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet34>

                        Console.Write(msg);
                        break;

                    case "/webServices:":
                        // <Snippet35>
                        // Get the webServices section.
                        WebServicesSection webServices =
                            systemWeb.WebServices;
                        // Read section information.
                        info =
                            webServices.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet35>

                        Console.Write(msg);
                        break;

                    case "/XhtmlConformance:":
                        // <Snippet36>
                        // Get the xhtmlConformance section.
                        XhtmlConformanceSection xhtmlConformance =
                            systemWeb.XhtmlConformance;
                        // Read section information.
                        info =
                            xhtmlConformance.SectionInformation;

                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);
                        // </Snippet36>

                        Console.Write(msg);
                        break;

                        
                    case "/all:":
                        StringBuilder allSections = new StringBuilder();
                        ConfigurationSectionGroup systemWebGroup =
                            configuration.GetSectionGroup("system.web");
                        int i = 0;
                        foreach (ConfigurationSection section in
                            systemWebGroup.Sections)
                        {
                            i += 1;
                            info = section.SectionInformation;
                            name = info.SectionName;
                            type = info.Type;
                            declared = info.IsDeclared.ToString();
                            if (i < 10)
                            {
                                msg = String.Format(
                                    "{0})Name:   {1}\nDeclared: {2}\nType:     {3}\n",
                                    i.ToString(), name, declared, type);
                            }
                            else
                            {
                                msg = String.Format(
                                     "{0})Name:  {1}\nDeclared: {2}\nType:     {3}\n",
                                     i.ToString(), name, declared, type);
                            }
                            allSections.AppendLine(msg);
                        }

                        // Console.WriteLine(systemWebGroup.Name);
                        // Console.WriteLine(systemWebGroup.SectionGroupName);

                        Console.Write(allSections.ToString());
                        break;

                    default:
                        // Option is not allowed..
                        Console.Write("Input not allowed.");
                        break;
                }
            }
            catch (ArgumentException e)
            {
                // Never display this. Use it for 
                // debugging purposes.
                msg = e.ToString();
            }

        }

    }
}
