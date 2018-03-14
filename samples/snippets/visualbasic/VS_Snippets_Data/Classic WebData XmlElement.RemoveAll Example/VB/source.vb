' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>" & _
                "<title>Pride And Prejudice</title>" & _
                "</book>")

    Dim root as XmlElement = doc.DocumentElement

    ' Remove all attributes and child nodes from the book element.
    root.RemoveAll()

    Console.WriteLine("Display the modified XML...")
    Console.WriteLine(doc.InnerXml)

  end sub
end class
   ' </Snippet1>

