//<Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

public class Group{
   public string GroupName;
}

public class Test{
   static void Main(){
      Test t = new Test();
      // Deserialize the file containing unknown elements.
      t.DeserializeObject("UnknownElements.xml");
   }
   private void Serializer_UnknownElement(object sender, XmlElementEventArgs e){
      Console.WriteLine("Unknown Element");
      Console.WriteLine("\t" + e.Element.Name + " " + e.Element.InnerXml);
      Console.WriteLine("\t LineNumber: " + e.LineNumber);
      Console.WriteLine("\t LinePosition: " + e.LinePosition);
      
      Group x  = (Group) e.ObjectBeingDeserialized;
      Console.WriteLine (x.GroupName);
      Console.WriteLine (sender.ToString());
   }
   private void DeserializeObject(string filename){
      XmlSerializer ser = new XmlSerializer(typeof(Group));
      // Add a delegate to handle unknown element events.
      ser.UnknownElement+=new XmlElementEventHandler(Serializer_UnknownElement);
      // A FileStream is needed to read the XML document.
     FileStream fs = new FileStream(filename, FileMode.Open);
     Group g = (Group) ser.Deserialize(fs);
     fs.Close();
   	}
}
 //</Snippet1>  




