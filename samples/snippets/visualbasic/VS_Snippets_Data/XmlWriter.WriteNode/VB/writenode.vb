'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim reader as XmlTextReader = new XmlTextReader("books.xml")
    reader.WhitespaceHandling = WhitespaceHandling.None

    'Move the reader to the first book element.
    reader.MoveToContent()
    reader.Read()

    'Create a writer that outputs to the console.
    Dim writer as XmlTextWriter = new XmlTextWriter (Console.Out)
    writer.Formatting = Formatting.Indented
	
    'Write the start tag.
    writer.WriteStartElement("myBooks")

    'Write the first book.
    writer.WriteNode(reader, false)

    'Skip the second book.
    reader.Skip()

    'Write the last book.
    writer.WriteNode(reader, false)
    writer.WriteEndElement()

    'Close the writer and the reader.
    writer.Close()
    reader.Close()

  end sub
end class
'</snippet1>