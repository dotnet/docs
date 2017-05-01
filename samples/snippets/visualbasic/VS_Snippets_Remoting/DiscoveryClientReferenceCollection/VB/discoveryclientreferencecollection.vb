' System.Web.Services.Discovery.DiscoveryClientReferenceCollection

' The following example demonstrates the class 
' 'DiscoveryClientReferenceCollection'. A sample discovery document 
' is read and the 'Keys' and 'Values' properties are displayed. A 
' string containing the URL of a discovery document is passed as 
' an argument to 'Contains' method of the instance of the class. 

Option Strict On
' <Snippet1>
Imports System
Imports System.Net
Imports System.Collections
Imports System.Security.Permissions
Imports System.Web.Services.Discovery

Class MyDiscoveryClientReferenceCollection
   
   Shared Sub Main()
      Run()
   End Sub 'Main

   <PermissionSetAttribute(SecurityAction.Demand, Name := "FullTrust")> _
   Shared Sub Run()
      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      
      myDiscoveryClientProtocol.Credentials = CredentialCache.DefaultCredentials
      
      ' 'dataservice.vsdisco' is a sample discovery document.
      Dim myStringUrl As String = "http://localhost/dataservice.vsdisco"
      
      ' Call the Discover method to populate the References property.
      Dim myDiscoveryDocument As DiscoveryDocument = _
          myDiscoveryClientProtocol.Discover(myStringUrl)
      
      ' Resolve all references found in the discovery document.
      myDiscoveryClientProtocol.ResolveAll()
      
      Dim myDiscoveryClientReferenceCollection As DiscoveryClientReferenceCollection = _ 
          myDiscoveryClientProtocol.References

      ' Retrieve the keys from the collection.
      Dim myCollection As ICollection = myDiscoveryClientReferenceCollection.Keys
      Dim myObjectCollection(myDiscoveryClientReferenceCollection.Count) As Object
      myCollection.CopyTo(myObjectCollection, 0)

      Console.WriteLine("The discovery documents, service descriptions, and XML schema")
      Console.WriteLine(" definitions in the collection are:")
      Dim i As Integer
      For i = 0 To myObjectCollection.Length - 1
          Console.WriteLine(myObjectCollection(i))
      Next i

      ' Retrieve the values from the collection.
      Dim myCollection1 As ICollection = myDiscoveryClientReferenceCollection.Values
      Dim myObjectCollection1(myDiscoveryClientReferenceCollection.Count - 1) As Object
      myCollection1.CopyTo(myObjectCollection1, 0)
      
      Console.WriteLine("The objects in the collection are:")
      For i = 0 To myObjectCollection1.Length - 1
          Console.WriteLine(myObjectCollection1(i))
      Next i
      
      
      Dim myStringUrl1 As String = "http://localhost/dataservice.vsdisco"
      If myDiscoveryClientReferenceCollection.Contains(myStringUrl1) Then
          Console.WriteLine("The document reference {0} is part of the collection.", _
              myStringUrl1)
      End If
   End Sub 'Run

End Class 'MyDiscoveryClientReferenceCollection
' </Snippet1>
