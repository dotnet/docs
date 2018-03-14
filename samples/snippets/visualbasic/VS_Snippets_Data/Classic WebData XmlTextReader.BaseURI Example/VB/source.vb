' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
   
   Public Shared Sub Main()
      Dim reader As XmlTextReader = Nothing
      
      Try
         'Load the reader with the XML file.
         reader = New XmlTextReader("http://localhost/baseuri.xml")
         
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