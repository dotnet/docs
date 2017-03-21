   ' Create a custom section.
   Shared Sub CreateSection()
      Try
         
         Dim customSection As CustomSection
         
         ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)
         
         ' Create the section entry  
         ' in the <configSections> and the 
         ' related target section in <configuration>.
         If config.Sections("CustomSection") Is Nothing Then
            customSection = New CustomSection()
            config.Sections.Add("CustomSection", customSection)
            customSection.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)
         End If
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'CreateSection
    