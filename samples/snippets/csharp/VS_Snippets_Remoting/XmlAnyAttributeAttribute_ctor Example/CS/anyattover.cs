//<Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class Group{
   public string GroupName;
   // The Things array will be used to collect all unknown
   // attributes found when deserializing.
   public XmlAttribute[]Things;
}

public class Test{
   static void Main(){
      Test t = new Test();
      t.DeserializeObject("UnknownAttributes.xml");
   }

   private void DeserializeObject(string filename){
      // Use the CreateOverrideSerializer to return an instance
      // of the XmlSerializer customized for overrides.
      XmlSerializer ser = CreateOverrideSerializer();
      // A FileStream is needed to read the XML document.
      FileStream fs = new FileStream(filename, FileMode.Open);
     Group g = (Group)
     	ser.Deserialize(fs);
     fs.Close();
     Console.WriteLine(g.GroupName);
     Console.WriteLine(g.Things.Length);
     foreach(XmlAttribute xAtt in g.Things){
        Console.WriteLine(xAtt.Name + ": " + xAtt.InnerXml);
        }
   }

   private XmlSerializer CreateOverrideSerializer(){
      // Override the Things field to capture all
      // unknown XML attributes.
      XmlAnyAttributeAttribute myAnyAttribute = 
      new XmlAnyAttributeAttribute();
      XmlAttributeOverrides xOverride = 
      new XmlAttributeOverrides();
      XmlAttributes xAtts = new XmlAttributes();
      xAtts.XmlAnyAttribute=myAnyAttribute;
      xOverride.Add(typeof(Group), "Things", xAtts);
       
      return new XmlSerializer(typeof(Group) , xOverride);
   }
}
 //</Snippet1>  

