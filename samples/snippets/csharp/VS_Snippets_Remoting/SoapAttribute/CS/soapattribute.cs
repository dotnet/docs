//<Snippet1>
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

[SoapInclude(typeof(Vehicle))]
public class Group
{
   [SoapAttribute (Namespace = "http://www.cpandl.com")]
   public string GroupName;
   
   [SoapAttribute(DataType = "base64Binary")]
   public Byte [] GroupNumber;

   [SoapAttribute(DataType = "date", AttributeName = "CreationDate")]
   public DateTime Today;
   [SoapElement(DataType = "nonNegativeInteger", ElementName = "PosInt")]
   public string PostitiveInt;

   public Vehicle GroupVehicle;
}
  
public class Vehicle
{
   public string licenseNumber;
}

public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("SoapAtts.xml");
      test.DeserializeObject("SoapAtts.xml");
   }
   public void SerializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class that
      // can generate encoded SOAP messages.
      XmlSerializer mySerializer =  ReturnSOAPSerializer();

      Group myGroup=MakeGroup();
      // Writing the file requires a TextWriter.
      XmlTextWriter writer = 
      new XmlTextWriter(filename, Encoding.UTF8);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartElement("wrapper");
      // Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup);
      writer.WriteEndElement();
      writer.Close();
   }

   private Group MakeGroup(){
      // Create an instance of the class that will be serialized.
      Group myGroup = new Group();

      // Set the object properties.
      myGroup.GroupName = ".NET";

      Byte [] hexByte = new Byte[2]{Convert.ToByte(100),
      Convert.ToByte(50)};
      myGroup.GroupNumber = hexByte;

      DateTime myDate = new DateTime(2002,5,2);
      myGroup.Today = myDate;
      myGroup.PostitiveInt= "10000";
      myGroup.GroupVehicle = new Vehicle();
      myGroup.GroupVehicle.licenseNumber="1234";
      return myGroup;
   }   	

   public void DeserializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class that
      // can generate encoded SOAP messages.
      XmlSerializer mySerializer =  ReturnSOAPSerializer();

      // Reading the file requires an  XmlTextReader.
      XmlTextReader reader= 
      new XmlTextReader(filename);
      reader.ReadStartElement("wrapper");

      // Deserialize and cast the object.
      Group myGroup; 
      myGroup = (Group) mySerializer.Deserialize(reader);
      reader.ReadEndElement();
      reader.Close();

   }
   
   private XmlSerializer ReturnSOAPSerializer(){
      // Create an instance of the XmlSerializer class.
      XmlTypeMapping myMapping = 
      (new SoapReflectionImporter().ImportTypeMapping
      (typeof(Group)));
       return new XmlSerializer(myMapping);
   }
}
//</Snippet1>

 
