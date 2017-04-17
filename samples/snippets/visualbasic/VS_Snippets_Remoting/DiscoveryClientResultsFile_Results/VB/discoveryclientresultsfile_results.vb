' System.Web.Services.Discovery.DiscoveryClientProtocol.DiscoveryClientResultsFile
' System.Web.Services.Discovery.DiscoveryClientProtocol.DiscoveryClientResultsFile.ctor
' System.Web.Services.Discovery.DiscoveryClientProtocol.DiscoveryClientResultsFile.Results
'
' The following example demonstrates the usage of 'DiscoveryClientProtocol.
' DiscoveryClientResultsFile' class, constructor 'DiscoveryClientProtocol.
' DiscoveryClientResultsFile()' and the property 'Results' of the class.
' The input to the program is a VSDisco file 'MathService.vsdisco', which
' holds reference to 'MathService' web service. The 'Results' property returns
' all valid references of the discovery document 'MathService.vsdisco'.

' <Snippet1>
Imports System
Imports System.Web.Services.Discovery
Imports System.Net
Imports System.Xml
Imports System.Xml.Serialization

Class myDiscoveryClient_Results
   
   Shared Sub Main()
      Dim outputDirectory As String = "c:\InetPub\wwwroot"
      Dim myClient As New DiscoveryClientProtocol()
      
      ' Use default credentials to access the URL being discovered.
      myClient.Credentials = CredentialCache.DefaultCredentials
      Try
          Dim myDocument As DiscoveryDocument
          ' Discover the supplied URL to determine if it is a discovery document.
          myDocument = myClient.Discover("http://localhost/MathService_vb.vsdisco")
          myClient.ResolveAll()
          Dim myCollection As DiscoveryClientResultCollection = _ 
              myClient.WriteAll(outputDirectory, "MyDiscoMap.discomap")
' <Snippet2>
' <Snippet3>
         ' Get the DiscoveryClientProtocol.DiscoveryClientResultsFile.
         Dim myResultFile As New DiscoveryClientProtocol.DiscoveryClientResultsFile()
         Dim mySerializer As New XmlSerializer(myResultFile.GetType())
         Dim reader = New XmlTextReader("http://localhost/MyDiscoMap.discomap")
         myResultFile = CType(mySerializer.Deserialize(reader), _ 
             DiscoveryClientProtocol.DiscoveryClientResultsFile)

         ' Get a collection of 'DiscoveryClientResult' objects.
         Dim myResultcollection As DiscoveryClientResultCollection = _
             myResultFile.Results

         Console.WriteLine("Referred file(s) : ")
         Dim myResult As DiscoveryClientResult
         For Each myResult In  myResultcollection
            Console.WriteLine(myResult.Filename)
         Next myResult
' </Snippet3>
' </Snippet2>
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'Main
End Class 'myDiscoveryClient_Results
' </Snippet1>