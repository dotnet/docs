    Public Shared Sub GetElementSource() 

        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), UrlsSection)
        
        ' Get the element.
        Dim url As UrlConfigElement = _
        section.Simple
        
        ' Get the element source file.
        Dim sourceFile As String = _
        url.ElementInformation.Source
        
        Console.WriteLine( _
        "Url element source file: {0}", sourceFile)
    
    End Sub 'GetElementSource
    