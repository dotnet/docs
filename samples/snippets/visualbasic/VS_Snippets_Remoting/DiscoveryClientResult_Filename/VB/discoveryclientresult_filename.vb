' System.Web.Services.Discovery.DiscoveryClientResultCollection.Remove
' System.Web.Services.Discovery.DiscoveryClientResult()
' System.Web.Services.Discovery.DiscoveryClientResult.ReferenceTypeName
' System.Web.Services.Discovery.DiscoveryClientResult.Url
' System.Web.Services.Discovery.DiscoveryClientResult.Filename
' System.Web.Services.Discovery.DiscoveryClientResultCollection.Add
' System.Web.Services.Discovery.DiscoveryClientResultCollection.Contains
' System.Web.Services.Discovery.DiscoveryClientResultCollection.Item

' The following example demonstrates 'ReferenceTypeName' ,'Url','Filename' properties and
' the constructor of 'DiscoveryClientResult' class  and 'Remove', 'Add' 'Contains' methods and
' 'Item' property of 'DiscoveryClientResultCollection' class.
' A 'DiscoveryClientResultCollection' object is obtained by reading a '.discomap' file which contains the
' 'DiscoveryClientResult' objects, representing the details of discovery references. An element from the 
' collection is removed and programmatically added to it to show the usage of methods of 
' 'DiscoveryClientResultCollection' class . The contents of this collection are displayed..

Imports System
Imports System.Web.Services.Discovery

Public Class MyDiscoveryClientResult
   
   Shared Sub Main()
      Try
         Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()

         ' Get the collection of 'DiscoveryClientResult' objects.
         Dim myDiscoveryClientResultCollection As _
             DiscoveryClientResultCollection = _
             myDiscoveryClientProtocol.ReadAll("results.discomap")

         Console.WriteLine("The number of DiscoveryClientResult objects: " & _
             myDiscoveryClientResultCollection.Count.ToString())

         Console.WriteLine( _
             "Removing a 'DiscoveryClientResult' object from the collection...")
' <Snippet1>
         ' Remove the first DiscoveryClientResult from the collection.
         myDiscoveryClientResultCollection.Remove( _
            myDiscoveryClientResultCollection(0))
' </Snippet1>
         Console.WriteLine( _
             "Adding a DiscoveryClientResult to the collection...")
' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>
         ' Initialize a new instance of the DiscoveryClientResult class.
         Dim myDiscoveryClientResult As New DiscoveryClientResult()

         ' Set the type of reference in the discovery document as 
         ' DiscoveryDocumentReference.
         myDiscoveryClientResult.ReferenceTypeName = _
             "System.Web.Services.Discovery.DiscoveryDocumentReference"

         ' Set the URL for the reference.
         myDiscoveryClientResult.Url = _
             "http://localhost/Discovery/Service1_vb.asmx?disco"

         ' Set the name of the file in which the reference is saved.
         myDiscoveryClientResult.Filename = "Service1_vb.disco"

         ' Add the DiscoveryClientResult to the collection.
         myDiscoveryClientResultCollection.Add(myDiscoveryClientResult)
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>

' <Snippet7>
         If myDiscoveryClientResultCollection.Contains( _ 
             myDiscoveryClientResult) Then

             Console.WriteLine( _
                 "The collection contains the specified " & _
                 "DiscoveryClientResult' instance.")

         End If
' </Snippet7>
         Console.WriteLine("Displaying the items in the collection")
         
' <Snippet8>
         Dim i As Integer
         For i = 0 To myDiscoveryClientResultCollection.Count - 1
            Dim myClientResult As DiscoveryClientResult = _
                myDiscoveryClientResultCollection(i)
            Console.WriteLine("DiscoveryClientResult " & (i + 1).ToString())
            Console.WriteLine("Type of reference in the discovery document: " _
                & myClientResult.ReferenceTypeName)
            Console.WriteLine("Url for reference:" & myClientResult.Url)
            Console.WriteLine("File for saving the reference: " _
                & myClientResult.Filename)
         Next i
' </Snippet8>
      Catch e As Exception
         Console.WriteLine("Error is " + e.Message)
      End Try
   End Sub 'Main
End Class 'MyDiscoveryClientResult
