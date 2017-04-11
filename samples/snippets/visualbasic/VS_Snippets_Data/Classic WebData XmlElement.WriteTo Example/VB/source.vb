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

    ' Add a new attribute.
    root.SetAttribute("genre", "urn:samples", "novel")

    Console.WriteLine("Display the modified XML...")
    Dim writer as XmlTextWriter = new XmlTextWriter(Console.Out)
    writer.Formatting = Formatting.Indented
    root.WriteTo(writer)

  end sub
end class
   ' </Snippet1>

