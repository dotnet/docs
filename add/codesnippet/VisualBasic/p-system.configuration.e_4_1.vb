    Public Shared Sub GetElementProperties() 
        
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
        
        ' Get the element properties.
        Dim properties _
        As PropertyInformationCollection = _
        url.ElementInformation.Properties
        
        Dim prop As PropertyInformation
        For Each prop In  properties
            Console.WriteLine("Name: {0} Type: {1}", _
            prop.Name, prop.Type.ToString())
        Next prop
    
    End Sub 'GetElementProperties
    