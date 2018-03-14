'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample 

  public shared sub Main()

    Dim xmlData as string 
    xmlData = "<book>" & _
              "  <title>Oberon's Legacy</title>" & _
              "  <price>5.95</price>" & _
              "</book>"

    ' Create the reader.
    Dim reader as XmlTextReader = new XmlTextReader(new StringReader(xmlData))
    reader.WhitespaceHandling = WhitespaceHandling.None

    ' Display each element node.
    while reader.Read()
       select case reader.NodeType
         case XmlNodeType.Element
           Console.Write("<{0}>", reader.Name)
         case XmlNodeType.Text
           Console.Write(reader.Value)
         case XmlNodeType.EndElement
           Console.Write("</{0}>", reader.Name)
       end select       
    end while           

    ' Close the reader.
    reader.Close()       
  end sub
end class
'</snippet1>


