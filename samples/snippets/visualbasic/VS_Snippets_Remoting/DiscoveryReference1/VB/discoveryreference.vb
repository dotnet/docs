' System.Web.Services.Discovery.DiscoveryReference

'   This program demonstrates 'DiscoveryReference' class. 
'   DiscoveryReference class is derived in 'MyDiscoveryReferenceClass'. A
'   variable of type 'MyDiscoveryReferenceClass' class is taken to demonstrate 
'   members of 'MyDiscoveryReferenceClass'.
'   Note : The dataservice.disco file should be copied to c:\Inetpub\wwwroot

' <Snippet1>
Imports System
Imports System.IO
Imports System.Web.Services.Discovery
Imports System.Net

Class MyDiscoveryDocumentClass
   Public Shared Sub Main()
      Try
         Dim myDiscoveryDocument As DiscoveryDocument
         Dim myStreamReader As New StreamReader("c:\Inetpub\wwwroot\dataservice.disco")
         Dim myStream As New FileStream("c:\MyDiscovery.disco", FileMode.OpenOrCreate)
         Console.WriteLine("Demonstrating DiscoveryReference class.")

         ' Read the discovery file.
         myDiscoveryDocument = DiscoveryDocument.Read(myStreamReader)

         ' Create an instance of the DiscoveryReference class.
         Dim myDiscoveryReference As MyDiscoveryReferenceClass
         myDiscoveryReference = New MyDiscoveryReferenceClass()

         Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
         myDiscoveryClientProtocol.Credentials = _
             CredentialCache.DefaultCredentials

         ' Set the client protocol.
         myDiscoveryReference.ClientProtocol = myDiscoveryClientProtocol

         ' Read the default file name.
         Console.WriteLine("Default file name is: " _
             & myDiscoveryReference.DefaultFilename)

         ' Write the document.
         myDiscoveryReference.WriteDocument(myDiscoveryDocument, myStream)

         ' Read the document.
         myDiscoveryReference.ReadDocument(myStream)

         ' Set the URL.
         myDiscoveryReference.Url = "http://localhost/dataservice.disco"
         Console.WriteLine("Url is : " + myDiscoveryReference.Url)

         ' Resolve the URL.
         myDiscoveryReference.Resolve()

         myStreamReader.Close()
         myStream.Close()

      Catch e as Exception
         Console.WriteLine("Exception caught! - {0}", e.Message)
      End Try
   
   End Sub

End Class


' Class derived from DiscoveryReference class and overriding it members.
Class MyDiscoveryReferenceClass
   Inherits DiscoveryReference
   Private myDocumentUrl As String

   Public Overrides ReadOnly Property DefaultFilename() As String
      Get
         Return "dataservice.disco"
      End Get
   End Property

   Public Overrides Function _
      ReadDocument(ByVal stream As System.IO.Stream) As Object
      Return stream
   End Function

   Public Overloads Sub Resolve()
      Try
         Dim myDiscoveryRefDocument As DiscoveryDocument
         myDiscoveryRefDocument = MyBase.ClientProtocol.Discover(Url)
      Catch e As Exception
         Throw e
      End Try
   End Sub

   Protected Overloads Overrides Sub _
      Resolve(ByVal contentType As String, ByVal stream As Stream)
   End Sub

   Public Overrides Property Url() As String
      Get
         Return myDocumentUrl
      End Get

      Set(ByVal Value As String)
         myDocumentUrl = Value
      End Set
   End Property

   Public Overrides Sub WriteDocument _
      (ByVal document As Object, ByVal stream As System.IO.Stream)
      Dim myDiscoveryDocument As DiscoveryDocument = _
          CType(document, DiscoveryDocument)
      myDiscoveryDocument.Write(stream)
   End Sub
End Class
' </Snippet1>
