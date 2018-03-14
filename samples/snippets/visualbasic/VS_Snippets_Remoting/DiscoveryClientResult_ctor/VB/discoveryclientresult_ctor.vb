' System.Web.Services.Discovery.DiscoveryClientResult(Type,String,String)

' The following example demonstrates the DiscoveryClientResult(Type,String,String)
' constructor of 'DiscoveryClientResult' class.
' A 'DiscoveryClientResultCollection' object is obtained by reading a '.discomap' file 
' which contains the 'DiscoveryClientResult' objects, representing the details of 
' discovery references. A 'DiscoveryClientProtocol' object from the collection is 
' removed. Then a 'DiscoveryClientProtocol' is created suppling the type of reference
' in the discovery document, URL for the reference and  name of the file in which the
' reference is saved.and programmatically added to it. The contents of this collection 
' are displayed.

Imports System
Imports System.Reflection
Imports System.Web.Services.Discovery

Public Class MyDiscoveryClientResult
   
   Shared Sub Main()
      Try
         Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
         ' Get the collection of DiscoveryClientResult objects.
         Dim myDiscoveryClientResultCollection As _
            DiscoveryClientResultCollection = _
            myDiscoveryClientProtocol.ReadAll("results.discomap")

         Console.WriteLine("The number of DiscoveryClientResult objects: " & _
            myDiscoveryClientResultCollection.Count.ToString())
         Console.WriteLine("Removing a DiscoveryClientResult " & _
            "from the collection...")
         ' Remove first DiscoveryClientResult from the collection.
         myDiscoveryClientResultCollection.Remove( _
            myDiscoveryClientResultCollection(0))
         Console.WriteLine("Adding a DiscoveryClientResult " & _
            "to the collection...")
' <Snippet1>
         ' Initialize a new instance of the DiscoveryClientResult class.
         Dim myDiscoveryClientResult As New DiscoveryClientResult( _
            GetType(System.Web.Services.Discovery.DiscoveryDocumentReference), _
            "http://localhost/Discovery/Service1_vb.asmx?disco", _
            "Service1_vb.disco")

         ' Add the DiscoveryClientResult to the collection.
         myDiscoveryClientResultCollection.Add(myDiscoveryClientResult)
' </Snippet1>
         Console.WriteLine("Displaying the items in collection")
         Dim i As Integer
         For i = 0 To myDiscoveryClientResultCollection.Count - 1
            Dim myClientResult As DiscoveryClientResult = _
               myDiscoveryClientResultCollection(i)
            Console.WriteLine("DiscoveryClientResult Object " _
               & (i + 1).ToString())
            Console.WriteLine("Type of reference in the discovery document: " _
               & myClientResult.ReferenceTypeName)
            Console.WriteLine("URL for reference: " & myClientResult.Url)
            Console.WriteLine("File for saving the reference: " _
               & myClientResult.Filename)
         Next i
      Catch e As Exception
         Console.WriteLine("Error is " + e.Message)
      End Try
   End Sub 'Main
End Class 'MyDiscoveryClientResult
