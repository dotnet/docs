' System.Web.Services.Discovery.DiscoveryClientDocumentCollection

' The following example demonstrates the class 'DiscoveryClientDocumentCollection'.
' A sample discovery document is read and the 'Keys' and 'Values' properties 
' are displayed.

' <Snippet1>
Imports System
Imports System.Net
Imports System.IO
Imports System.Collections
Imports System.Security.Permissions
Imports System.Web.Services.Discovery

Class DiscoveryClientDocumentCollectionSample
   
   Shared Sub Main()
      Run()
   End Sub 'Main

   <PermissionSetAttribute(SecurityAction.Demand, Name := "FullTrust")> _
   Shared Sub Run()

      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      
      myDiscoveryClientProtocol.Credentials = CredentialCache.DefaultCredentials
      
      ' 'dataservice.disco' is a sample discovery document.
      Dim myStringUrl As String = "http://localhost/dataservice.disco"
      
      ' 'Discover' method is called to populate the 'Documents' property.
      Dim myDiscoveryDocument As DiscoveryDocument = myDiscoveryClientProtocol.Discover(myStringUrl)
      
      ' An instance of the 'DiscoveryClientDocumentCollection' class is created.
      Dim myDiscoveryClientDocumentCollection As DiscoveryClientDocumentCollection = _
                                                myDiscoveryClientProtocol.Documents
      
      ' 'Keys' in the collection are retrieved.
      Dim myCollection As ICollection = myDiscoveryClientDocumentCollection.Keys
      Dim myObjectCollection(myDiscoveryClientDocumentCollection.Count-1) As Object
      myCollection.CopyTo(myObjectCollection, 0)
      
      Console.WriteLine("The discovery documents in the collection are :")
      Dim iIndex As Integer
      For iIndex = 0 To myObjectCollection.Length - 1
         Console.WriteLine(myObjectCollection(iIndex))
      Next iIndex
      
      Console.WriteLine("")
      
      ' 'Values' in the collection are retrieved.
      Dim myCollection1 As ICollection = myDiscoveryClientDocumentCollection.Values
      Dim myObjectCollection1(myDiscoveryClientDocumentCollection.Count-1) As Object
      myCollection1.CopyTo(myObjectCollection1, 0)
      
      Console.WriteLine("The objects in the collection are :")
      For iIndex = 0 To myObjectCollection1.Length - 1
         Console.WriteLine(myObjectCollection1(iIndex))
      Next iIndex
   End Sub 'Run
End Class 'DiscoveryClientDocumentCollectionSample
' </Snippet1>