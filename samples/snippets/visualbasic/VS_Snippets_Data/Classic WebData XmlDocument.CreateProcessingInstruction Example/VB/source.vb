' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()
  
    Dim doc as XmlDocument = new XmlDocument()

    ' Create a procesing instruction.
    Dim newPI as XmlProcessingInstruction 
    Dim PItext as String = "type='text/xsl' href='book.xsl'"
    newPI = doc.CreateProcessingInstruction("xml-stylesheet", PItext)

    ' Display the target and data information.
    Console.WriteLine("<?{0} {1}?>", newPI.Target, newPI.Data)

    ' Add the processing instruction node to the document.
    doc.AppendChild(newPI)

  end sub
end class
' </Snippet1>
