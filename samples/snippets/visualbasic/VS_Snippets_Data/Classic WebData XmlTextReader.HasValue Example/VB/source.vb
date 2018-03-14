' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim reader As XmlTextReader = Nothing
        
        Try
            'Load the reader with the XML file.
            reader = New XmlTextReader("book1.xml")
            reader.WhitespaceHandling = WhitespaceHandling.None
            
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
    End Sub 'Main
End Class 'Sample 
' </Snippet1>