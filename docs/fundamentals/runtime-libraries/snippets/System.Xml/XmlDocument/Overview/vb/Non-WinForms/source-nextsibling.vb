' <Snippet1>
Imports System.Xml

Public Class NextSiblingSample
    Public Shared Sub Main()

        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("books.xml")

        Dim currNode As XmlNode = doc.DocumentElement.FirstChild
        Console.WriteLine("First book...")
        Console.WriteLine(currNode.OuterXml)

        Dim nextNode As XmlNode = currNode.NextSibling
        Console.WriteLine(ControlChars.Lf + "Second book...")
        Console.WriteLine(nextNode.OuterXml)

    End Sub
End Class
' </Snippet1>
