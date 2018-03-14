' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<book xmlns:bk='urn:samples' bk:genre='novel'>" & _
                "<title>Pride And Prejudice</title>" & _
                "</book>") 

    'Create an attribute collection.
    Dim attrColl as XmlAttributeCollection = doc.DocumentElement.Attributes

    Console.WriteLine("Display information on each of the attributes... ")
    Dim attr as XmlAttribute
    for each attr in attrColl
       Console.Write("{0} = {1}", attr.Name, attr.Value)
       Console.WriteLine("   namespaceURI=" + attr.NamespaceURI)
    next

  end sub
end class
   ' </Snippet1>

