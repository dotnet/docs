    Public Shared Sub IsElementCollection() 
        
        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), _
        UrlsSection)
        
        ' Get the element.
        Dim url As UrlConfigElement = section.Simple
        
        ' Get the collection element.
        Dim urls As UrlsCollection = section.Urls
        
        Dim isCollection As Boolean = _
        url.ElementInformation.IsCollection
        Console.WriteLine("Url element is a collection? {0}", _
        isCollection.ToString())
        
        isCollection = _
        urls.ElementInformation.IsCollection
        Console.WriteLine("Urls element is a collection? {0}", _
        isCollection.ToString())
    
    End Sub 'IsElementCollection