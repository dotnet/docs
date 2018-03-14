//<Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Xml;
using System.Text;

namespace Company{

[SoapType("TheGroup", "http://www.cohowinery.com")]
public class Group
{
   public string GroupName;
   public Thing[] Things;
   [SoapElement(DataType = "language")]
   public string Lang = "en";
   [SoapElement(DataType = "integer")]
   public string MyNumber;

   [SoapElement(DataType = "duration")]
   public string ReDate = "8/31/01";
}

public class Thing{ 
   public string ThingName;
}

public class Test
{
   public static void Main()
   {
      Test t = new Test();

      t.GetMap("MyMap.xml");
   }


   public void GetMap(string filename){
      // Create an XmlSerializer instance.
      XmlTypeMapping map = new SoapReflectionImporter().ImportTypeMapping(typeof(Group));
      Console.WriteLine("ElementName: " + map.ElementName);
      Console.WriteLine("Namespace: " + map.Namespace);
      Console.WriteLine("TypeFullName: " + map.TypeFullName);
      Console.WriteLine("TypeName: " + map.TypeName);
      XmlSerializer ser = new XmlSerializer(map);
      Group xGroup=  new Group();
      xGroup.GroupName= "MyCar";
      xGroup.MyNumber= 5454.ToString();
      xGroup.Things = new Thing[]{new Thing(), new Thing()};
      // To write the outer wrapper, use an XmlTextWriter.
      XmlTextWriter writer = 
      new XmlTextWriter(filename, Encoding.UTF8);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartElement("wrapper");
      ser.Serialize(writer, xGroup);
      writer.WriteEndElement();
      writer.Close();
   }
}
}
//</Snippet1>
