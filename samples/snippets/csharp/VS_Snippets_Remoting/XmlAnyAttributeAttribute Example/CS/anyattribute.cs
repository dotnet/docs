//<Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class Group{
   public string GroupName;
   // The UnknownAttributes array will be used to collect all unknown
   // attributes found when deserializing.
   [XmlAnyAttribute]
    public XmlAttribute[]XAttributes;
}

public class Test{
   static void Main(){
      Test t = new Test();
      // Deserialize the file containing unknown attributes.

      t.DeserializeObject("UnknownAttributes.xml");
   }

   private void DeserializeObject(string filename){
      XmlSerializer ser = new XmlSerializer(typeof(Group));
      // A FileStream is needed to read the XML document.
     FileStream fs = new FileStream(filename, FileMode.Open);
     Group g = (Group) ser.Deserialize(fs);
     fs.Close();
     // Write out the data, including unknown attributes.
     Console.WriteLine(g.GroupName);
     Console.WriteLine("Number of unknown attributes: " + 
     g.XAttributes.Length);
     foreach(XmlAttribute xAtt in g.XAttributes){
     Console.WriteLine(xAtt.Name + ": " + xAtt.InnerXml);
     }
     // Serialize the object again with the attributes added.
     this.SerializeObject("AttributesAdded.xml",g);
   }

   private void SerializeObject(string filename, object g){
      XmlSerializer ser = new XmlSerializer(typeof(Group));
      TextWriter writer = new StreamWriter(filename);
      ser.Serialize(writer, g);
      writer.Close();
   }
}
 //</Snippet1>  

