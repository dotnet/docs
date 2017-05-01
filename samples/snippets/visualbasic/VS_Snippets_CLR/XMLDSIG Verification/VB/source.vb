'<Snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.IO
Imports System.Xml

 _

Public Class Verify
   
   Public Shared Sub Main(args() As [String])
      
      Console.WriteLine(("Verifying " + args(0) + "..."))
      
      ' Create a SignedXml.
      Dim signedXml As New SignedXml()
      
      ' Load the XML.
      Dim xmlDocument As New XmlDocument()
      xmlDocument.PreserveWhitespace = True
      xmlDocument.Load(New XmlTextReader(args(0)))
      
      Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")
      signedXml.LoadXml(CType(nodeList(0), XmlElement))
      
      If signedXml.CheckSignature() Then
         Console.WriteLine("Signature check OK")
      Else
         Console.WriteLine("Signature check FAILED")
      End If
   End Sub 'Main 
End Class 'Verify
'</Snippet1>