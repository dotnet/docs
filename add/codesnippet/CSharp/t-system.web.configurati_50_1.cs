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