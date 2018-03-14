' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" & _
                "<title>Pride And Prejudice</title>" & _
                "</book>")      

    Dim root as XmlElement = doc.DocumentElement

    ' Check to see if the element has a genre attribute.
    if (root.HasAttribute("genre"))
     Dim attr as XmlAttribute = root.GetAttributeNode("genre")
     Console.WriteLine(attr.Value)
    end if
       
    Console.WriteLine("Display the modified XML...")
    Console.WriteLine(doc.InnerXml)

  end sub
end class
   ' </Snippet1>

