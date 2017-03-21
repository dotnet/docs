    Public Shared Sub GetElementErrors() 

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

        'Get the errors.
        Dim errors As ICollection = url.ElementInformation.Errors
        Console.WriteLine("Number of errors: {0)", _
        errors.Count.ToString())

    
    End Sub 'GetElementErrors 