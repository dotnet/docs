'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

     Dim writer as XmlTextWriter = new XmlTextWriter (Console.Out)
     'Use indenting for readability
     writer.Formatting = Formatting.Indented
	
     'Write an XML fragment.
     writer.WriteStartElement("book")
     writer.WriteElementString("title", "Pride And Prejudice")
     writer.WriteEndElement()
     writer.Flush()

     'Write another XML fragment.
     writer.WriteStartElement("cd")
     writer.WriteElementString("title", "Americana")
     writer.WriteEndElement()
     writer.Flush()  

     'Close the writer.
     writer.Close()

  end sub
end class
'</snippet1>