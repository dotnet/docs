        ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <sessionPageState> section.
        Dim sessionPageState _
        As SessionPageStateSection = _
        CType(configuration.GetSection( _
        "system.web/sessionPageState"), _
        SessionPageStateSection)
