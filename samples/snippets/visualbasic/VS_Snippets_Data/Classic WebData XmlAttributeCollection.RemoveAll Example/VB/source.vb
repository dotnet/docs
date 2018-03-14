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

    'Create an attribute collection and remove an attribute
    'from the collection.  
    Dim attrColl as XmlAttributeCollection = doc.DocumentElement.Attributes
    attrColl.RemoveAll()

    Console.WriteLine("Display the modified XML...")
    Console.WriteLine(doc.OuterXml)

  end sub
end class
   ' </Snippet1>

