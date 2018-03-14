//<Snippet1>
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

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
   // This is ignored when serialized unless it's overridden.
   [SoapIgnore] 
   public bool IgnoreThis;
   
   public GroupType Grouptype;

   public Vehicle MyVehicle;

   // The SoapInclude allows the method to return a Car.
   [SoapInclude(typeof(Car))]
   public Vehicle myCar(string licNumber)
   {
      Vehicle v;
      if(licNumber == "")
         {
            v = new Car();
   	    v.licenseNumber = "!!!!!!";
   	 }
      else
   	 {
   	   v = new Car();
   	   v.licenseNumber = licNumber;
   	 }
      return v;
   }
}
  
// SoapInclude allows Vehicle to accept Car type.
[SoapInclude(typeof(Car))]
public abstract class Vehicle
{
   public string licenseNumber;
   public DateTime makeDate;
}

public class Car: Vehicle
{
}

public enum GroupType
{
   // These enums can be overridden.
   [SoapEnum("Small")]
   A,
   [SoapEnum("Large")]
   B
}
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeOriginal("SoapOriginal.xml");
      test.SerializeOverride("SoapOverrides.xml");
      test.DeserializeOriginal("SoapOriginal.xml");
      test.DeserializeOverride("SoapOverrides.xml");
   
   }
   public void SerializeOriginal(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlTypeMapping myMapping = 
      (new SoapReflectionImporter().ImportTypeMapping(
      typeof(Group)));
      XmlSerializer mySerializer =  
      new XmlSerializer(myMapping);
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

   public void SerializeOverride(string filename)
   {
      // Create an instance of the XmlSerializer class
      // that overrides the serialization.
      XmlSerializer overRideSerializer = CreateOverrideSerializer();
      Group myGroup=MakeGroup();
      // Writing the file requires a TextWriter.
      XmlTextWriter writer = 
      new XmlTextWriter(filename, Encoding.UTF8);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartElement("wrapper");
      // Serialize the class, and close the TextWriter.
      overRideSerializer.Serialize(writer, myGroup);
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
      myGroup.IgnoreThis=true;
      myGroup.Grouptype= GroupType.B;
      Car thisCar =(Car)  myGroup.myCar("1234566");
      myGroup.MyVehicle=thisCar;
      return myGroup;
   }   	

   public void DeserializeOriginal(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlTypeMapping myMapping = 
      (new SoapReflectionImporter().ImportTypeMapping(
      typeof(Group)));
      XmlSerializer mySerializer =  
      new XmlSerializer(myMapping);


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

   public void DeserializeOverride(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlSerializer overRideSerializer = CreateOverrideSerializer();

      // Reading the file requires an  XmlTextReader.
      XmlTextReader reader= 
      new XmlTextReader(filename);
      reader.ReadStartElement("wrapper");

      // Deserialize and cast the object.
      Group myGroup; 
      myGroup = (Group) overRideSerializer.Deserialize(reader);
      reader.ReadEndElement();
      reader.Close();
      ReadGroup(myGroup);
   }

   private void ReadGroup(Group myGroup){
      Console.WriteLine(myGroup.GroupName);
      Console.WriteLine(myGroup.GroupNumber[0]);
      Console.WriteLine(myGroup.GroupNumber[1]);
      Console.WriteLine(myGroup.Today);
      Console.WriteLine(myGroup.PostitiveInt);
      Console.WriteLine(myGroup.IgnoreThis);
      Console.WriteLine();
   }
   private XmlSerializer CreateOverrideSerializer()
   {
      SoapAttributeOverrides mySoapAttributeOverrides = 
      new SoapAttributeOverrides();
      SoapAttributes soapAtts = new SoapAttributes();

      SoapElementAttribute mySoapElement = new SoapElementAttribute();
      mySoapElement.ElementName = "xxxx";
      soapAtts.SoapElement = mySoapElement;
      mySoapAttributeOverrides.Add(typeof(Group), "PostitiveInt", 
      soapAtts);

      // Override the IgnoreThis property.
      SoapIgnoreAttribute myIgnore = new SoapIgnoreAttribute();
      soapAtts = new SoapAttributes();
      soapAtts.SoapIgnore = false;      
      mySoapAttributeOverrides.Add(typeof(Group), "IgnoreThis", 
      soapAtts);

      // Override the GroupType enumeration.	
      soapAtts = new SoapAttributes();
      SoapEnumAttribute xSoapEnum = new SoapEnumAttribute();
      xSoapEnum.Name = "Over1000";
      soapAtts.SoapEnum = xSoapEnum;

      // Add the SoapAttributes to the 
      // mySoapAttributeOverridesrides object.
      mySoapAttributeOverrides.Add(typeof(GroupType), "A", 
      soapAtts);

      // Create second enumeration and add it.
      soapAtts = new SoapAttributes();
      xSoapEnum = new SoapEnumAttribute();
      xSoapEnum.Name = "ZeroTo1000";
      soapAtts.SoapEnum = xSoapEnum;
      mySoapAttributeOverrides.Add(typeof(GroupType), "B", 
      soapAtts);

      // Override the Group type.
      soapAtts = new SoapAttributes();
      SoapTypeAttribute soapType = new SoapTypeAttribute();
      soapType.TypeName = "Team";
      soapAtts.SoapType = soapType;
      mySoapAttributeOverrides.Add(typeof(Group),soapAtts);

      // Create an XmlTypeMapping that is used to create an instance 
      // of the XmlSerializer. Then return the XmlSerializer object.
      XmlTypeMapping myMapping = (new SoapReflectionImporter(
      mySoapAttributeOverrides)).ImportTypeMapping(typeof(Group));
	
      XmlSerializer ser = new XmlSerializer(myMapping);
      return ser;
   }
}
//</Snippet1>

 
