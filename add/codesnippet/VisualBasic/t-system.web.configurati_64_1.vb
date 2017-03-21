        ' Get the applicaqtion configuration.
        Dim configuration _
        As Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the section.
        Dim anonymousIdentificationSection _
        As AnonymousIdentificationSection = _
        CType(configuration.GetSection( _
        "system.web/anonymousIdentification"), _
        AnonymousIdentificationSection)