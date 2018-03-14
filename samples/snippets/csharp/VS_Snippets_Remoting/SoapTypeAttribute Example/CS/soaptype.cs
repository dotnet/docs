//<Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// The SoapType is overridden when the
// SerializeOverride  method is called.
[SoapType("SoapGroupType", "http://www.cohowinery.com")]
public class Group
{
   public string GroupName;
   public Employee[] Employees;
}

[SoapType("EmployeeType")]
public class Employee
{
   public string Name;
}

public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeOriginal("SoapType.xml");
      test.SerializeOverride("SoapType2.xml");
      test.DeserializeObject("SoapType2.xml");
   }

   public void SerializeOriginal(string filename)
   {
      // Create an instance of the XmlSerializer class that
      // can be used for serializing as a SOAP message.
      XmlTypeMapping mapp = 
         (new SoapReflectionImporter()).ImportTypeMapping(typeof(Group));
      XmlSerializer mySerializer = new XmlSerializer(mapp);
      
      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create an XML text writer.
      XmlTextWriter xmlWriter = new XmlTextWriter(writer);
      xmlWriter.Formatting = Formatting.Indented;
      xmlWriter.Indentation = 2;

      // Create an instance of the class that will be serialized.
      Group myGroup = new Group();

      // Set the object properties.
      myGroup.GroupName = ".NET";
      Employee e1 = new Employee();
      e1.Name = "Pat";
      myGroup.Employees=new Employee[]{e1};

      // Write the root element.
      xmlWriter.WriteStartElement("root");

      // Serialize the class.
      mySerializer.Serialize(xmlWriter, myGroup);

      // Close the root tag.
      xmlWriter.WriteEndElement();

      // Close the XmlWriter.
      xmlWriter.Close();

      // Close the TextWriter.
      writer.Close();
   }


   public void SerializeOverride(string filename)
   {
      // Create an instance of the XmlSerializer class that
      // uses a SoapAttributeOverrides object.
      
      XmlSerializer mySerializer =  CreateOverrideSerializer();

      // Writing the file requires a TextWriter.
      TextWriter writer = new StreamWriter(filename);

      // Create an XML text writer.
      XmlTextWriter xmlWriter = new XmlTextWriter(writer);
      xmlWriter.Formatting = Formatting.Indented;
      xmlWriter.Indentation = 2;

      // Create an instance of the class that will be serialized.
      Group myGroup = new Group();

      // Set the object properties.
      myGroup.GroupName = ".NET";
      Employee e1 = new Employee();
      e1.Name = "Pat";
      myGroup.Employees=new Employee[]{e1};

      // Write the root element.
      xmlWriter.WriteStartElement("root");

      // Serialize the class.
      mySerializer.Serialize(xmlWriter, myGroup);

      // Close the root tag.
      xmlWriter.WriteEndElement();

      // Close the XmlWriter.
      xmlWriter.Close();

      // Close the TextWriter.
      writer.Close();
   }

   private XmlSerializer CreateOverrideSerializer()
   {
      // Create and return an XmlSerializer instance used to
      // override and create SOAP messages.
      SoapAttributeOverrides mySoapAttributeOverrides = 
          new SoapAttributeOverrides();
      SoapAttributes soapAtts = new SoapAttributes();

      // Override the SoapTypeAttribute.
      SoapTypeAttribute soapType = new SoapTypeAttribute();
      soapType.TypeName = "Team";
      soapType.IncludeInSchema = false;
      soapType.Namespace = "http://www.microsoft.com";
      soapAtts.SoapType = soapType;
      
      mySoapAttributeOverrides.Add(typeof(Group),soapAtts);

      // Create an XmlTypeMapping that is used to create an instance 
      // of the XmlSerializer. Then return the XmlSerializer object.
      XmlTypeMapping myMapping = (new SoapReflectionImporter(
      mySoapAttributeOverrides)).ImportTypeMapping(typeof(Group));
    
      XmlSerializer ser = new XmlSerializer(myMapping);
      return ser;
   }

   public void DeserializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer mySerializer =  CreateOverrideSerializer();

      // Reading the file requires a TextReader.
      TextReader reader = new StreamReader(filename);

      // Create an XML text reader.
      XmlTextReader xmlReader = new XmlTextReader(reader);
      xmlReader.ReadStartElement();

      // Deserialize and cast the object.
      Group myGroup = (Group) mySerializer.Deserialize(xmlReader);
      xmlReader.ReadEndElement();
      Console.WriteLine("The GroupName is " + myGroup.GroupName);
      Console.WriteLine("Look at the SoapType.xml and SoapType2.xml " +
        "files for the generated XML.");

      // Close the readers.
      xmlReader.Close();
      reader.Close();
   }
}
//</Snippet1>
