' System.Web.Services.Discovery.DiscoveryClientDocumentCollection.DiscoveryClientDocumentCollection
' System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Add
' System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Remove
' System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Item

' The following example demonstrates the constructor, the 'Add' and 
' 'Remove' methods and the 'Item' property. The method 'Add', adds a
' discovery document object to the DiscoveryClientDocumentCollection.
' The method 'Remove', removes a discovery document object from the
' DiscoveryClientDocumentCollection. The Item property is used to 
' retrieve an object in the DiscoveryClientDocumentCollection. A sample
' discovery document is read and the methods 'Add', 'Remove' and the 
' property 'Item' are applied on the sample.

Imports System
Imports System.Net
Imports System.IO
Imports System.Collections
Imports System.Web.Services.Discovery

Public Class DiscoveryClientDocumentCollection_Add
   
   Public Shared Sub Main()
' <Snippet3>
' <Snippet2>
' <Snippet1>
      Dim myDiscoveryClientDocumentCollection As New DiscoveryClientDocumentCollection()
' </Snippet1>
      Dim myDiscoveryDocument As New DiscoveryDocument()
      Dim myStringUrl As String = "http://www.contoso.com/service.disco"
      Dim myStringUrl1 As String = "http://www.contoso.com/service1.disco"
      
      myDiscoveryClientDocumentCollection.Add(myStringUrl, myDiscoveryDocument)
      myDiscoveryClientDocumentCollection.Add(myStringUrl1, myDiscoveryDocument)
' </Snippet2>
      myDiscoveryClientDocumentCollection.Remove(myStringUrl1)
' </Snippet3>

' <Snippet4>
      Dim myObject As Object = myDiscoveryClientDocumentCollection(myStringUrl)
      Console.WriteLine(("Object representing the Url : " + myObject.ToString()))
' </Snippet4>
      Console.WriteLine("")
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
   End Sub 'Main
End Class 'DiscoveryClientDocumentCollection_Add 
