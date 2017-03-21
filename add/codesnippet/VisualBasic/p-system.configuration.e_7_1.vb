    Public Shared Sub GetElementLineNumber() 

        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), UrlsSection)
        
        ' Get the collection element.
        Dim urls As UrlsCollection = _
        section.Urls
        
        Dim ln As Integer = _
        urls.ElementInformation.LineNumber

        Console.WriteLine("Urls element line number: {0}", _
        ln.ToString())
    
    End Sub 'GetElementLineNumber
    