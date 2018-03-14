' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    Public Shared Sub Main()
        Dim reader As XmlNodeReader = Nothing
        
        Try
            'Create and load an XmlDocument.
            Dim doc As New XmlDocument()
            doc.LoadXml("<?xml version='1.0' ?>" & _
                        "<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" & _
                        "<book>" & _
                        "<title>Pride And Prejudice</title>" & _
                        "<misc>&h;</misc>" & _
                        "</book>")
            
            reader = New XmlNodeReader(doc)
            
            'Parse the file and display each node.
            While reader.Read()
                If reader.HasValue Then
                    Console.WriteLine("({0})  {1}={2}", reader.NodeType, reader.Name, reader.Value)
                Else
                    Console.WriteLine("({0}) {1}", reader.NodeType, reader.Name)
                End If
            End While
        
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main ' End class
End Class 'Sample 
' </Snippet1>
