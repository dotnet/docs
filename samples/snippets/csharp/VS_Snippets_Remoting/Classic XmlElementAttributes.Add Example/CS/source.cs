using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Sample
{
// <Snippet1>
public XmlSerializer CreateOverrider()
{
   // Create XmlAttributes and XmlAttributeOverrides instances.
   
   XmlAttributes attrs = new XmlAttributes();
   XmlAttributeOverrides xOver = 
   new XmlAttributeOverrides();
      
   /* Create an XmlElementAttributes to override 
      the Vehicles property. */
   XmlElementAttribute xElement1 = 
   new XmlElementAttribute(typeof(Truck));
   // Add the XmlElementAttribute to the collection.
   attrs.XmlElements.Add(xElement1);

   /* Create a second XmlElementAttribute, and 
      add to the collection. */
   XmlElementAttribute xElement2 = 
   new XmlElementAttribute(typeof(Train));
   attrs.XmlElements.Add(xElement2);

   /* Add the XmlAttributes to the XmlAttributeOverrides,
      specifying the member to override. */
   xOver.Add(typeof(Transportation), "Vehicles", attrs);
      
   // Create the XmlSerializer, and return it.
   XmlSerializer xSer = new XmlSerializer
   (typeof(Transportation), xOver);
   return xSer;
}

// </Snippet1>
}

public class Truck {
    // Class added so sample will compile
}

public class Train {
    // Class added so sample will compile
}

public class Transportation {
    // Class added so sample will compile
}

