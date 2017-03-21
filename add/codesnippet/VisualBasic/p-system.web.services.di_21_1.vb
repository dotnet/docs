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