    Public Shared Function GetSectionInformation() _
    As SectionInformation

        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), UrlsSection)

        Dim sInfo As SectionInformation = _
        section.SectionInformation

        Return sInfo

    End Function 'GetSectionInformation
     