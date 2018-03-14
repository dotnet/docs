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

    ' Create a new element.
    Dim elem as XmlElement = doc.CreateElement("price")
    elem.InnerText="19.95"

    ' Display the element's owner document. Note
    ' that although the element has not been inserted
    ' into the document, it still has an owner document.
    Console.WriteLine(elem.OwnerDocument.OuterXml)
    
    'Add the element into the document.
    root.AppendChild(elem)

    Console.WriteLine("Display the modified XML...")
    Console.WriteLine(doc.InnerXml)

  end sub
end class
   ' </Snippet1>

