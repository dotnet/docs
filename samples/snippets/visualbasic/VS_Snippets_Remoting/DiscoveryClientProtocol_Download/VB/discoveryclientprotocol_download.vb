' System.Web.Services.Discovery.DiscoveryClientProtocol.DiscoveryClientProtocol
' System.Web.Services.Discovery.DiscoveryClientProtocol.Download(ref String)

' The following example demonstrates the 'constructor' and the
' method 'Download' of the 'DiscoveryClientProtocol' class. The
' Download' method downloads a discovery document into a stream.
' sample discovery document is read and the method 'download'
' is applied on it.

Imports System
Imports System.Net
Imports System.IO
Imports System.Security.Permissions
Imports System.Web.Services.Discovery

Class DiscoveryClientProtocol_Download
   Shared Sub Main()
      Run()
   End Sub 'Main

   <PermissionSetAttribute(SecurityAction.Demand, Name := "FullTrust")> _
   Shared Sub Run()
' <Snippet1>
' <Snippet2>
      ' Call the constructor of the DiscoveryClientProtocol class.
      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      myDiscoveryClientProtocol.Credentials = CredentialCache.DefaultCredentials
      ' 'dataservice.disco' is a sample discovery document.
      Dim myStringUrl As String = "http://localhost:80/dataservice.disco"

      Dim myStream As Stream = myDiscoveryClientProtocol.Download(myStringUrl)
      Console.WriteLine("Size of the discovery document downloaded")
      Console.WriteLine("is : {0} bytes", myStream.Length.ToString())
      myStream.Close()
' </Snippet1>
' </Snippet2>
   End Sub 'Run
End Class 'DiscoveryClientProtocol_Download

