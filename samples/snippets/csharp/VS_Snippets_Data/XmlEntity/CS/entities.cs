//<snippet1>
using System;
using System.IO;
using System.Xml;
 
public class Sample
{
  private const String filename = "doment.xml";
 
  public static void Main()
  {      
     XmlDocument doc = new XmlDocument();
     doc.Load(filename);
 
     Console.WriteLine("Display information on all entities...");     
     XmlNamedNodeMap nMap = doc.DocumentType.Entities;
     DisplayEntities(nMap);
  }
 
  public static void DisplayEntities(XmlNamedNodeMap nMap)
  {    
     for (int i=0; i < nMap.Count; i++)
     {
        XmlEntity ent = (XmlEntity) nMap.Item(i);
        Console.Write("{0} ", ent.NodeType);
        Console.Write("{0} ", ent.Name);
        Console.Write("{0} ", ent.NotationName);
        Console.Write("{0} ", ent.PublicId);
        Console.Write("{0} ", ent.SystemId);
        Console.WriteLine();
     }
  }
}
//</snippet1>

