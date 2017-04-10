//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample{

  public static void Main(){

     XmlTextReader reader = new XmlTextReader("authors.xml");
     reader.WhitespaceHandling = WhitespaceHandling.None;

     // Parse the file.  Return white space only if an
     // xml:space='preserve' attribute is found.
     while (reader.Read()){
       switch (reader.NodeType){
         case XmlNodeType.Element:
           Console.Write("<{0}>", reader.Name);
           if (reader.XmlSpace==XmlSpace.Preserve)
             reader.WhitespaceHandling=WhitespaceHandling.Significant;
           break;
         case XmlNodeType.Text:
           Console.Write(reader.Value);
           break;
         case XmlNodeType.EndElement:
           Console.Write("</{0}>", reader.Name);
           break;
         case XmlNodeType.SignificantWhitespace:
           Console.Write(reader.Value);
           break;         
       }              
     }
  }
}
//</snippet1>


