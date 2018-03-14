//<snippet1>
using System;
using System.Xml;

public class Sample{

  public static void Main(){
     XmlTextWriter writer = new XmlTextWriter ("out.xml", null);
     string tag = "item name";
   
  try{
	
     // Write the root element.
     writer.WriteStartElement("root");

     writer.WriteStartElement(XmlConvert.VerifyName(tag));
             
     }
     catch (XmlException e){
        Console.WriteLine(e.Message);
        Console.WriteLine("Convert to a valid name...");
        writer.WriteStartElement(XmlConvert.EncodeName(tag));
     }

     writer.WriteString("hammer");
     writer.WriteEndElement();

     // Write the end tag for the root element.
     writer.WriteEndElement();
 
     writer.Close();
 
  }

}
//</snippet1>