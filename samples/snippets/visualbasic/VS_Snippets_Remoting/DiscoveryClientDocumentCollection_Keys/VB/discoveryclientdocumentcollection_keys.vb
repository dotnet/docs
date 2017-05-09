' System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Keys
' System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Values
' System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Contains(String)

' The following example demonstrates the 'Keys', 'Values' properties
' and the 'Contains' method. The 'Keys' property returns the names
' the discoverydocuments in the 'DiscoveryClientDocumentCollection' and 
' the 'Values' property returns the type of objects in the 
' 'DiscoveryClientDocumentCollection'. A sample discovery document is read
' and the properties 'Keys' and 'Values' and the method 'Contains' are 
' displayed.

Imports System
Imports System.Net
Imports System.IO
Imports System.Collections
Imports System.Security.Permissions
Imports System.Web.Services.Discovery

Class DiscoveryClientDocumentCollectionSample_Keys
   
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
      Dim myDiscoveryClientDocumentCollection As DiscoveryClientDocumentCollection = _
                                                   myDiscoveryClientProtocol.Documents
      
      ' 'Keys' in the collection are retrieved.
' <Snippet1>
      Dim myCollection As ICollection = myDiscoveryClientDocumentCollection.Keys
      Dim myObjectCollection(myDiscoveryClientDocumentCollection.Count-1) As Object
      myCollection.CopyTo(myObjectCollection, 0)
      Console.WriteLine("The discovery documents in the collection are :")
      Dim iIndex As Integer
      For iIndex = 0 To myObjectCollection.Length - 1
         Console.WriteLine(myObjectCollection(iIndex))
      Next iIndex
' </Snippet1>
      Console.WriteLine("")
' <Snippet2>
      ' 'Values' in the collection are retrieved.
      Dim myCollection1 As ICollection = myDiscoveryClientDocumentCollection.Values
      Dim myObjectCollection1(myDiscoveryClientDocumentCollection.Count-1) As Object
      myCollection1.CopyTo(myObjectCollection1, 0)
      Console.WriteLine("The objects in the collection are :")
      For iIndex = 0 To myObjectCollection1.Length - 1
         Console.WriteLine(myObjectCollection1(iIndex))
      Next iIndex 
' </Snippet2>
      Console.WriteLine("")
' <Snippet3>
      Dim myContains As Boolean = myDiscoveryClientDocumentCollection.Contains(myStringUrl)
      If myContains Then
         Console.WriteLine("The discovery document {0} is present in the Collection", _
                                                                              myStringUrl)
      End If
' </Snippet3>
   End Sub 'Run
End Class 'DiscoveryClientDocumentCollectionSample_Keys

