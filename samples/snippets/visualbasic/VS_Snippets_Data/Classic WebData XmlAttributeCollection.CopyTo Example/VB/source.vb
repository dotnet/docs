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

    'Declare the array.
    Dim array(1) as XmlAttribute
    Dim index as integer=0

    'Copy all the attributes into the array.
    attrColl.CopyTo(array, index)

    Console.WriteLine("Display all the attributes in the array...")
    Dim attr as XmlAttribute
    for each attr in array
      Console.WriteLine("{0} = {1}",attr.Name,attr.Value)
    next
        
  end sub
end class
' </Snippet1>

