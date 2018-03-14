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
            
            ' Load the XmlNodeReader 
            reader = New XmlNodeReader(doc)
            
            'Read the ISBN attribute.
            reader.MoveToContent()
            Dim isbn As String = reader.GetAttribute("ISBN")
            Console.WriteLine("The ISBN value: " & isbn)
        
        
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main 
End Class 'Sample 
' </Snippet1>
