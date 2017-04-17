' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<book xmlns:bk='urn:samples'>" & _
                "<bk:ISBN>1-861001-57-5</bk:ISBN>" & _
                "<title>Pride And Prejudice</title>" & _
                "</book>")

    ' Display information on the ISBN element.
    Dim elem as XmlElement 
    elem = CType(doc.DocumentElement.ChildNodes.Item(0),XmlElement) 
    Console.Write("{0}:{1} = {2}", elem.Prefix, elem.LocalName, elem.InnerText)
    Console.WriteLine("  namespaceURI=" + elem.NamespaceURI)

  end sub
end class
   ' </Snippet1>

