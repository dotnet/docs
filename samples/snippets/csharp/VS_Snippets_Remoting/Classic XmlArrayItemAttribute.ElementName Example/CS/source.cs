using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class Transportation
{  
   [XmlArray("Vehicles")]
   /* Specifies acceptable types and the ElementName generated 
      for each object type. */
   [XmlArrayItem(typeof(Vehicle), ElementName = "Transport"), 
   XmlArrayItem(typeof(Car), ElementName = "Automobile")]
   public Vehicle[] MyVehicles;
}

// By default, this class results in XML elements named "Vehicle". 
public class Vehicle
{
   public string id;
}

// By default, this class results in XML elements named "Car". 
public class Car:Vehicle
{
   public string Maker;
}

// </Snippet1>

