' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()
  
    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<book ISBN='1-861001-57-5'>" & _
                "<title>Pride And Prejudice</title>" & _
                "</book>")      

    'Create a new attribute.
    Dim newAttr as XmlAttribute = doc.CreateAttribute("genre")
    newAttr.Value = "novel"

    'Create an attribute collection and add the new attribute
    'to the collection.  
    Dim attrColl as XmlAttributeCollection = doc.DocumentElement.Attributes
    attrColl.InsertBefore(newAttr, attrColl.ItemOf(0))

    Console.WriteLine("Display the modified XML...")
    Console.WriteLine(doc.OuterXml)

  end sub
end class
   ' </Snippet1>

