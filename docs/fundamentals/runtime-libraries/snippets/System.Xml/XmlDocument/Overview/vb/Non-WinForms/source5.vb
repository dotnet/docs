' <Snippet1>
Imports System.Xml

Public Class Sample5
    Public Shared Sub Main()
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load("books.xml")

        Dim lastNode As XmlNode = doc.DocumentElement.LastChild
        Console.WriteLine("Last book...")
        Console.WriteLine(lastNode.OuterXml)

        Dim prevNode As XmlNode = lastNode.PreviousSibling
        Console.WriteLine(ControlChars.Lf + "Previous book...")
        Console.WriteLine(prevNode.OuterXml)
    End Sub
End Class
' </Snippet1>
