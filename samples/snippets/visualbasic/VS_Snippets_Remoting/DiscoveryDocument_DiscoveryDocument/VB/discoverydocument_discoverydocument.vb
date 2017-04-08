' System.Web.Services.Discovery.DiscoveryDocument.DiscoveryDocument
' System.Web.Services.Discovery.DiscoveryDocument.Namespace
' System.Web.Services.Discovery.DiscoveryDocument.CanRead
' System.Web.Services.Discovery.DiscoveryDocument.Read( XmlReader )
' System.Web.Services.Discovery.DiscoveryDocument.References

' The following example demonstrates the 'DiscoveryDocument' constructor,
' 'Namespace' field, 'References' property and the 'CanRead' and 'Read( XmlReader )'
' methods of the 'DiscoveryDocument' class.
' The namespace field is displayed onto the console. A XmlTextReader object is
' created with a sample discovery file and this is passed to the CanRead method
' to check wether it is readable. Then we read this file to create a Discovery
' document and display the references in the created document.

' <Snippet1>
Imports System
Imports System.Xml
Imports System.IO
Imports System.Web.Services.Discovery
Imports System.Collections

Public Class DiscoveryDocument_Example
   
   Shared Sub Main()
      Try

         ' Create an object of the 'DiscoveryDocument'.
         Dim myDiscoveryDocument As New DiscoveryDocument()

' <Snippet2>
         ' Display the 'Namespace' field.
         Console.WriteLine("The namespace is : " + DiscoveryDocument.Namespace)
' </Snippet2>
         ' Create an XmlTextReader with the sample file.
         Dim myXmlTextReader As New XmlTextReader("http://localhost/example.vsdisco")
         
' <Snippet3>
' <Snippet4>
         ' Check whether the given XmlTextReader is readable.
         If DiscoveryDocument.CanRead(myXmlTextReader) = True Then
            ' Read the given XmlTextReader.
            myDiscoveryDocument = DiscoveryDocument.Read(myXmlTextReader)
         Else
            Console.WriteLine("The supplied file is not readable")
         End If
' </Snippet4>
' </Snippet3>
         
' <Snippet5>
         ' Enumerate the 'References' in the DiscoveryDocument.
         Dim myEnumerator As IEnumerator = myDiscoveryDocument.References.GetEnumerator()
         Console.WriteLine("The 'References' in the discovery document are-")
         While myEnumerator.MoveNext()
            Console.Write(CType(myEnumerator.Current, DiscoveryDocumentReference).Url)
         End While
' </Snippet5>
         Console.WriteLine()
      Catch e As Exception
         Console.WriteLine("Exception raised : {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'DiscoveryDocument_Example
' </Snippet1>