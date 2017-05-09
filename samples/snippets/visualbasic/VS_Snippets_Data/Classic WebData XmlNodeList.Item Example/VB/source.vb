' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<items>" & _
                "  <item>First item</item>" & _
                "  <item>Second item</item>" & _
                "</items>")
                         
     'Get and display the last item node.
     Dim root as XmlElement = doc.DocumentElement
     Dim nodeList as XmlNodeList = root.GetElementsByTagName("item")
     Console.WriteLine(nodeList.Item(1).InnerXml)
    
  end sub
end class
 ' </Snippet1>

