//<snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{

  public static void Main()
  {
     XmlTextWriter writer = new XmlTextWriter (Console.Out);
     //Use indenting for readability
     writer.Formatting = Formatting.Indented;
	
     //Write an XML fragment.
     writer.WriteStartElement("book");
     writer.WriteElementString("title", "Pride And Prejudice");
     writer.WriteEndElement();
     writer.Flush();

     //Write another XML fragment.
     writer.WriteStartElement("cd");
     writer.WriteElementString("title", "Americana");
     writer.WriteEndElement();
     writer.Flush();  

     //Close the writer.
     writer.Close();
  }
}
//</snippet1>