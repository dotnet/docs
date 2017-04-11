 ' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Security.Permissions

' Show how to use the ProtectedConfiguration.
NotInheritable Public Class UsingProtectedConfiguration
   
  

   ' <Snippet3>
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
    ' </Snippet3>

   <PermissionSet( _
    SecurityAction.Demand, Name:="FullTrust")> _
    Private Shared Sub GetProviderName()
      ' <Snippet4>
      ' Get the current provider name.
        Dim dataProtectionProviderName As String = _
        ProtectedConfiguration.DataProtectionProviderName
        Console.WriteLine( _
        "Data protection provider name: {0}", _
        dataProtectionProviderName)
        ' </Snippet4>

      ' <Snippet5>
      ' Get the Rsa provider name.
        Dim rsaProviderName As String = _
        ProtectedConfiguration.RsaProviderName
        Console.WriteLine( _
        "Rsa provider name: {0}", rsaProviderName)
        ' </Snippet5>

        ' <Snippet6>
        ' Get the Rsa provider name.
        Dim protectedSectionName As String = _
        ProtectedConfiguration.ProtectedDataSectionName
        Console.WriteLine( _
        "Protected section name: {0}", protectedSectionName)
        ' </Snippet6>

    End Sub 'GetProviderName
   
   
    Public Shared Sub Main(ByVal args() As String)

       
        ' Get current and Rsa provider names.
        GetProviderName()

        ' Get the providers' collection.
        GetProviders()
        
    End Sub 'Main 

End Class 'UsingProtectedConfiguration 
' </Snippet1>