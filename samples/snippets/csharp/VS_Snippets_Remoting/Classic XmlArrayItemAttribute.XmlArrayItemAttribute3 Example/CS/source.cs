// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
 
public class Vehicle
{
   public string id;
}
public class Car:Vehicle
{
   public string Maker;
}
 
public class Transportation
{  
   [XmlArray]
   [XmlArrayItem("Transport", typeof(Vehicle)), 
   XmlArrayItem("Automobile", typeof(Car))]
   public Vehicle[] MyVehicles;
}
 
public class Run
{
   public static void Main()
   {
      Run test= new Run();
      test.SerializeObject("XmlArrayItem4.xml");
      test.DeserializeObject("XmlArrayItem4.xml");
   }
 
   private void SerializeObject(string filename)
   {
       // Creates an XmlSerializer for the Transportation class.
      XmlSerializer MySerializer = 
      new XmlSerializer(typeof(Transportation));

      // Writing the XML file to disk requires a TextWriter.
      TextWriter myTextWriter = new StreamWriter(filename);
 
      Transportation myTransportation = new Transportation();

      Vehicle myVehicle= new Vehicle() ;
      myVehicle.id = "A12345";

      Car myCar = new Car();
      myCar.id = "Car 34";
      myCar.Maker = "FamousCarMaker";
       
      Vehicle [] myVehicles = {myVehicle, myCar};
      myTransportation.MyVehicles = myVehicles;

      // Serializes the object, and closes the StreamWriter.
      MySerializer.Serialize(myTextWriter, myTransportation);
      myTextWriter.Close();
   }
 
   private void DeserializeObject(string filename)
   {
      // Creates an XmlSerializer.
      XmlSerializer mySerializer = 
      new XmlSerializer(typeof(Transportation));
      FileStream myFileStream = new FileStream(filename,FileMode.Open);
      Transportation myTransportation =
      (Transportation) mySerializer.Deserialize(myFileStream);
 
      for(int i = 0;i < myTransportation.MyVehicles.Length;i++)
      {
         Console.WriteLine(myTransportation.MyVehicles[i].id);
      }
   }
}
   
// </Snippet1>
