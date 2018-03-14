' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
   
   Public Shared Sub Main()
      Dim reader As XmlValidatingReader = Nothing
      Dim txtreader As XmlTextReader = Nothing
      
      Try
         'Create the validating reader.
         txtreader = New XmlTextReader("http://localhost/uri.xml")
         reader = New XmlValidatingReader(txtreader)
         reader.ValidationType = ValidationType.None
         
         'Parse the file and display the base URI for each node.
         While reader.Read()
            Console.WriteLine("({0}) {1}", reader.NodeType, reader.BaseURI)
         End While
      
      Finally
         If Not (reader Is Nothing) Then
            reader.Close()
         End If
      End Try
   End Sub 'Main ' End class
End Class 'Sample 
' </Snippet1>