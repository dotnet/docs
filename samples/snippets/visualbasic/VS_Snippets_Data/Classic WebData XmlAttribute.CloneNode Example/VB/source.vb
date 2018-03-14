' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.Load("2elems.xml")
 
    'Create an attribute.
    Dim attr as XmlAttribute 
    attr = doc.CreateAttribute("bk","genre","urn:samples")
    attr.Value = "novel"

    'Add the attribute to the first book.
    Dim currNode as XmlElement
    currNode = CType(doc.DocumentElement.FirstChild, XmlElement) 
    currNode.SetAttributeNode(attr)

    'An attribute cannot be added to two different elements.  
    'You must clone the attribute and add it to the second book.
    Dim attr2 as XmlAttribute 
    attr2 = CType (attr.CloneNode(true), XmlAttribute) 
    currNode = CType(doc.DocumentElement.LastChild, XmlElement) 
    currNode.SetAttributeNode(attr2)

    Console.WriteLine("Display the modified XML...")
    Dim writer as XmlTextWriter = new XmlTextWriter(Console.Out)
    writer.Formatting = Formatting.Indented
    doc.WriteContentTo(writer)

  end sub
end class
' </Snippet1>

