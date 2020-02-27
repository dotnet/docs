// <Snippet1>
using System;
using System.Xml;

public class Sample {
 
  public static void Main() {
   
    XmlTextWriter writer = null;
     
      try {
    
        writer = new XmlTextWriter (Console.Out);
 
        // Write an element.
        writer.WriteStartElement("address");
     
        // Write an email address using entities
        // for the @ and . characters.
        writer.WriteString("someone");
        writer.WriteCharEntity('@');
        writer.WriteString("example");
        writer.WriteCharEntity('.');
        writer.WriteString("com");
        writer.WriteEndElement();
    }        
 
    finally {
      // Close the writer.
      if (writer != null)
        writer.Close();
    } 
  }
}
// </Snippet1>
