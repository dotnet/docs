' System.Web.Services.Discovery.DiscoveryDocumentReference.DiscoveryDocumentReference(string)
' System.Web.Services.Discovery.DiscoveryDocumentReference.Ref
' System.Web.Services.Discovery.DiscoveryDocumentReference.Url
' System.Web.Services.Discovery.DiscoveryDocumentReference.DefaultFilename

'This program demonstrates the 'DiscoveryDocumentReference(string)' Constructor, 'Ref',
''Url', and 'DefaultFileName' properties of the 'DiscoveryDocumentReference' class.
'It creates an instance of 'DiscoveryDocumentReference' and displays the 'Ref', 'Url' and
''DefaultFilename' properties.

Imports System
Imports System.Xml
Imports System.Web.Services.Discovery


Public Class DiscoveryDocumentReference_ctor_Properties

    Public Shared Sub Main()
        Try
' <Snippet1>
            Dim myDiscoveryDocumentReference As New _
                DiscoveryDocumentReference("http://localhost/Sample_vb.disco")
' </Snippet1>

            Console.WriteLine("The reference to the discovery document is:")

' <Snippet2>
            ' Display the discovery document reference.
            Console.WriteLine(myDiscoveryDocumentReference.Ref.ToString())
' </Snippet2>
            Console.WriteLine()
            Console.WriteLine( _
                "The URL of the referenced discovery document is: ")

' <Snippet3>
            ' Display the URL of the referenced discovery document.
            Console.WriteLine(myDiscoveryDocumentReference.Url.ToString())
' </Snippet3>
            Console.WriteLine()
            Console.WriteLine("The name of the default disco file is: ")

' <Snippet4>
            ' Display the name of the default file used for reference.
            Console.WriteLine( _
                myDiscoveryDocumentReference.DefaultFilename.ToString())
' </Snippet4>
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'DiscoveryDocumentReference_ctor_Properties
