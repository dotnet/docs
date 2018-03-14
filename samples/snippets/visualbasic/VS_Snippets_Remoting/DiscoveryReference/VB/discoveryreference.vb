' System.Web.Services.Discovery.DiscoveryReference.ClientProtocol
' System.Web.Services.Discovery.DiscoveryReference.DefaultFilename
' System.Web.Services.Discovery.DiscoveryReference.WriteDocument(object,Stream)
' System.Web.Services.Discovery.DiscoveryReference.ReadDocument(Stream)
' System.Web.Services.Discovery.DiscoveryReference.Url
' System.Web.Services.Discovery.DiscoveryReference.Resolve()

' This program demonstrate 'ClientProtocol', 'WriteDocumant', 'Url' properties
' and 'DefaultFilename', 'readDocument', 'Resolve' methods of 'DiscoveryReference'
' class. DiscoveryReference class is derived in 'MyDiscoveryReferenceClass'. A
' variable of type 'MyDiscoveryReferenceClass' class is taken to demonstrate these
' members.
'  Note : The dataservice.disco file should be copied to Inetpub\wwwroot

' <Snippet1>
Imports System
Imports System.IO
Imports System.Web.Services.Discovery
Imports System.Net

Class MyDiscoveryDocumentClass
  Public Shared Sub Main()

      Dim myDiscoveryDocument As DiscoveryDocument
      Dim myStreamReader As _
         New StreamReader("c:\Inetpub\wwwroot\dataservice.disco")
      Dim myStream As _
         New FileStream("C:\MyDiscovery.disco", FileMode.OpenOrCreate)
      Console.WriteLine("Demonstrating Discovery Reference class.")

      ' Read discovery file.
      myDiscoveryDocument = DiscoveryDocument.Read(myStreamReader)

      ' Variable of type DiscoveryReference class defined.
      Dim myDiscoveryReference As MyDiscoveryReferenceClass
      myDiscoveryReference = New MyDiscoveryReferenceClass()

      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      myDiscoveryClientProtocol.Credentials = _
         CredentialCache.DefaultCredentials

      ' Set the client protocol.
      myDiscoveryReference.ClientProtocol = myDiscoveryClientProtocol

      ' Read the default file name.
      Console.WriteLine("Default file name is : " & _
         myDiscoveryReference.DefaultFilename)

      ' Write the document.
      myDiscoveryReference.WriteDocument(myDiscoveryDocument, myStream)

      ' Read the document.
      myDiscoveryReference.ReadDocument(myStream)

      ' Set the URL.
      myDiscoveryReference.Url = "http://localhost/dataservice.disco"
      Console.WriteLine("Url is : " & myDiscoveryReference.Url)

      ' Resolve the URL
      myDiscoveryReference.Resolve()

      myStreamReader.Close()
      myStream.Close()
   End Sub

End Class


' Class derived from DiscoveryReference class and overriding its members.
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
