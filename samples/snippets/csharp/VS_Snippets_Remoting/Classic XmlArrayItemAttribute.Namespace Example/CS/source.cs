using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// <Snippet1>
public class Transportation
{  
   // Sets the Namespace property.
   [XmlArrayItem(typeof(Car), Namespace = "http://www.cpandl.com")]
   public Vehicle[] MyVehicles;
}

// </Snippet1>

public class Vehicle {
    // Class added so sample will compile
}

public class Car : Vehicle {
    // Class added so sample will compile
}

