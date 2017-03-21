public class Transportation
{  
   // Sets the Namespace property.
   [XmlArrayItem(typeof(Car), Namespace = "http://www.cpandl.com")]
   public Vehicle[] MyVehicles;
}
