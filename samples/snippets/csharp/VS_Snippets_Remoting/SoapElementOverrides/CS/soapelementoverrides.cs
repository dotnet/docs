//<Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Xml;
using System.Text;
public class Transportation
{
   // The SoapElementAttribute specifies that the
   // generated XML element name will be "Wheels"
   // instead of "Vehicle".
   [SoapElement("Wheels")]
   public string Vehicle;
   [SoapElement(DataType = "dateTime")]
   public DateTime CreationDate;
   [SoapElement(IsNullable = true)]
   public Thing thing;
   
}

public class Thing{ 
   [SoapElement(IsNullable=true)] public string ThingName;
}

public class Test
{
   public static void Main()
   {
      Test t = new Test();
      t.SerializeObject("SoapElementOriginal.xml");
      t.SerializeOverride("SoapElementOverride.xml");
      Console.WriteLine("Finished writing two XML files.");
   }

   // Return an XmlSerializer used for overriding.
   public XmlSerializer CreateSoapOverrider()
   {
      // Create the SoapAttributes and SoapAttributeOverrides objects.
      SoapAttributes soapAttrs = new SoapAttributes();

      SoapAttributeOverrides soapOverrides = 
      new SoapAttributeOverrides();
            
      /* Create an SoapElementAttribute to override 
      the Vehicles property. */
      SoapElementAttribute soapElement1 = 
      new SoapElementAttribute("Truck");
      // Set the SoapElement to the object.
      soapAttrs.SoapElement= soapElement1;

      /* Add the SoapAttributes to the SoapAttributeOverrides,
      specifying the member to override. */
      soapOverrides.Add(typeof(Transportation), "Vehicle", soapAttrs);
      
      // Create the XmlSerializer, and return it.
      XmlTypeMapping myTypeMapping = (new SoapReflectionImporter
      (soapOverrides)).ImportTypeMapping(typeof(Transportation));
      return new XmlSerializer(myTypeMapping);
   }

   public void SerializeOverride(string filename)
   {
      // Create an XmlSerializer instance.
      XmlSerializer ser = CreateSoapOverrider();

      // Create the object and serialize it.
      Transportation myTransportation = 
      new Transportation();

      myTransportation.Vehicle = "MyCar";
      myTransportation.CreationDate=DateTime.Now;
      myTransportation.thing = new Thing();

      XmlTextWriter writer = 
      new XmlTextWriter(filename, Encoding.UTF8);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartElement("wrapper");
      ser.Serialize(writer, myTransportation);
      writer.WriteEndElement();
      writer.Close();
   }
   public void SerializeObject(string filename){
      // Create an XmlSerializer instance.
      XmlSerializer ser = new XmlSerializer(typeof(Transportation));
      Transportation myTransportation = 
      new Transportation();
      myTransportation.Vehicle = "MyCar";
      myTransportation.CreationDate = DateTime.Now;
      myTransportation.thing = new Thing();
      XmlTextWriter writer = 
      new XmlTextWriter(filename, Encoding.UTF8);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartElement("wrapper");
      ser.Serialize(writer, myTransportation);
      writer.WriteEndElement();
      writer.Close();
   }
}
//</Snippet1>
