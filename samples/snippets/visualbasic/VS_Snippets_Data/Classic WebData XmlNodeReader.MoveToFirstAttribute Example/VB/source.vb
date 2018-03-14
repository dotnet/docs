' <Snippet1>
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
            
            'Read the genre attribute.
            reader.MoveToContent()
            reader.MoveToFirstAttribute()
            Dim genre As String = reader.Value
            Console.WriteLine("The genre value: " & genre)
        
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
