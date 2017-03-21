   <PermissionSet( _
    SecurityAction.Demand, Name:="FullTrust")> _
    Private Shared Sub GetProviders()
      ' Get the providers' collection.
        Dim providers _
        As ProtectedConfigurationProviderCollection = _
        ProtectedConfiguration.Providers
      
        Dim pEnum As IEnumerator = _
        providers.GetEnumerator()
      
        Dim provider _
        As ProtectedConfigurationProvider

        For Each provider In providers
            Console.WriteLine( _
            "Provider name: {0}", provider.Name)
            Console.WriteLine( _
            "Provider description: {0}", provider.Description)
        Next provider
   End Sub 'GetProviders