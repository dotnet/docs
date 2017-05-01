//<Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// The name of this type will be overridden using
// the SoapTypeAttribute.
public class Group
{
   public string GroupName;
}
  
public class Run
{
   public static void Main()
   {
      Run test = new Run();

      test.SerializeOverride("GetSoapAttributes2.xml");
      
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

      // Set the object properties.
      myGroup.GroupName = ".NET";

      // Serialize the class, and close the TextWriter.
      overRideSerializer.Serialize(writer, myGroup);
       writer.Close();
   }

   private XmlSerializer CreateOverrideSerializer()
   {
      SoapAttributeOverrides mySoapAttributeOverrides = 
      new SoapAttributeOverrides();
      SoapAttributes mySoapAttributes = new SoapAttributes();

      SoapTypeAttribute mySoapType = new SoapTypeAttribute();
      mySoapType.TypeName= "Team";
      mySoapAttributes.SoapType = mySoapType;
      // Add the SoapAttributes to the 
      // mySoapAttributeOverridesrides object.
      mySoapAttributeOverrides.Add(typeof(Group), mySoapAttributes);
      // Get the SoapAttributes with the Item property.
      SoapAttributes thisSoapAtts = 
      mySoapAttributeOverrides[typeof(Group)];
      Console.WriteLine("New serialized type name: " + 
      thisSoapAtts.SoapType.TypeName);

      // Create an XmlTypeMapping that is used to create an instance 
      // of the XmlSerializer. Then return the XmlSerializer object.
      XmlTypeMapping myMapping = (new SoapReflectionImporter(
      mySoapAttributeOverrides)).ImportTypeMapping(typeof(Group));
	
      XmlSerializer ser = new XmlSerializer(myMapping);
      return ser;
   }

}
//</Snippet1>

 


