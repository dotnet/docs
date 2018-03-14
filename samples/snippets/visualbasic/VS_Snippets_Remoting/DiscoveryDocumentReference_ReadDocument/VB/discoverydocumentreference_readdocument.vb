' System.Web.Services.Discovery.DiscoveryDocumentReference.ReadDocument(stream)

' This program demonstrates the 'ReadDocument(stream)' of 'DiscoveryDocumentReference'
' class. Read the contents of the discovery document from the stream and returns 
' discovery document reference. The references of the 'DiscoveryDocumentReference'
' are printed.

Imports System
Imports System.Web.Services.Discovery
Imports System.IO
Imports System.Collections
Imports System.Security.Permissions
Imports MicroSoft.VisualBasic

Class DiscoveryDocumentReference_ReadDocument
   
   Shared Sub Main()
      Run()
   End Sub 'Main

   <PermissionSetAttribute(SecurityAction.Demand, Name := "FullTrust")> _
   Shared Sub Run()
      Try
' <Snippet1>
         Dim myUrl As String = "http://localhost/Sample_vb.vsdisco"
         Dim myProtocol As New DiscoveryClientProtocol()
         Dim myReference As New DiscoveryDocumentReference(myUrl)
         Dim myFileStream As Stream = myProtocol.Download(myUrl)
         Dim myDiscoveryDocument As DiscoveryDocument = _
                 CType(myReference.ReadDocument(myFileStream), DiscoveryDocument)
' </Snippet1>
         Dim myEnumerator As IEnumerator = myDiscoveryDocument.References.GetEnumerator()
         Console.WriteLine(ControlChars.NewLine + _
                 "The references to the discovery document are : " + ControlChars.NewLine)
         While myEnumerator.MoveNext()
            Dim myNewReference As DiscoveryDocumentReference = _
                 CType(myEnumerator.Current, DiscoveryDocumentReference)
            ' Print the discovery document references on the console.
            Console.WriteLine(myNewReference.Url)
         End While
      Catch e As Exception
         Console.WriteLine("Exception:{0}", e.Message.ToString())
      End Try
   End Sub 'Run

End Class 'DiscoveryDocumentReference_ReadDocument