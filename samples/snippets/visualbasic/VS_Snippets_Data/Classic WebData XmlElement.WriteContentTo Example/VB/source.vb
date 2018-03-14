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

    ' Note that because WriteContentTo saves only the children of the element
    ' to the writer none of the attributes are displayed.
    Console.WriteLine("Display the contents of the element...")
    Dim writer as XmlTextWriter = new XmlTextWriter(Console.Out)
    writer.Formatting = Formatting.Indented
    root.WriteTo(writer)

  end sub
end class
   ' </Snippet1>

