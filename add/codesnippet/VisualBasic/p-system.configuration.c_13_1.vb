   Shared Sub DisplayCustomSectionInformation()
      
      Try
         Dim customSection As CustomSection
         
         customSection = ConfigurationManager.GetSection("CustomSection")
        
         If customSection Is Nothing Then
            Console.WriteLine(("Failed to load " + "CustomSection" + "."))
         Else
            ' Display specific information
            Console.WriteLine("Defaults:")
            Console.WriteLine("File Name:       {0}", customSection.FileName)
                Console.WriteLine("Max Users:       {0}", customSection.MaxUsers.ToString())
                Console.WriteLine("Max Idle Time:   {0}", customSection.MaxIdleTime.ToString())
            
            ' Display generic information
            Console.WriteLine("Generic information:")
            Console.WriteLine("AllowExeDefinition:  {0}", customSection.SectionInformation.AllowExeDefinition.ToString())
            Console.WriteLine("IsLocked:            {0}", customSection.SectionInformation.IsLocked.ToString())
         End If
      
      Catch err As ConfigurationErrorsException
         Console.WriteLine(err.ToString())
      End Try
   End Sub 'DisplayCustomSectionInformation
   