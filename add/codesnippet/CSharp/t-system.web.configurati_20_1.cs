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