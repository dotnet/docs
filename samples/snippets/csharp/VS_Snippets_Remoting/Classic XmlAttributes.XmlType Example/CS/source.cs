// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

public class Transportation
{
   public Car[] Cars;
}

public class Car
{
   public int ID;
}

public class Test
{
   public static void Main()
   {
      Test t = new Test();
      t.SerializeObject("XmlType.xml");
   }

   // Return an XmlSerializer used for overriding.
   public XmlSerializer CreateOverrider()
   {
      // Create the XmlAttributes and XmlAttributeOverrides objects.
      XmlAttributes attrs = new XmlAttributes();
      XmlAttributeOverrides xOver = new XmlAttributeOverrides();
      
      /* Create an XmlTypeAttribute and change the name of the 
         XML type. */
      XmlTypeAttribute xType = new XmlTypeAttribute();
      xType.TypeName = "Autos";

      // Set the XmlTypeAttribute to the XmlType property.
      attrs.XmlType = xType;

      /* Add the XmlAttributes to the XmlAttributeOverrides,
         specifying the member to override. */
      xOver.Add(typeof(Car), attrs);

      // Create the XmlSerializer, and return it.
      XmlSerializer xSer = new XmlSerializer
      (typeof(Transportation), xOver);
      return xSer;
   }

   public void SerializeObject(string filename)
   {
      // Create an XmlSerializer instance.
      XmlSerializer xSer = CreateOverrider();

      // Create object and serialize it.
      Transportation myTransportation = 
      new Transportation();

      Car c1 = new Car();
      c1.ID = 12;

      Car c2 = new Car();
      c2.ID = 44;

      myTransportation.Cars = new Car[2]{c1,c2};

      // To write the file, a TextWriter is required.
      TextWriter writer = new StreamWriter(filename);
      xSer.Serialize(writer, myTransportation);
   }
}

// </Snippet1>
