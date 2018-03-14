using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// <Snippet1>
public class Transportation
{  
   [XmlArray("Vehicles")]
   // Specifies the Form property value.
   [XmlArrayItem(typeof(Vehicle), 
   Form = XmlSchemaForm.Unqualified), 
   XmlArrayItem(typeof(Car), 
   Form = XmlSchemaForm.Qualified)]
   public Vehicle[] MyVehicles;
}

public class Vehicle
{
   public string id;
}

public class Car:Vehicle
{
   public string Maker;
}

// </Snippet1>

