using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Sample
{
// <Snippet1>
private void SerializeObject(string filename)
{
   XmlSerializer serializer = 
   new XmlSerializer(typeof(OrderedItem));

   // Create an instance of the class to be serialized.
   OrderedItem i = new OrderedItem();

   // Set the public property values.
   i.ItemName = "Widget";
   i.Description = "Regular Widget";
   i.Quantity = 10;
   i.UnitPrice = (decimal) 2.30;

   // Writing the document requires a TextWriter.
   TextWriter writer = new StreamWriter(filename);

   // Serialize the object, and close the TextWriter.
   serializer.Serialize(writer, i);
   writer.Close();
}

// This is the class that will be serialized.
public class OrderedItem
{
   public string ItemName;
   public string Description;
   public decimal UnitPrice;
   public int Quantity;
}

// </Snippet1>
}
