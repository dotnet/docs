'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub Main()

    Dim reader as XmlTextReader = nothing

    try
       'Create the XML fragment to be parsed.
       Dim xmlFrag as string ="<book genre='novel' misc='sale-item &h; 1987'></book>"
 
       'Create the XmlParserContext.
       Dim context as XmlParserContext 
       Dim subset as string = "<!ENTITY h 'hardcover'>"
       context = new XmlParserContext(nothing, nothing, "book", nothing, nothing, subset, "", "", XmlSpace.None)
        
       'Create the reader.
       reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context)
  
       'Read the misc attribute. The attribute is parsed
       'into multiple text and entity reference nodes.
       reader.MoveToContent()
       reader.MoveToAttribute("misc")
       while (reader.ReadAttributeValue())
          if (reader.NodeType = XmlNodeType.EntityReference)
            Console.WriteLine("{0} {1}", reader.NodeType, reader.Name)
          else
             Console.WriteLine("{0} {1}", reader.NodeType, reader.Value)
          end if
        end while

     finally 
       if Not reader Is Nothing
        reader.Close()
      End if
      end try
  end sub
end class 
'</snippet1>


