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

    Console.WriteLine("Display information on all notations...");     
    XmlNamedNodeMap nMap = doc.DocumentType.Notations;
    DisplayNotations(nMap);      
  }
 
  public static void DisplayNotations(XmlNamedNodeMap nMap)
  {   
     for (int i=0; i < nMap.Count; i++)
     {
        XmlNotation note = (XmlNotation) nMap.Item(i);
        Console.Write("{0} ", note.NodeType);
        Console.Write("{0} ", note.Name);
        Console.Write("{0} ", note.PublicId);
        Console.Write("{0} ", note.SystemId);
        Console.WriteLine();
    }
  }            
}
//</snippet1>

