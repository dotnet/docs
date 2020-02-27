' <Snippet1>
Imports System.Xml

public class Sample 

  public shared sub Main() 

        Dim doc as XmlDocument = new XmlDocument()
        doc.LoadXml("<book>" & _
                    "  <title>Oberon's Legacy</title>" & _
                    "  <price>5.95</price>" & _
                       "</book>") 
 
        ' Create a new element node.
        ' It is possible to supply a prefix for this node, and specify a qualified namespace
        Dim newElem as XmlNode
        newElem = doc.CreateNode(XmlNodeType.Element,"g", "ISBN","https://global.ISBN/list")
        newElem.InnerText = "1-861001-57-5"
     
        ' Add the new element to the document
        Dim root as XmlElement = doc.DocumentElement
        root.AppendChild(newElem)
     
        ' Display the modified XML document
        Console.WriteLine(doc.OuterXml)
        
        ' Output:
        ' <book><title>Oberon's Legacy</title><price>5.95</price><g:ISBN xmlns:g="https://global.ISBN/list">1-861001-57-5</g:ISBN></book>
   end sub
end class
' </Snippet1>

