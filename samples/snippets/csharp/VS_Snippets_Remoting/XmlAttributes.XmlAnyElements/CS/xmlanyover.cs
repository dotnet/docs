//<Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class Group{
   public string GroupName;
   [XmlAnyElement]
   public object[]Things;

}

public class Test{
   static void Main(){
      Test t = new Test();
      // 1 Run this and create the XML document.
      // 2 Add new elements to the XML document.
      // 3 Comment out the new line, and uncomment
      // the DeserializeObject line to deserialize the
      // XML document and see unknown elements.
      t.SerializeObject("UnknownElements.xml");
     
      // t.DeserializeObject("UnknownElements.xml");
   }

   private void SerializeObject(string filename){
      XmlSerializer ser = new XmlSerializer(typeof (Group));
      TextWriter writer = new StreamWriter(filename);
      Group g = new Group();
      g.GroupName = "MyGroup";
      ser.Serialize(writer, g);
      writer.Close();
   }

   
   private void DeserializeObject(string filename){

      XmlSerializer ser = CreateOverrideSerializer();
      // A FileStream is needed to read the XML document.
      FileStream fs = new FileStream(filename, FileMode.Open);
     Group g = (Group)
     	ser.Deserialize(fs);
     fs.Close();
     Console.WriteLine(g.GroupName);
     Console.WriteLine(g.Things.Length);
     foreach(XmlElement xelement in g.Things){
     Console.WriteLine(xelement.Name + ": " + xelement.InnerXml);
     }
   }

   private XmlSerializer CreateOverrideSerializer(){
      XmlAnyElementAttribute myAnyElement = 
      new XmlAnyElementAttribute();
      XmlAttributeOverrides xOverride = 
      new XmlAttributeOverrides();
      XmlAttributes xAtts = new XmlAttributes();
      xAtts.XmlAnyElements.Add(myAnyElement);
      xOverride.Add(typeof(Group), "Things", xAtts);
      return new XmlSerializer(typeof(Group) , xOverride);
   }
}
 //</Snippet1>  
