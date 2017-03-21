    ' Create a section whose name is 
    ' MyUrls that contains a nested collection as 
    ' defined by the UrlsSection class.
    Shared Sub CreateSection()
        Dim sectionName As String = "MyUrls"

        Try

            ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim urlsSection As UrlsSection

            ' Create the section whose name
            ' attribute isMyUrls in 
            ' <configSections>.
            ' Also, create the related target section 
            ' MyUrls in <configuration>.
            If config.Sections(sectionName) Is Nothing Then
                urlsSection = New UrlsSection()

                ' Change the default values of 
                ' the simple element.
                urlsSection.Simple.Name = "Contoso"
                urlsSection.Simple.Url = "http://www.contoso.com"
                urlsSection.Simple.Port = 8080

                config.Sections.Add(sectionName, urlsSection)
                urlsSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            End If
        Catch e As ConfigurationErrorsException
            Console.WriteLine("[CreateSection: {0}]", e.ToString())
        End Try

    End Sub 'CreateSection
