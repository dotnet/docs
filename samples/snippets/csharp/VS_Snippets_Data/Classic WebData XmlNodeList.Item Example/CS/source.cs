// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {
  
     XmlDocument doc = new XmlDocument();
     doc.LoadXml("<items>" +
                 "  <item>First item</item>" +
                 "  <item>Second item</item>" +
                 "</items>");
                         
     //Get and display the last item node.
     XmlElement root = doc.DocumentElement;
     XmlNodeList nodeList = root.GetElementsByTagName("item");
     Console.WriteLine(nodeList.Item(1).InnerXml);     
    
  }
}
 // </Snippet1>

