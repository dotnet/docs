Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Sample
    
    ' <Snippet1>
    Private Sub serializer_UnknownNode _
                    (ByVal sender As Object, _
                     ByVal e As XmlNodeEventArgs)
        Console.WriteLine("UnknownNode Namespace URI: " & e.NamespaceURI)
    End Sub
    ' </Snippet1>
End Class

