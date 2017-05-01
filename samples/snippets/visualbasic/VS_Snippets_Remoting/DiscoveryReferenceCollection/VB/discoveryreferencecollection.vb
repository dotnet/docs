' System.Web.Services.Discovery.DiscoveryReferenceCollection.DiscoveryReferenceCollection
' System.Web.Services.Discovery.DiscoveryReferenceCollection.Add(DiscoveryReference)
' System.Web.Services.Discovery.DiscoveryReferenceCollection.Contains(DiscoveryReference)
' System.Web.Services.Discovery.DiscoveryReferenceCollection.Item(int)
' System.Web.Services.Discovery.DiscoveryReferenceCollection.Remove(DiscoveryReference)
' System.Web.Services.Discovery.DiscoveryReferenceCollection

' The following example demonstrates the usage of 'DiscoveryReferenceCollection' class, 'Add', 'Contains',
' 'Item'and  'Remove' methods and its constructor. A variable of 'DiscoveryReferenceCollection'
' class is taken. One 'DiscoveryReference' type member is added to the collection. Using this
' various methods of 'DiscoveryReferenceCollection' class are demonstrated.

' <Snippet1>
Imports System
Imports System.IO
Imports System.Web.Services.Discovery

' <Snippet2>
Class MyDiscoveryDocumentMod

   Shared Sub Main()
   Try
      Dim myDiscoveryDocReference1 As New DiscoveryDocumentReference()
      Dim myDiscoveryDocReference2 As New DiscoveryDocumentReference()
      Dim myDiscoveryReference As DiscoveryReference

      Console.WriteLine("Demonstrating DiscoveryReferenceCollection class.")

      ' Create new DiscoveryReferenceCollection.
      Dim myDiscoveryReferenceCollection As New DiscoveryReferenceCollection()

      ' Access the Count method.
      Console.WriteLine("The number of elements in collection is: " & _
         myDiscoveryReferenceCollection.Count.ToString())

      ' Add elements to the collection.
      myDiscoveryReferenceCollection.Add(myDiscoveryDocReference1)
      myDiscoveryReferenceCollection.Add(myDiscoveryDocReference2)

      Console.WriteLine("The number of elements in the collection " _
         & "after adding two elements to the collection: " _
         & myDiscoveryReferenceCollection.Count.ToString())

      ' Call the Contains method.
      If myDiscoveryReferenceCollection.Contains(myDiscoveryDocReference1) _
         <> True Then
         Throw New Exception("Element not found in collection.")
      End If

      ' Access the Item property.
      myDiscoveryReference = myDiscoveryReferenceCollection.Item(0)

      If  myDiscoveryReference Is Nothing Then
         Throw New Exception("Element not found in collection.")
      End If

      ' Remove one element from the collection.
      myDiscoveryReferenceCollection.Remove(myDiscoveryDocReference1)
      Console.WriteLine("The number of elements in collection " _
         & "after removing one element is: " _
         & myDiscoveryReferenceCollection.Count.ToString())

   Catch e As Exception
       Console.Writeline("Exception occured : " + e.Message)
   End Try
   End Sub

End Class
' </Snippet2>
' </Snippet1>
