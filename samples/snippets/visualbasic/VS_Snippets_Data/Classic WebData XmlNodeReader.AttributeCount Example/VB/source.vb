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
            doc.LoadXml("<book genre='novel' ISBN='1-861003-78' publicationdate='1987'> " & _
                       "</book>")
            
            'Load the XmlNodeReader 
            reader = New XmlNodeReader(doc)
            
            'Read the attributes on the root element.
            reader.MoveToContent()
            If reader.HasAttributes Then
                Dim i As Integer
                For i = 0 To reader.AttributeCount - 1
                    reader.MoveToAttribute(i)
                    Console.WriteLine("{0} = {1}", reader.Name, reader.Value)
                Next i
                'Return the reader to the book element.
                reader.MoveToElement()
            End If
        
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
