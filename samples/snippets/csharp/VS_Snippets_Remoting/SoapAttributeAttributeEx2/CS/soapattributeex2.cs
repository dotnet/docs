//<Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


public class Group
{
   // This attribute will be overridden.
   [SoapAttribute (Namespace = "http://www.cpandl.com")]
   public string GroupName;
   
}

public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeOverride("SoapOveride.xml");
     
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


   private XmlSerializer CreateOverrideSerializer(){
   	
      SoapAttributeOverrides mySoapAttributeOverrides = 
		new SoapAttributeOverrides();
      SoapAttributes mySoapAttributes = new SoapAttributes();
      // Create a new SoapAttributeAttribute to override the 
      // one applied to the Group class. The resulting XML 
      // stream will use the new namespace and attribute name.
      SoapAttributeAttribute mySoapAttribute = 
      new SoapAttributeAttribute();
      mySoapAttribute.AttributeName = "TeamName";
      // Change the Namespace.
      mySoapAttribute.Namespace = "http://www.cohowinery.com";

      mySoapAttributes.SoapAttribute = mySoapAttribute;
      mySoapAttributeOverrides.
      Add(typeof(Group), "GroupName" ,mySoapAttributes);
	
      XmlTypeMapping myMapping = (new SoapReflectionImporter
        (mySoapAttributeOverrides)).ImportTypeMapping(typeof(Group));
	
      XmlSerializer ser = new XmlSerializer(myMapping);
      return ser;
   }

}
//<?xml version="1.0" encoding="utf-8" ?> 
// <Group xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
//xmlns:xsd="http://www.w3.org/2001/XMLSchema" n1:TeamName=".NET" 
//xmlns:n1="http://www.cohowinery" /> 
//</Snippet1>




