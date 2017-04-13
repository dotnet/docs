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

    'Create an attribute collection.
    Dim attrColl as XmlAttributeCollection = doc.DocumentElement.Attributes

    Console.WriteLine("Display all the attributes in the collection...")
    Dim i as integer
    for i=0  to attrColl.Count-1
      Console.Write("{0} = ", attrColl.ItemOf(i).Name)
      Console.Write("{0}", attrColl.ItemOf(i).Value)
      Console.WriteLine()
    next
        
  end sub
end class
   ' </Snippet1>

