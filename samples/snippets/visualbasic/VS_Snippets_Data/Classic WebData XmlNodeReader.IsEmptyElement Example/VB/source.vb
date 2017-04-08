' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim reader As XmlNodeReader = Nothing
        
        Try
            'Create and load the XML document.
            Dim doc As New XmlDocument()
            doc.LoadXml("<book>" & _
                        "<title>Pride And Prejudice</title>" & _
                        "<price>19.95</price>" & _
                        "<misc/>" & _
                        "</book>")
            
            'Load the XmlNodeReader 
            reader = New XmlNodeReader(doc)
            
            'Parse the XML and display the text content of each of the elements.
            While reader.Read()
                If reader.IsStartElement() Then
                    If reader.IsEmptyElement Then
                        Console.WriteLine("<{0}/>", reader.Name)
                    Else
                        Console.Write("<{0}> ", reader.Name)
                        reader.Read() 'Read the start tag.
                        If (reader.IsStartElement())  'Handle nested elements.
                          Console.WriteLine()
                          Console.Write("<{0}>", reader.Name)
                        End If
                        Console.WriteLine(reader.ReadString()) 'Read the text content of the element.
                    End If
                End If
            End While
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
