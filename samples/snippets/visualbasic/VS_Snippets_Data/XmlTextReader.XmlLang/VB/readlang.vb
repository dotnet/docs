'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample 

  public shared sub Main()

    'Create the XML fragment to be parsed.
    Dim xmlFrag as string = "<book xml:lang='en-US'> " & _
                                    "  <title xml:lang='en-GB'>Colour Analysis</title>" & _
                                    "  <title>Color Analysis</title>" & _
                                    "</book>" 

    'Create the XmlNamespaceManager.
    Dim nt as NameTable = new NameTable()
    Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(nt)

    'Create the XmlParserContext.
    Dim context as XmlParserContext = new XmlParserContext(nothing, nsmgr, nothing, XmlSpace.None)

    'Create the reader.
    Dim reader as XmlTextReader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context)
    reader.WhitespaceHandling = WhitespaceHandling.None

    'Parse the XML and display each of the nodes, including the xml:lang setting.
    while (reader.Read())
       select case reader.NodeType
         case XmlNodeType.Element:
           Console.WriteLine("{0}: <{1}>", reader.XmlLang, reader.Name)
         case XmlNodeType.Text:
           Console.WriteLine("{0}: {1}", reader.XmlLang, reader.Value)
         case XmlNodeType.EndElement:
           Console.WriteLine("{0}: </{1}>", reader.XmlLang, reader.Name)
       end select       
    end while           
  
    'Close the reader.
    reader.Close()     
  
  end sub
end class
'</snippet1>


