// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main()
  {
    XmlValidatingReader reader = null;

    try
    {
       //Create the XML fragment to be parsed.
       string xmlFrag ="<book genre='novel' misc='sale-item &h; 1987'></book>";

       //Create the XmlParserContext.
       XmlParserContext context;
       string subset = "<!ENTITY h 'hardcover'>";
       context = new XmlParserContext(null, null, "book", null, null, subset, "", "", XmlSpace.None);
        
       //Create the reader and set it to not expand general entities. 
       reader = new XmlValidatingReader(xmlFrag, XmlNodeType.Element, context);
       reader.ValidationType = ValidationType.None;
       reader.EntityHandling = EntityHandling.ExpandCharEntities;
  
       //Read the misc attribute. Because EntityHandling is set to
       //ExpandCharEntities, the attribute is parsed into multiple text
       //and entity reference nodes.
       reader.MoveToContent();
       reader.MoveToAttribute("misc");
       while (reader.ReadAttributeValue()){
          if (reader.NodeType==XmlNodeType.EntityReference)
            //To expand the entity, call ResolveEntity.
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
   // </Snippet1>

