//<Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Group{
   public string GroupName;
   public GroupType Grouptype;
}

public enum GroupType{
   // Use the SoapEnumAttribute to instruct the XmlSerializer
   // to generate Small and Large instead of A and B.
   [SoapEnum("Small")]
   A,
   [SoapEnum("Large")]
   B
}
 
public class Run {
   static void Main(){
      Run test= new Run();
      test.SerializeObject("SoapEnum.xml");
      test.SerializeOverride("SoapOverride.xml");
      Console.WriteLine("Fininished writing two files");
   }

     private void SerializeObject(string filename){
      // Create an instance of the XmlSerializer Class.
      XmlTypeMapping mapp  =
      (new SoapReflectionImporter()).ImportTypeMapping(typeof(Group));
      XmlSerializer mySerializer =  new XmlSerializer(mapp);

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create an instance of the Class that will be serialized.
      Group myGroup = new Group();

      // Set the object properties.
      myGroup.GroupName = ".NET";
      myGroup.Grouptype= GroupType.A;

      // Serialize the Class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup);
       writer.Close();
   }

   private void SerializeOverride(string fileName){
      SoapAttributeOverrides soapOver = new SoapAttributeOverrides();
      SoapAttributes SoapAtts = new SoapAttributes();

      // Add a SoapEnumAttribute for the GroupType.A enumerator.       
      // Instead of 'A'  it will be "West".
      SoapEnumAttribute soapEnum = new SoapEnumAttribute("West");
      // Override the "A" enumerator.
      SoapAtts.SoapEnum = soapEnum;
      soapOver.Add(typeof(GroupType), "A", SoapAtts);

      // Add another SoapEnumAttribute for the GroupType.B enumerator.
      // Instead of //B// it will be "East".
      SoapAtts= new SoapAttributes();
      soapEnum = new SoapEnumAttribute();
      soapEnum.Name = "East";
      SoapAtts.SoapEnum = soapEnum;
      soapOver.Add(typeof(GroupType), "B", SoapAtts);

      // Create an XmlSerializer used for overriding.
      XmlTypeMapping map = 
      new SoapReflectionImporter(soapOver).
      ImportTypeMapping(typeof(Group));
      XmlSerializer ser = new XmlSerializer(map);
      Group myGroup = new Group();
      myGroup.GroupName = ".NET";
      myGroup.Grouptype = GroupType.B;
      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(fileName);
      ser.Serialize(writer, myGroup);
      writer.Close();
   	}
}
//</Snippet1>


