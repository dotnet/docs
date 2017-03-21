Imports System
Imports System.IO
Imports System.Configuration


' Shows how to use ProtectedConfigurationSection.

Class UsingProtectedConfigurationSection
    
    
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
     
    
    Shared Sub GetProviderCollection() 
        
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

            Console.WriteLine( _
            "Protected configuration section providers:")
            Dim ps As ProviderSettings
            For Each ps In  pcSection.Providers
                Console.WriteLine("  {0}", ps.Name)
            Next ps
        
        Catch e As ConfigurationErrorsException
            Console.WriteLine(e.ToString())
        End Try
    
    End Sub 'GetProviderCollection
     

    Public Shared Sub Main() 
        GetDefaultProvider()
        GetProviderCollection()
    
    End Sub 'Main
End Class 'UsingProtectedConfigurationSection