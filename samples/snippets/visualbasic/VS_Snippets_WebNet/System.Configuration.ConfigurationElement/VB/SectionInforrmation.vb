 ' File name: SectionInformation.cs
' Allowed snippet tags range: [91 - 120].
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration



Class UsingSectionInformation
    
    
    ' <Snippet91>
    Public Shared Function GetSectionInformation() _
    As SectionInformation

        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), UrlsSection)

        Dim sInfo As SectionInformation = _
        section.SectionInformation

        Return sInfo

    End Function 'GetSectionInformation
     
    ' </Snippet91>

    ' <Snippet92>
    Public Shared Sub GetParentSection() 

        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim parentSection _
        As ConfigurationSection = _
        sInfo.GetParentSection()
        
        Console.WriteLine("Parent section : {0}", _
        parentSection.SectionInformation.Name)
    
    End Sub 'GetParentSection
    ' </Snippet92>

    ' <Snippet93>
    Public Shared Sub GetSectionXml()

        Dim sInfo As SectionInformation = _
        GetSectionInformation()

        Dim sectionXml As String = sInfo.GetRawXml()

        Console.WriteLine("Section xml:")
        Console.WriteLine(sectionXml)

    End Sub 'GetSectionXml
     
    ' </Snippet93>

    ' <Snippet94>
    Public Shared Sub ProtectSection() 
        
        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        
        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), UrlsSection)
        
        
        ' Protect (encrypt)the section.
        section.SectionInformation.ProtectSection( _
        "RsaProtectedConfigurationProvider")
        
        ' Save the encrypted section.
        section.SectionInformation.ForceSave = True
        
        config.Save(ConfigurationSaveMode.Full)
        
        ' Display decrypted configuration 
        ' section. Note, the system
        ' uses the Rsa provider to decrypt
        ' the section transparently.
        Dim sectionXml As String = _
        section.SectionInformation.GetRawXml()
        
        Console.WriteLine("Decrypted section:")
        Console.WriteLine(sectionXml)
    
    End Sub 'ProtectSection
     
    ' </Snippet94>

    Public Shared Sub GetAllowProperties()

        ' <Snippet95>
        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), UrlsSection)

        Dim sInfo As SectionInformation = _
        section.SectionInformation
        ' </Snippet95>

        ' <Snippet96>  
        Dim allowDefinition _
        As ConfigurationAllowDefinition = _
        sInfo.AllowDefinition
        Console.WriteLine("Allow definition: {0}", _
        allowDefinition.ToString())
        ' </Snippet96>  

        ' <Snippet97>  
        Dim allowExeDefinition _
        As ConfigurationAllowExeDefinition = _
        sInfo.AllowExeDefinition
        Console.WriteLine("Allow exe definition: {0}", _
        allowExeDefinition.ToString())
        ' </Snippet97>  

        ' <Snippet98>  
        Dim allowLocation As Boolean = _
        sInfo.AllowLocation
        Console.WriteLine("Allow location: {0}", _
        allowLocation.ToString())
        ' </Snippet98>  

        ' <Snippet99>  
        Dim allowOverride As Boolean = _
        sInfo.AllowOverride
        Console.WriteLine("Allow override: {0}", _
        allowOverride.ToString())
        ' </Snippet99>  

    End Sub 'GetAllowProperties
    
    
    ' <Snippet100>  
    Public Shared Sub GetInheritInChildApps() 

        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim inheritInChildApps As Boolean = _
        sInfo.InheritInChildApplications
        Console.WriteLine("Inherit in child apps: {0}", _
        inheritInChildApps.ToString())

    End Sub 'GetInheritInChildApps    
    ' </Snippet100>  

    Public Shared Sub GetIsProperties() 

        ' <Snippet102>
        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), UrlsSection)
                
        Dim sInfo As SectionInformation = _
        section.SectionInformation
        ' </Snippet102>

        ' <Snippet103>
        Dim declRequired As Boolean = _
        sInfo.IsDeclarationRequired
        Console.WriteLine("Declaration required?: {0}", _
        declRequired.ToString())
        ' </Snippet103>

        ' <Snippet104>
        Dim declared As Boolean = _
        sInfo.IsDeclared
        Console.WriteLine("Section declared?: {0}", _
        declared.ToString())
        ' </Snippet104>

        ' <Snippet105>
        Dim locked As Boolean = _
        sInfo.IsLocked
        Console.WriteLine("Section locked?: {0}", _
        locked.ToString())
        ' </Snippet105>

        ' <Snippet106>
        Dim protect As Boolean = _
        sInfo.IsProtected
        Console.WriteLine("Section protected?: {0}", _
        protect.ToString())
        ' </Snippet106>

    End Sub 'GetIsProperties
    
    
    ' <Snippet107>
    Public Shared Sub GetSectionNameProperty() 

        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim sectionNameProperty _
        As String = sInfo.Name
        Console.WriteLine("Section name: {0}", _
        sectionNameProperty)
    
    End Sub 'GetSectionNameProperty
    ' </Snippet107>
    
    ' <Snippet108>
    Public Shared Sub GetProtectionProvider()

        Dim sInfo As SectionInformation = _
        GetSectionInformation()

        Dim pp _
        As ProtectedConfigurationProvider = _
        sInfo.ProtectionProvider
        If pp Is Nothing Then
            Console.WriteLine("Protection provider is null")
        Else
            Console.WriteLine("Protection provider: {0}", _
            pp.ToString())
        End If

    End Sub 'GetProtectionProvider
    ' </Snippet108>
    
    ' <Snippet109>
    Public Shared Sub RestartOnExternalChanges()

        Dim sInfo As SectionInformation = _
        GetSectionInformation()

        Dim restartOnChange As Boolean = _
        sInfo.RestartOnExternalChanges
        Console.WriteLine("Section type: {0}", _
        restartOnChange.ToString())

    End Sub 'RestartOnExternalChanges
    ' </Snippet109>

    ' <Snippet110>
    Public Shared Sub GetSectionName() 
        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim sectionName As String = _
        sInfo.SectionName
        Console.WriteLine("Section type: {0}", _
        sectionName)
    End Sub 'GetSectionName
    ' </Snippet110>
    
    ' <Snippet111>
    Public Shared Sub GetSectionType() 
        Dim sInfo As SectionInformation = _
        GetSectionInformation()
        
        Dim sectionType As String = sInfo.Type
        Console.WriteLine("Section type: {0}", _
        sectionType)
    
    End Sub 'GetSectionType
    ' </Snippet111>
    
    ' <Snippet112>
    Public Shared Sub UnProtectSection() 
        
        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the section.
        Dim section As UrlsSection = _
        CType(config.GetSection("MyUrls"), UrlsSection)
        
        ' Unprotect (decrypt)the section.
        section.SectionInformation.UnprotectSection()
        
        ' <Snippet113>
        ' Force the section information to be written to
        ' the configuration file.
        section.SectionInformation.ForceDeclaration(True)
        ' </Snippet113>

        ' Save the decrypted section.
        section.SectionInformation.ForceSave = True
        
        config.Save(ConfigurationSaveMode.Full)
        
        ' Display the decrypted configuration 
        ' section. 
        Dim sectionXml As String = _
        section.SectionInformation.GetRawXml()
        
        Console.WriteLine("Decrypted section:")
        Console.WriteLine(sectionXml)
    
    End Sub 'UnProtectSection 
    ' </Snippet112>

End Class 'UsingSectionInformation
