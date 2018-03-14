using System;
using System.Web.Configuration;

public class ConfigSectionSample
{
    public static void GetAuthServiceSection()
    {
        //<snippet1>
        // Get the Web application configuration.
        System.Configuration.Configuration configuration =
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

        // Get the external Web services section.
        ScriptingWebServicesSectionGroup webServicesSection =
            (ScriptingWebServicesSectionGroup)configuration.GetSectionGroup(
            "system.web.extensions/scripting/webServices");

        // Get the authentication service section.
        ScriptingAuthenticationServiceSection authenticationSection =
            webServicesSection.AuthenticationService;
        //</snippet1>
    }

    public static void GetProfileServiceSection()
    {
        //<snippet2>
        // Get the Web application configuration.
        System.Configuration.Configuration configuration =
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

        // Get the external Web services section.
        ScriptingWebServicesSectionGroup webServicesSection =
            (ScriptingWebServicesSectionGroup)configuration.GetSectionGroup(
            "system.web.extensions/scripting/webServices");

        // Get the profile service section.
        ScriptingProfileServiceSection profileSection =
            webServicesSection.ProfileService;
        //</snippet2>
    }

    public static void GetConverterElement()
    {
        //<snippet3>
        // Get the Web application configuration.
        System.Configuration.Configuration configuration =
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

        // Get the external JSON section.
        ScriptingJsonSerializationSection jsonSection =
            (ScriptingJsonSerializationSection)configuration.GetSection(
            "system.web.extensions/scripting/webServices/jsonSerialization");

        //Get the converters collection.
        ConvertersCollection converters =
            jsonSection.Converters;

        if ((converters != null) && converters.Count > 0)
        {
            // Get the first registered converter.
            Converter converterElement = converters[0];
        }
        //</snippet3>
    }

    public static void GetRoleServiceSection()
    {
        //<snippet4>
        // Get the Web application configuration.
        System.Configuration.Configuration configuration =
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

        // Get the external Web services section.
        ScriptingWebServicesSectionGroup webServicesSection =
            (ScriptingWebServicesSectionGroup)configuration.GetSectionGroup(
            "system.web.extensions/scripting/webServices");

        // Get the role service section.
        ScriptingRoleServiceSection roleSection =
            webServicesSection.RoleService;
        //</snippet4>
    }
}
