// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample 
{
  public static void Main()
  {
    XmlNodeReader reader = null;

    try
    {
       //Create and load an XML document.
       XmlDocument doc = new XmlDocument();
       doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'harcover'>]>" +
                   "<book genre='novel' misc='sale-item &h; 1987'>" +
                   "</book>");
        
       //Create the reader. 
       reader = new XmlNodeReader(doc);

       //Read the misc attribute. The attribute is parsed into multiple 
       //text and entity reference nodes.
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

