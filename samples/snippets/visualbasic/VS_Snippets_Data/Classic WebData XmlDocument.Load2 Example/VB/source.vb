' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        'Create the XmlDocument.
        Dim doc As New XmlDocument()
        
        'Load the the document with the last book node.
        Dim reader As New XmlTextReader("books.xml")
        reader.WhitespaceHandling = WhitespaceHandling.None
        reader.MoveToContent()
        reader.Read()
        reader.Skip() 'Skip the first book.
        reader.Skip() 'Skip the second book.
        doc.Load(reader)
        
        doc.Save(Console.Out)
    End Sub 'Main
End Class 'Sample
' </Snippet1>

    Public Function LoadDocument(ByVal generateXML As Boolean) As XmlDocument
        <Snippet2>
        Dim doc As XmlDocument = New XmlDocument
        doc.PreserveWhitespace = True
        
        Try
            doc.Load("booksData.xml")
        Catch ex As System.IO.FileNotFoundException
            ' If no file is found, generate some XML.
            doc.LoadXml("<?xml version=""1.0""?> " & ControlChars.NewLine & _
                "<books xmlns=""http://www.contoso.com/books""> " & ControlChars.NewLine & _
                "  <book genre=""novel"" ISBN=""1-861001-57-8"" publicationdate=""1823-01-28""> " & ControlChars.NewLine & _
                "    <title>Pride And Prejudice</title> " & ControlChars.NewLine & _
                "    <price>24.95</price> " & ControlChars.NewLine & _
                "  </book> " & ControlChars.NewLine & _
                "  <book genre=""novel"" ISBN=""1-861002-30-1"" publicationdate=""1985-01-01""> " & ControlChars.NewLine & _
                "    <title>The Handmaid's Tale</title> " & ControlChars.NewLine & _
                "    <price>29.95</price> " & ControlChars.NewLine & _
                "  </book> " & ControlChars.NewLine & _
                "</books>")
        End Try
</Snippet2>
        Return doc
    End Function