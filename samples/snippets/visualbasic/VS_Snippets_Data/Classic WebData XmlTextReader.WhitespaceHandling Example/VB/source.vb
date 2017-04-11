' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample 

  public shared sub Main()

    'Create the XML fragment to be parsed.
    Dim xmlFrag as string ="<book> " & _
                           "  <title>Pride And Prejudice</title>" & _
                           "  <genre>novel</genre>" & _
                           "</book>" 

    'Create the XmlNamespaceManager.
    Dim nt as NameTable = new NameTable()
    Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(nt)

    'Create the XmlParserContext.
    Dim context as XmlParserContext = new XmlParserContext(nothing, nsmgr, nothing, XmlSpace.Default)

    Console.WriteLine("Read the XML and ignore all white space...")
    ReadXML(context, xmlFrag, WhitespaceHandling.None)

    Console.WriteLine()
    Console.WriteLine("Read the XML including white space nodes...")
    ReadXML(context, xmlFrag, WhitespaceHandling.All)
  end sub
  
  public shared sub ReadXML(context as XmlParserContext, xmlFrag as string, ws as WhitespaceHandling)

    'Create the reader and specify the WhitespaceHandling setting.
    Dim reader as XmlTextReader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context)
    reader.WhitespaceHandling = ws

      'Parse the XML and display each of the nodes.
      while (reader.Read())
         select case reader.NodeType
           case XmlNodeType.Element:
             Console.WriteLine("{0}: <{1}>", reader.NodeType, reader.Name)
           case XmlNodeType.Text:
             Console.WriteLine("{0}: {1}", reader.NodeType, reader.Value)
           case XmlNodeType.EndElement:
             Console.WriteLine("{0}: </{1}>", reader.NodeType, reader.Name)
           case XmlNodeType.Whitespace:
             Console.WriteLine("{0}:", reader.NodeType)
           case XmlNodeType.SignificantWhitespace:
             Console.WriteLine("{0}:", reader.NodeType)
         end select       
      end while           
  
    'Close the reader.
    reader.Close()     
  
  end sub
end class

' </Snippet1>
