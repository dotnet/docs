'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic

public class Sample

  public shared sub Main()

    ' Create the XML fragment to be parsed.
    Dim xmlFrag as string = "<book>" + Chr(10) & _
                            "  <misc>"  + Chr(10) & _
                            "    <style>paperback</style>"  + Chr(10) & _
                            "    <pages>240</pages>" + Chr(10) & _
                            "  </misc>" + Chr(10) & _
                            "</book>"

    ' Create the XmlNamespaceManager.
    Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(new NameTable())

    ' Create the XmlParserContext.
    Dim context as XmlParserContext = new XmlParserContext(nothing, nsmgr, nothing, XmlSpace.None)

    ' Create the reader.
    Dim reader as XmlValidatingReader = new XmlValidatingReader(xmlFrag, XmlNodeType.Element, context)

    Dim lineInfo as IXmlLineInfo = CType(reader, IXmlLineInfo)
    if (lineInfo.HasLineInfo())
       
      ' Parse the XML and display each node.
      while (reader.Read())
       select case reader.NodeType
         case XmlNodeType.Element:
           Console.Write("{0} {1},{2}  ", reader.Depth, lineInfo.LineNumber, lineInfo.LinePosition)
           Console.WriteLine("<{0}>", reader.Name)
         case XmlNodeType.Text:
           Console.Write("{0} {1},{2}  ", reader.Depth, lineInfo.LineNumber, lineInfo.LinePosition)
           Console.WriteLine("  {0}", reader.Value)
         case XmlNodeType.EndElement:
           Console.Write("{0} {1},{2}  ", reader.Depth, lineInfo.LineNumber, lineInfo.LinePosition)
           Console.WriteLine("</{0}>", reader.Name)
       end select       
      end while           
    end if

    ' Close the reader.
    reader.Close()     
  
  end sub
end class
'</snippet1>


