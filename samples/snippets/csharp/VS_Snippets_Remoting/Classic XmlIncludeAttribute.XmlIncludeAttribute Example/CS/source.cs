using System;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class Vehicle{}
 
public class Car:Vehicle{}
 
public class Truck:Vehicle{}
 
public class Sample
{
[WebMethodAttribute]
[XmlInclude(typeof(Car))]
[XmlInclude(typeof(Truck))]
public Vehicle ReturnVehicle(int i){
   if(i == 0)
      return new Car();
   else
      return new Truck();
   }
}   
// </Snippet1>

