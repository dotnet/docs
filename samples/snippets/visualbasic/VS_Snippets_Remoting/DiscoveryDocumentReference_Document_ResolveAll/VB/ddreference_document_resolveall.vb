' System.Web.Services.Discovery.DiscoveryDocumentReference.Document
' System.Web.Services.Discovery.DiscoveryDocumentReference.ResolveAll()

' This program demonstrates the 'Document' property and 'ResolveAll()' method of 
' 'DiscoveryDocumentReference' class. Set the 'ClientProtocol' of
' 'DiscoveryDocumentReference' class. The validity of the documents within the discovery
' document is verified using the 'ResolveAll' method and the valid references to the
' discovery documents are displayed on the console using the 'Document' property.

' <Snippet2>
Imports System
Imports System.Web.Services.Discovery
Imports System.Collections
Imports System.Security.Permissions
Imports MicroSoft.VisualBasic

Class DiscoveryDocumentReference_Document_ResolveAll
   
   Shared Sub Main()
      Run()
   End Sub 'Main

   <PermissionSetAttribute(SecurityAction.Demand, Name := "FullTrust")> _
   Shared Sub Run()
      Try
' <Snippet1>
         Dim myUrl As String = "http://localhost/Sample_vb.vsdisco"
         Dim myProtocol As New DiscoveryClientProtocol()
         ' Get the discovery document myDiscoveryDocument.
         Dim myDiscoveryDocument As DiscoveryDocument = myProtocol.Discover(myUrl)
         ' Get the references of myDiscoveryDocument.
         Dim myEnumerator As IEnumerator = myDiscoveryDocument.References.GetEnumerator()
         While myEnumerator.MoveNext()
            Dim myNewReference As DiscoveryDocumentReference = _ 
                                  CType(myEnumerator.Current, DiscoveryDocumentReference)
            ' Set the ClientProtocol of myNewReference.
            Dim myNewProtocol As DiscoveryClientProtocol = myNewReference.ClientProtocol
            ' Verify for all the valid references.
            myNewReference.ResolveAll()

            ' Get the document of myNewReference.
            Dim myNewDiscoveryDocument As DiscoveryDocument = myNewReference.Document
            Dim myNewEnumerator As IEnumerator = _ 
                                     myNewDiscoveryDocument.References.GetEnumerator()
            Console.WriteLine("The valid discovery document is : " + ControlChars.NewLine)
            While myNewEnumerator.MoveNext()
               ' Display the references of myNewDiscoveryDocument on the console.
               Console.WriteLine(CType(myNewEnumerator.Current, DiscoveryDocumentReference).Ref)
            End While
         End While
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception :{0}", e.Message)
      End Try
   End Sub 'Run
End Class 'DiscoveryDocumentReference_Document_ResolveAll
' </Snippet2>
