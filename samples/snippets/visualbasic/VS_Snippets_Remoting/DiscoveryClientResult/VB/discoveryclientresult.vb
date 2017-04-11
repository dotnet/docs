' System.Web.Services.DiscoveryClientResult

' The following example demonstrates 'DiscoveryClientResult' class.
' A 'DiscoveryClientResultCollection' object is obtained by reading a
' '.discomap' file which contains the 'DiscoveryClientResult' objects,
' representing the details of discovery references. The contents of this
' collection are displayed..

' <Snippet1>
Imports System
Imports System.Web.Services.Discovery

Public Class MyDiscoveryClientResult

    Shared Sub Main()
        Try
            Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()

            ' Get the collection holding DiscoveryClientResult objects.
            Dim myDiscoveryClientResultCollection As _
                DiscoveryClientResultCollection = _
                myDiscoveryClientProtocol.ReadAll("results.discomap")
            Console.WriteLine("The number of DiscoveryClientResult objects: " _
                & myDiscoveryClientResultCollection.Count.ToString())
            Console.WriteLine("Displaying the items in the collection:")

            ' Iterate through the collection and display the properties
            ' of each DiscoveryClientResult in it.
            Dim myDiscoveryClientResult As DiscoveryClientResult
            For Each myDiscoveryClientResult In myDiscoveryClientResultCollection
                Console.WriteLine( _
                    "Type of reference in the discovery document: " _
                    & myDiscoveryClientResult.ReferenceTypeName)
                Console.WriteLine("Url for the reference: " _
                    & myDiscoveryClientResult.Url)
                Console.WriteLine("File for saving the reference: " _
                    & myDiscoveryClientResult.Filename)
            Next myDiscoveryClientResult
        Catch e As Exception
            Console.WriteLine("Error is " + e.Message)
        End Try
    End Sub 'Main
End Class 'MyDiscoveryClientResult
' </Snippet1>
