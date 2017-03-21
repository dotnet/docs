        ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <caching> section group.
        Dim cachingSectionGroup _
        As SystemWebCachingSectionGroup = _
        CType(configuration.GetSectionGroup( _
        "system.web/caching"), SystemWebCachingSectionGroup)