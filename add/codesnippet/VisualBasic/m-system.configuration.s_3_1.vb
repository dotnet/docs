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
     