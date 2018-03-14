 ' File name: ElementInformation.cs
' Allowed snippet tags range: [71 - 90].
Imports System
' using System.Collections.Generic;
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Text
Imports System.Configuration



Class UsingElementInformation
    
    
    ' <Snippet80>
    Public Shared Function GetElementInformation() _
    As ElementInformation

        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = CType( _
        config.GetSection("MyUrls"), UrlsSection)

        ' Get the element.
        Dim url As UrlConfigElement = _
        section.Simple

        Dim eInfo As ElementInformation = _
        url.ElementInformation

        Return eInfo

    End Function 'GetElementInformation     
    ' </Snippet80>

    ' <Snippet81>
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
    ' </Snippet81>

    ' <Snippet82>
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
    ' </Snippet82>

    ' <Snippet83>
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
    
    ' </Snippet83>

    ' <Snippet84>
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
    
    ' </Snippet84>

    ' <Snippet85>
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
    
    ' </Snippet85>

    ' <Snippet86>
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
    
    ' </Snippet86>

    ' <Snippet87>
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
    
    ' </Snippet87>

    ' <Snippet88>
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
    ' </Snippet88>

    ' <Snippet89>
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
    ' </Snippet89>

End Class 'UsingElementInformation 

