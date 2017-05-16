' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<book genre='novel' publicationdate='1997'> " & _
                "  <title>Pride And Prejudice</title>" & _
                "</book>")
                         
    Dim attrColl as XmlAttributeCollection = doc.DocumentElement.Attributes

    ' Add a new attribute to the collection.
    Dim attr as XmlAttribute = doc.CreateAttribute("style")
    attr.Value = "hardcover"
    attrColl.SetNamedItem(attr)

    Console.WriteLine("Display the modified XML...")
    Console.WriteLine(doc.OuterXml)
    
  end sub
end class
 ' </Snippet1>

