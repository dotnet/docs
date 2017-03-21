        ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <urlMapping> section.
        Dim urlMappingSection _
        As UrlMappingsSection = _
        CType(configuration.GetSection( _
        "system.web/urlMappings"), UrlMappingsSection)

        ' Get the url mapping collection.
        Dim urlMappings _
        As UrlMappingCollection = _
        urlMappingSection.UrlMappings
