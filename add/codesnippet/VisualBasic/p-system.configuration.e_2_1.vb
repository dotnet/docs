    Public Shared Sub IsElementLocked() 

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
        
        Dim isLocked As Boolean = _
        url.ElementInformation.IsLocked
        Console.WriteLine("Url element is locked? {0}", _
        isLocked.ToString())
    
    End Sub 'IsElementLocked