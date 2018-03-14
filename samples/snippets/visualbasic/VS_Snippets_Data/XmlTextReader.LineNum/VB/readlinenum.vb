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
    Dim nt as NameTable = new NameTable()
    Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(nt)

    ' Create the XmlParserContext.
    Dim context as XmlParserContext = new XmlParserContext(nothing, nsmgr, nothing, XmlSpace.None)

    ' Create the reader.
    Dim reader as XmlTextReader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context)

    ' Parse the XML and display each node.
    while (reader.Read())
       select case reader.NodeType
         case XmlNodeType.Element:
           Console.Write("{0} {1},{2}  ", reader.Depth, reader.LineNumber, reader.LinePosition)
           Console.WriteLine("<{0}>", reader.Name)
         case XmlNodeType.Text:
           Console.Write("{0} {1},{2}  ", reader.Depth, reader.LineNumber, reader.LinePosition)
           Console.WriteLine("  {0}", reader.Value)
         case XmlNodeType.EndElement:
           Console.Write("{0} {1},{2}  ", reader.Depth, reader.LineNumber, reader.LinePosition)
           Console.WriteLine("</{0}>", reader.Name)
       end select       
    end while           

    ' Close the reader.
    reader.Close()      
  end sub
end class
'</snippet1>


