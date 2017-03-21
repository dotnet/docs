        ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <clientTarget> section.
        Dim clientTargetSection _
        As ClientTargetSection = _
        CType(configuration.GetSection( _
        "system.web/clientTarget"), _
        ClientTargetSection)

        ' Get the client target collection.
        Dim clientTargets _
        As ClientTargetCollection = _
        clientTargetSection.ClientTargets

