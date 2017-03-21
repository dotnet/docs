    Public Shared Sub GetElementValidator() 

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
        Dim elValidator _
        As ConfigurationValidatorBase = _
        url.ElementInformation.Validator
        
        Console.WriteLine("Url element validator: {0}", _
        elValidator.ToString())
    
    End Sub 'GetElementValidator    