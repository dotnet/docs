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

    'Try to display the attribute's owner element.
    if attr.OwnerElement is nothing
      Console.WriteLine("The attribute has not been added to an element")
      Console.WriteLine()
    else
      Console.WriteLine(attr.OwnerElement.OuterXml)
    end if

    'Add the attribute to an element.
    doc.DocumentElement.SetAttributeNode(attr)

    'Display the attribute's owner element.
    Console.WriteLine("Display the owner element...")
    Console.WriteLine(attr.OwnerElement.OuterXml)

  end sub
end class
   ' </Snippet1>

