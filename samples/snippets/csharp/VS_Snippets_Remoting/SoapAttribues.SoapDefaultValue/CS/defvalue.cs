//<Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.ComponentModel;

public class Group
{
   // The default is set to .NET.
   [DefaultValue(".NET")]
   public string GroupName;
}
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeOriginal("SoapOriginal.xml");
      test.SerializeOverride("mySoapAttributeOverridesideAttributes.xml");
      test.DeserializeOriginal("SoapOriginal.xml");
      test.DeserializeOverride("mySoapAttributeOverridesideAttributes.xml");
   }
   public void SerializeOriginal(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer mySerializer =  
      new XmlSerializer(typeof(Group));

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create an instance of the class that will be serialized.
      Group myGroup = new Group();

      // Setting the GroupName to '.NET' is like not setting it at all
      // because it is the default value. So no value will be 
      // serialized, and on deserialization it will appear as a blank.
      myGroup.GroupName = ".NET";

      // Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup);
      writer.Close();
   }

   public void SerializeOverride(string filename)
   {
      // Create an instance of the XmlSerializer class
      // that overrides the serialization.
      XmlSerializer overRideSerializer = CreateOverrideSerializer();

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create an instance of the class that will be serialized.
      Group myGroup = new Group();

      // The override specifies that the default value is now 
      // 'Team1'. So setting the GroupName to '.NET' means
      // the value will be serialized.
      myGroup.GroupName = ".NET";
      // Serialize the class, and close the TextWriter.
      overRideSerializer.Serialize(writer, myGroup);
       writer.Close();

   }


   public void DeserializeOriginal(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer mySerializer= new XmlSerializer(typeof(Group));
      // Reading the file requires a TextReader.
      TextReader reader = new StreamReader(filename);

      // Deserialize and cast the object.
      Group myGroup; 
      myGroup = (Group) mySerializer.Deserialize(reader);

      Console.WriteLine(myGroup.GroupName);
      Console.WriteLine();
   }

   public void DeserializeOverride(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer overRideSerializer = CreateOverrideSerializer();
      // Reading the file requires a TextReader.
      TextReader reader = new StreamReader(filename);

      // Deserialize and cast the object.
      Group myGroup; 
      myGroup = (Group) overRideSerializer.Deserialize(reader);

      Console.WriteLine(myGroup.GroupName);

   }

   private XmlSerializer CreateOverrideSerializer()
   {
      SoapAttributeOverrides mySoapAttributeOverrides = 
      new SoapAttributeOverrides();
      SoapAttributes soapAtts = new SoapAttributes();
      // Create a new DefaultValueAttribute object for the GroupName
      // property.
      DefaultValueAttribute newDefault = 
      new DefaultValueAttribute("Team1");
      soapAtts.SoapDefaultValue = newDefault;

      mySoapAttributeOverrides.Add(typeof(Group), "GroupName", 
      soapAtts);
      
      // Create an XmlTypeMapping that is used to create an instance 
      // of the XmlSerializer. Then return the XmlSerializer object.
      XmlTypeMapping myMapping = (new SoapReflectionImporter(
      mySoapAttributeOverrides)).ImportTypeMapping(typeof(Group));
	
      XmlSerializer ser = new XmlSerializer(myMapping);
      return ser;
   }

}
//</Snippet1>

 
