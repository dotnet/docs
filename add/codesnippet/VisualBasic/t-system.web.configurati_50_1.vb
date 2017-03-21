        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the external Web services section.
        Dim webServicesSection As ScriptingWebServicesSectionGroup = _
            CType(configuration.GetSectionGroup( _
            "system.web.extensions/scripting/webServices"), ScriptingWebServicesSectionGroup)

        ' Get the profile service section.
        Dim profileSection _
            As ScriptingProfileServiceSection = _
            webServicesSection.ProfileService