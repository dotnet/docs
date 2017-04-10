' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim reader As XmlTextReader = Nothing
        
        Try
            ' Load the reader with the XML file.
            reader = New XmlTextReader("book2.xml")
            
            ' Parse the file.  If they exist, display the prefix and 
            ' namespace URI of each node.
            While reader.Read()
                If reader.IsStartElement() Then
                    If reader.Prefix = String.Empty Then
                        Console.WriteLine("<{0}>", reader.LocalName)
                    Else
                        Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName)
                        Console.WriteLine(" The namespace URI is " & reader.NamespaceURI)
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
