    Shared Sub GetDefaultProvider() 
        Try
            ' Get the application configuration.
            Dim config As Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)
            
            ' Get the protected configuration section.
            Dim pcSection _
            As ProtectedConfigurationSection = _
            CType(config.GetSection( _
            "configProtectedData"), _
            System.Configuration.ProtectedConfigurationSection)
            
            ' Get the current DefaultProvider.
            Console.WriteLine( _
            "Protected configuration section default provider:")
            Console.WriteLine("{0}", _
            pcSection.DefaultProvider)
        
        Catch e As ConfigurationErrorsException
            Console.WriteLine(e.ToString())
        End Try
    
    End Sub 'GetDefaultProvider
     