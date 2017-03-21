    Public Shared Function GetElementInformation() _
    As ElementInformation

        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = CType( _
        config.GetSection("MyUrls"), UrlsSection)

        ' Get the element.
        Dim url As UrlConfigElement = _
        section.Simple

        Dim eInfo As ElementInformation = _
        url.ElementInformation

        Return eInfo

    End Function 'GetElementInformation     