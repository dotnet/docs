' System.Web.Services.Discovery.DiscoveryClientReferenceCollection.DiscoveryClientReferenceCollection
' System.Web.Services.Discovery.DiscoveryClientReferenceCollection.Add(DiscoveryReference)
' System.Web.Services.Discovery.DiscoveryClientReferenceCollection.Add(DiscoveryReference, url)
' System.Web.Services.Discovery.DiscoveryClientReferenceCollection.Remove
' System.Web.Services.Discovery.DiscoveryClientReferenceCollection.Item

' The following example demonstrates the 'constructor' and various members of
' the class 'DiscoveryClientReferenceCollection'. The 'Add(DiscoveryReference)'
' method adds a DocumentReference object to the DiscoveryClientDocumentCollection
' collection. The Add(url, DiscoveryReference) method adds a DiscoveryReference
' with the specified Url. The 'Remove' method removes a DiscoveryReference with 
' the specified Url from the 'DiscoveryClientReferenceCollection' collection. 
' The 'Item' property gets or sets a DiscoveryReference object from the
' 'DiscoveryClientReferenceCollection' with the specified Url.

Imports System
Imports System.Collections
Imports System.Web.Services.Discovery

Public Class DiscoveryClientReferenceCollection_Keys
   
   Public Shared Sub Main()
' <Snippet5>
' <Snippet2>
' <Snippet1>

      Dim myDiscoveryClientReferenceCollection As _
          New DiscoveryClientReferenceCollection()

      Dim myContractReference As New ContractReference()
      Dim myStringUrl1 As String = "http://www.contoso.com/service1.disco"
      myContractReference.Ref = myStringUrl1
      myDiscoveryClientReferenceCollection.Add(myContractReference)
' </Snippet1>
' </Snippet2>
      ' myDiscoveryClientReferenceCollection is an instance collection.
      Dim myObject As Object = _
          myDiscoveryClientReferenceCollection.Item(myStringUrl1)
      Console.WriteLine("Object representing the URL: " + myObject.ToString())
' </Snippet5>
      Console.WriteLine("")
' <Snippet4>
' <Snippet3>
      Dim myDiscoveryDocumentReference As New DiscoveryDocumentReference()
      Dim myStringUrl As String = "http://www.contoso.com/service.disco"
      myDiscoveryClientReferenceCollection.Add(myStringUrl, _
          myDiscoveryDocumentReference)
' </Snippet3>
      myDiscoveryClientReferenceCollection.Remove(myStringUrl)
' </Snippet4>
      ' Retrieve the keys in the colletion.
      Dim myCollection As ICollection = _
          myDiscoveryClientReferenceCollection.Keys
      Dim myObjectCollection(myDiscoveryClientReferenceCollection.Count - 1) _
          As Object
      myCollection.CopyTo(myObjectCollection, 0)

      Console.WriteLine("The discovery documents, service descriptions, and")
      Console.WriteLine("XML schema definitions in the collection are:")
      Dim iIndex As Integer
      For iIndex = 0 To myObjectCollection.Length - 1
          Console.WriteLine(myObjectCollection(iIndex))
      Next iIndex

      Console.WriteLine("")

      ' Retrieve the values in the collection.
      Dim myCollection1 As ICollection = _
          myDiscoveryClientReferenceCollection.Values
      Dim myObjectCollection1(myDiscoveryClientReferenceCollection.Count) _
          As Object
      myCollection1.CopyTo(myObjectCollection1, 0)

      Console.WriteLine("The objects in the collection are:")

      For iIndex = 0 To myObjectCollection1.Length - 1
         Console.WriteLine(myObjectCollection1(iIndex))
      Next iIndex
   End Sub 'Main
End Class 'DiscoveryClientReferenceCollection_Keys