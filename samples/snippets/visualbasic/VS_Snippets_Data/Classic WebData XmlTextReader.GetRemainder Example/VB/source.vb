' <Snippet1>
Imports System
Imports System.Xml

Public Class Sample
    Private Shared filename As String = "tworeads.xml"
    
    Public Shared Sub Main()

        Dim reader As New XmlTextReader(filename)
        reader.WhitespaceHandling = WhitespaceHandling.None
        
        ' Read the first part of the XML document
        While reader.Read()
            ' Display the elements and stop reading on the book endelement tag
            ' then go to ReadPart2 to start another reader to read the rest of the file. 
            Select Case reader.NodeType
                Case XmlNodeType.Element
                    Console.WriteLine("Name: {0}", reader.Name)
                Case XmlNodeType.Text
                    Console.WriteLine("  Element Text: {0}", reader.Value)
                Case XmlNodeType.EndElement
                    ' Stop reading when the reader gets to the end element of the book node.
                    If "book" = reader.LocalName Then
                        Console.WriteLine("End reading first book...")
                        Console.WriteLine()
                        GoTo ReadPart2
                    End If
            End Select
        End While
        
        ' Read the rest of the XML document
        ReadPart2: 
        Console.WriteLine("Begin reading second book...")
        
        ' Create a new reader to read the rest of the document.
        Dim reader2 As New XmlTextReader(reader.GetRemainder())
        
        While reader2.Read()
            Select Case reader2.NodeType
                Case XmlNodeType.Element
                    Console.WriteLine("Name: {0}", reader2.Name)
                Case XmlNodeType.Text
                    Console.WriteLine("  Element Text: {0}", reader2.Value)
                Case XmlNodeType.EndElement
                    'Stop reading when the reader gets to the end element of the book node.
                    If "book" = reader2.LocalName Then
                        Console.WriteLine("End reading second book...")
                        GoTo Done
                    End If
            End Select
        End While
        
        Done: 
        Console.WriteLine("Done.")
        reader.Close()
        reader2.Close()
    End Sub 'Main
End Class 'Sample
' </Snippet1>