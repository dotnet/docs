' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    'Load XML data which includes white space, but ignore
    'any white space in the file.
    Dim doc as XmlDocument = new XmlDocument()
    doc.PreserveWhitespace = false
    doc.Load("book.xml")

    'Save the document as is (no white space).
    Console.WriteLine("Display the modified XML...")
    doc.PreserveWhitespace = true
    doc.Save(Console.Out)

  end sub
end class
   ' </Snippet1>

