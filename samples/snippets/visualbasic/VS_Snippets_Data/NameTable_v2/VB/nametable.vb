Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
        
    Public Shared Sub Main() 
        
        '<snippet1>
        ' Add the element names to the NameTable.
        Dim nt As New NameTable()
        Dim book As Object = nt.Add("book")
        Dim title As Object = nt.Add("title")
        
        ' Create a reader that uses the NameTable.
        Dim settings As New XmlReaderSettings()
        settings.NameTable = nt
        Dim reader As XmlReader = XmlReader.Create("books.xml", settings)
        
        While reader.Read()
            If reader.NodeType = XmlNodeType.Element Then
                ' Cache the local name to prevent multiple calls to the LocalName property.
                Dim localname As Object = reader.LocalName
                
                ' Do a comparison between the object references. This just compares pointers.
                If book Is localname Then
                   ' Add additional processing here.
                End If 
                ' Do a comparison between the object references. This just compares pointers.
                If title Is localname Then
                   ' Add additional processing here.
                End If 
            End If
        End While 
        
        ' Close the reader.
        reader.Close()
'</snippet1>
    
    End Sub 'Main 
End Class 'Sample 
