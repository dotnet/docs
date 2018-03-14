' System.Web.Services.Discovery.DiscoveryClientReferenceCollection.Keys
' System.Web.Services.Discovery.DiscoveryClientReferenceCollection.Values
' System.Web.Services.Discovery.DiscoveryClientReferenceCollection.Contains

' The following example demonstrates the 'Keys', 'Values' properties and 
' the method 'Contains' of the class 'DiscoveryClientReferenceCollection'. A sample 
' discovery document is read and the 'Keys', 'Values' and 'Contains' properties 
' are displayed.

Imports System
Imports System.Net
Imports System.Collections
Imports System.Security.Permissions
Imports System.Web.Services.Discovery


Class DiscoveryClientReferenceCollection_Keys
   Shared Sub Main()
      Run()
   End Sub 'Main

   <PermissionSetAttribute(SecurityAction.Demand, Name := "FullTrust")> _
   Shared Sub Run()

' <Snippet1>
      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      myDiscoveryClientProtocol.Credentials = _
          CredentialCache.DefaultCredentials

      ' 'dataservice.disco' is a sample discovery document.
      Dim myStringUrl As String = "http://localhost/dataservice.disco"

      ' Call the Discover method to populate the References property.
      Dim myDiscoveryDocument As DiscoveryDocument = _
          myDiscoveryClientProtocol.Discover(myStringUrl)

      ' Resolve all references found in the discovery document.
      myDiscoveryClientProtocol.ResolveAll()
      Dim myDiscoveryClientReferenceCollection As DiscoveryClientReferenceCollection = _
          myDiscoveryClientProtocol.References

      ' Retrieve the keys in the collection.
      Dim myCollection As ICollection = myDiscoveryClientReferenceCollection.Keys
      Dim myObjectCollection(myDiscoveryClientReferenceCollection.Count) As Object
      myCollection.CopyTo(myObjectCollection, 0)

      Console.WriteLine("The discovery documents, service descriptions, and XML schema")
      Console.WriteLine(" definitions in the collection are:")
      Dim iIndex As Integer
      For iIndex = 0 To myObjectCollection.Length - 1
          Console.WriteLine(myObjectCollection(iIndex))
      Next iIndex
' </Snippet1>
      Console.WriteLine("")
' <Snippet2>
      ' Retrieve the values in the collection.
      Dim myCollection1 As ICollection = myDiscoveryClientReferenceCollection.Values
      Dim myObjectCollection1(myDiscoveryClientReferenceCollection.Count) As Object
      myCollection1.CopyTo(myObjectCollection1, 0)

      Console.WriteLine("The objects in the collection are:")
      For iIndex = 0 To myObjectCollection1.Length - 1
          Console.WriteLine(myObjectCollection1(iIndex))
      Next iIndex
' </Snippet2>
      Console.WriteLine("")
' <Snippet3>
      Dim myStringUrl1 As String = "http://localhost/dataservice.disco"
      If myDiscoveryClientReferenceCollection.Contains(myStringUrl1) Then
          Console.WriteLine("The document reference {0} is part of the" + _
          " collection.", myStringUrl1)
      End If
' </Snippet3>
   End Sub 'Run
End Class 'DiscoveryClientReferenceCollection_Keys 