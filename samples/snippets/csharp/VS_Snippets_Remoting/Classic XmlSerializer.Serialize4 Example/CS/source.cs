// <Snippet1>
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class OrderedItem
{
   public string ItemName;
   public string Description;
   public decimal UnitPrice;
   public int Quantity;
   public decimal LineTotal;
   // A custom method used to calculate price per item.
   public void Calculate()
   {
      LineTotal = UnitPrice * Quantity;
   }
}
 
public class Test{
   public static void Main()
   {
      Test t = new Test();
      // Write a purchase order.
      t.SerializeObject("simple.xml");
   }
 
   private void SerializeObject(string filename)
   {
      Console.WriteLine("Writing With XmlTextWriter");
 
      XmlSerializer serializer = 
      new XmlSerializer(typeof(OrderedItem));
      OrderedItem i = new OrderedItem();
      i.ItemName = "Widget";
      i.Description = "Regular Widget";
      i.Quantity = 10;
      i.UnitPrice = (decimal) 2.30;
      i.Calculate();
      // Create an XmlTextWriter using a FileStream.
      Stream fs = new FileStream(filename, FileMode.Create);
      XmlWriter writer = 
      new XmlTextWriter(fs, Encoding.Unicode);
      // Serialize using the XmlTextWriter.
      serializer.Serialize(writer, i);
      writer.Close();
   }
}
   
// </Snippet1>
