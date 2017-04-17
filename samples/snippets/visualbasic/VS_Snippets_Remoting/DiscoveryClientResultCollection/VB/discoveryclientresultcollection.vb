' System.Web.Services.Discovery.DiscoveryClientResultCollection

' The following example demonstrates 'DiscoveryClientResultCollection' class.
' A 'DiscoveryClientResultCollection' object is obtained by reading a '.discomap' file
' which contains the 'DiscoveryClientResult' objects, representing the details of 
' discovery references. An element from the collection is removed and programmatically 
' added to 'DiscoveryClientResultCollection' class .

' <Snippet1>
Imports System
Imports System.Reflection
Imports System.IO
Imports System.Web.Services.Discovery
Imports System.Xml.Schema
Imports System.Collections

Public Class MyDiscoveryClientResult
   
   Shared Sub Main()
      Try
         Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()

         ' Get the collection of DiscoveryClientResult objects.
         Dim myDiscoveryClientResultCollection As _
             DiscoveryClientResultCollection = _
             myDiscoveryClientProtocol.ReadAll("results.discomap")
         Console.WriteLine( _
             "Removing a DiscoveryClientResult from the collection...")

         ' Remove the first DiscoveryClientResult from the collection.
         myDiscoveryClientResultCollection.Remove( _
             myDiscoveryClientResultCollection(0))
         Console.WriteLine("Adding a DiscoveryClientResult" & _
             " to the collection...")
         Dim myDiscoveryClientResult As New DiscoveryClientResult()

         ' Set the DiscoveryDocumentReference class as the type of 
         ' reference in the discovery document.
         myDiscoveryClientResult.ReferenceTypeName = _
             "System.Web.Services.Discovery.DiscoveryDocumentReference"

         ' Set the URL for the reference.
         myDiscoveryClientResult.Url = _
             "http://localhost/Discovery/Service1_vb.asmx?disco"

         ' Set the name of the file in which the reference is saved.
         myDiscoveryClientResult.Filename = "Service1_vb.disco"

         ' Add myDiscoveryClientResult to the collection.
         myDiscoveryClientResultCollection.Add(myDiscoveryClientResult)

         If myDiscoveryClientResultCollection.Contains( _ 
             myDiscoveryClientResult) Then

             Console.WriteLine( _
                 "Instance of DiscoveryClientResult found in the Collection")
         End If

      Catch ex As Exception
         Console.WriteLine("Error is " + ex.Message)
      End Try
   End Sub 'Main
End Class 'MyDiscoveryClientResult
' </Snippet1>
