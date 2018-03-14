// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class OrderedItem
{
   [XmlElement(Namespace = "http://www.cpandl.com")]
   public string ItemName;
   [XmlElement(Namespace = "http://www.cpandl.com")]
   public string Description;
   [XmlElement(Namespace="http://www.cohowinery.com")]
   public decimal UnitPrice;
   [XmlElement(Namespace = "http://www.cpandl.com")]
   public int Quantity;
   [XmlElement(Namespace="http://www.cohowinery.com")]
   public decimal LineTotal;
   // A custom method used to calculate price per item.
   public void Calculate()
   {
      LineTotal = UnitPrice * Quantity;
   }
}
 
public class Test{
   public static void Main(string[] args)
   {
      Test t = new Test();
      // Write a purchase order.
      t.SerializeObject("simple.xml");
   }
 
   private void SerializeObject(string filename)
   {
      Console.WriteLine("Writing With TextWriter");
      // Create an XmlSerializer instance using the type.
      XmlSerializer serializer = 
      new XmlSerializer(typeof(OrderedItem));
      OrderedItem i = new OrderedItem();
      i.ItemName = "Widget";
      i.Description = "Regular Widget";
      i.Quantity = 10;
      i.UnitPrice = (decimal) 2.30;
      i.Calculate();
 
      // Create an XmlSerializerNamespaces object.
      XmlSerializerNamespaces ns = 
      new XmlSerializerNamespaces();
      // Add two namespaces with prefixes.
      ns.Add("inventory", "http://www.cpandl.com");
      ns.Add("money", "http://www.cohowinery.com");
      // Create a StreamWriter to write with.
      TextWriter writer = new StreamWriter(filename);
      /* Serialize using the object using the TextWriter 
      and namespaces. */
      serializer.Serialize(writer, i, ns);
      writer.Close();
   }
}

// </Snippet1>
