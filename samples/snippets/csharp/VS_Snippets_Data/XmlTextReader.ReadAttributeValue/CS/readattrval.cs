//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main()
  {
    XmlTextReader reader = null;

    try
    {
       //Create the XML fragment to be parsed.
       string xmlFrag ="<book genre='novel' misc='sale-item &h; 1987'></book>";
 
       //Create the XmlParserContext.
       XmlParserContext context;
       string subset = "<!ENTITY h 'hardcover'>";
       context = new XmlParserContext(null, null, "book", null, null, subset, "", "", XmlSpace.None);
        
       //Create the reader.
       reader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);
  
       //Read the misc attribute. The attribute is parsed
       //into multiple text and entity reference nodes.
       reader.MoveToContent();
       reader.MoveToAttribute("misc");
       while (reader.ReadAttributeValue()){
          if (reader.NodeType==XmlNodeType.EntityReference)
            Console.WriteLine("{0} {1}", reader.NodeType, reader.Name);
          else
             Console.WriteLine("{0} {1}", reader.NodeType, reader.Value);
        } 
     } 
     finally 
     {
        if (reader != null)
          reader.Close();
      }
  }
} // End class
//</snippet1>

