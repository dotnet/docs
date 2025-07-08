' <Snippet1>
Option Explicit On
Option Strict On
Imports System.Xml

Public Class LastChildSample
    Public Shared Sub Main()

        Dim doc As New XmlDocument()
        doc.LoadXml("<book ISBN='1-861001-57-5'>" &
                    "<title>Pride And Prejudice</title>" &
                    "<price>19.95</price>" &
                    "</book>")

        Dim root As XmlNode = doc.FirstChild

        Console.WriteLine("Display the price element...")
        Console.WriteLine(root.LastChild.OuterXml)
    End Sub
End Class
' </Snippet1>
