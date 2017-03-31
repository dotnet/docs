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
            doc.LoadXml("<book xmlns:bk='urn:samples'> " & _
                       "<title>Pride And Prejudice</title>" & _
                       "<bk:genre>novel</bk:genre>" & _
                       "</book>")
            
            'Load the XmlNodeReader 
            reader = New XmlNodeReader(doc)
            
            'Parse the XML.  If they exist, display the prefix and  
            'namespace URI of each node.
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
