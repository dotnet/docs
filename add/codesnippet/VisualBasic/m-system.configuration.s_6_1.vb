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
        
        ' Force the section information to be written to
        ' the configuration file.
        section.SectionInformation.ForceDeclaration(True)

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