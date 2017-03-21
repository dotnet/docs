    Public Shared Sub GetElementType() 

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
        
        ' Get the element type.
        Dim elType As Type = _
        url.ElementInformation.Type
        
        Console.WriteLine("Url element type: {0}", _
        elType.ToString())
    
    End Sub 'GetElementType
    