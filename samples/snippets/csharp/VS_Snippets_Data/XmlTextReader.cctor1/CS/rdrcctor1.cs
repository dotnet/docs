//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  public static void Main() {

    string xmlData = 
    @"<book>
       <title>Oberon's Legacy</title>
       <price>5.95</price>
      </book>";

    // Create the reader.
    XmlTextReader reader = new XmlTextReader(new StringReader(xmlData));
    reader.WhitespaceHandling = WhitespaceHandling.None;

    // Display each element node.
    while (reader.Read()){
       switch (reader.NodeType){
         case XmlNodeType.Element:
           Console.Write("<{0}>", reader.Name);
           break;
         case XmlNodeType.Text:
           Console.Write(reader.Value);
           break;
         case XmlNodeType.EndElement:
           Console.Write("</{0}>", reader.Name);
           break;
      }       
    }           

    // Close the reader.
    reader.Close();       
  }
} // End class
//</snippet1>


