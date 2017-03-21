        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <system.web> group.
        Dim systemWeb As SystemWebSectionGroup = _
        CType(configuration.GetSectionGroup( _
        "system.web"), SystemWebSectionGroup)
