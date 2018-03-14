'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic

public class Sample

  public shared sub Main()

    ' Create the XML fragment to be parsed.
    Dim xmlFrag as string = "<item attr1='  test A B C " + Chr(10) & _
                            "   1 2 3'/>" + Chr(10) & _
                            "<item attr2='&#01;'/>"
                    

    ' Create the XmlNamespaceManager.
    Dim nsmgr as XmlNamespaceManager = new XmlNamespaceManager(new NameTable())

    ' Create the XmlParserContext.
    Dim context as XmlParserContext = new XmlParserContext(nothing, nsmgr, nothing, XmlSpace.Preserve)

    ' Create the reader.
    Dim reader as XmlTextReader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context)

    ' Show attribute value normalization.
    reader.Read()
    reader.Normalization = false
    Console.WriteLine("Attribute value:{0}", reader.GetAttribute("attr1"))
    reader.Normalization = true
    Console.WriteLine("Attribute value:{0}", reader.GetAttribute("attr1"))

    ' Set Normalization back to false.  This allows the reader to accept
    ' character entities in the &#00; to &#20; range.  If Normalization had
    ' been set to true, character entities in this range throw an exception.
    reader.Normalization = false
    reader.Read()
    reader.MoveToContent()
    Console.WriteLine("Attribute value:{0}", reader.GetAttribute("attr2"))
  
    ' Close the reader.
    reader.Close()     
  
  end sub
end class
'</snippet1>


