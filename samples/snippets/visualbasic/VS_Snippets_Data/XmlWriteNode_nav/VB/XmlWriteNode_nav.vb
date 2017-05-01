'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath

Module Module1

    Sub Main()

        Dim doc As XPathDocument = New XPathDocument("books.xml")
        Dim nav As XPathNavigator = doc.CreateNavigator()

        ' Create a writer that outputs to the console.
        Dim writer As XmlWriter = XmlWriter.Create(Console.Out)

        ' Write the start tag.
        writer.WriteStartElement("myBooks")

        ' Write the first book.
        nav.MoveToChild("bookstore", "")
        nav.MoveToChild("book", "")
        writer.WriteNode(nav, False)

        ' Close the start tag.
        writer.WriteEndElement()

        ' Close the writer.
        writer.Close()

    End Sub
End Module
'</snippet1>