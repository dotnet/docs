' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim reader As XmlTextReader = Nothing
        
        Try
            'Load the reader with the XML file.
            reader = New XmlTextReader("attrs.xml")
            
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