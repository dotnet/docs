//<Snippet1>
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

// You must use the SoapIncludeAttribute to inform the XmlSerializer
// that the Vehicle type should be recognized when deserializing.
[SoapInclude(typeof(Vehicle))]
public class Group
{
   public string GroupName;
   public Vehicle GroupVehicle;
}
 [SoapInclude(typeof(Vehicle))]
public class Vehicle
{
   public string licenseNumber;
}

public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.DeserializeObject("UnrefObj.xml");
   }
   
   public void DeserializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class.
      XmlTypeMapping myMapping = 
      (new SoapReflectionImporter().ImportTypeMapping(
      typeof(Group)));
      XmlSerializer mySerializer =  
      new XmlSerializer(myMapping);
 
      mySerializer.UnreferencedObject += 
      new UnreferencedObjectEventHandler
      (Serializer_UnreferencedObject);

      // Reading the file requires an  XmlTextReader.
      XmlTextReader reader= 
      new XmlTextReader(filename);
      reader.ReadStartElement();

      // Deserialize and cast the object.
      Group myGroup; 
      myGroup = (Group) mySerializer.Deserialize(reader);
      reader.ReadEndElement();
      reader.Close();
   }

   private void Serializer_UnreferencedObject
   (object sender, UnreferencedObjectEventArgs e){
      Console.WriteLine("UnreferencedObject:");
      Console.WriteLine("ID: " + e.UnreferencedId);
      Console.WriteLine("UnreferencedObject: " + e.UnreferencedObject);
      Vehicle myVehicle = (Vehicle) e.UnreferencedObject;
      Console.WriteLine("License: " + myVehicle.licenseNumber);
   }
}

// The file named "UnrefObj.xml" should contain this XML:

// <wrapper>

//  <Group xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
//xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="id1" 
//n1:GroupName=".NET" xmlns:n1="http://www.cpandl.com">
//   </Group>

//<Vehicle id="id2" n1:type="Vehicle" 
//xmlns:n1="http://www.w3.org/2001/XMLSchema-instance">
//   <licenseNumber xmlns:q1="http://www.w3.org/2001/XMLSchema" 
//n1:type="q1:string">ABCD</licenseNumber>
//   </Vehicle>

//<Vehicle id="id3" n1:type="Vehicle" 
//xmlns:n1="http://www.w3.org/2001/XMLSchema-instance">
//    <licenseNumber xmlns:q1="http://www.w3.org/2001/XMLSchema" 
//n1:type="q1:string">1234</licenseNumber>
//  </Vehicle>

//</wrapper>

//</Snippet1>