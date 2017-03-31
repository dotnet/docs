' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<book>" & _
                "<title>Pride And Prejudice</title>" & _
                "</book>") 

    'Create an attribute.
    Dim attr as XmlAttribute
    attr = doc.CreateAttribute("bk","genre","urn:samples")
    attr.Value = "novel"

    'Display the attribute's owner document. Note
    'that although the attribute has not been inserted
    'into the document, it still has an owner document.
    Console.WriteLine(attr.OwnerDocument.OuterXml)

  end sub
end class
   ' </Snippet1>

