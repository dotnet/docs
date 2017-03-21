    Public Shared Sub IsElementPresent() 

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
        
        Dim isPresent As Boolean = _
        url.ElementInformation.IsPresent
        Console.WriteLine("Url element is present? {0}", _
        isPresent.ToString())
    
    End Sub 'IsElementPresent
    