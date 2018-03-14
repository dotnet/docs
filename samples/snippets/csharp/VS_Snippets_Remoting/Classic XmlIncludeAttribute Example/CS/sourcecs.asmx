<!--<Snippet1>-->
<%@ WebService Language="C#" Class="Test" %>
 
using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Data;
 
public class Test : WebService {
   [WebMethod()]
   [return:XmlElement("MyTime", DataType="time")]
   public DateTime EchoString([XmlElement(DataType="string")] 
   string strval) {
        return DateTime.Now;
   }
 
   [WebMethod()]
   [XmlInclude(typeof(Car)), XmlInclude(typeof(Bike))]
   public Vehicle Vehicle(string licenseNumber) {
      if (licenseNumber == "0") {
         Vehicle v = new Car();
         v.licenseNumber = licenseNumber;
         return v;
      }
      else if (licenseNumber == "1") {
          Vehicle v = new Bike();
          v.licenseNumber = licenseNumber;
          return v;
      }
      else {
         return null;
      }
   }
}
[XmlRoot("NewVehicle")] 
public abstract class Vehicle {
    public string licenseNumber;
    public DateTime make;
}
 
public class Car : Vehicle {
}
 
public class Bike : Vehicle {
}
   
// </Snippet1>
