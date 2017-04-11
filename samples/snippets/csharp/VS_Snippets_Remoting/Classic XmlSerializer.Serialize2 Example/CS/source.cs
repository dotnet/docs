// <Snippet1>
using System;
using System.IO;
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
   public static void Main(string[] args)
   {
      Test t = new Test();
      // Write a purchase order.
      t.SerializeObject("simple.xml");
   }
 
   private void SerializeObject(string filename)
   {
      Console.WriteLine("Writing With Stream");
 
      XmlSerializer serializer = 
      new XmlSerializer(typeof(OrderedItem));
      OrderedItem i = new OrderedItem();
      i.ItemName = "Widget";
      i.Description = "Regular Widget";
      i.Quantity = 10;
      i.UnitPrice = (decimal) 2.30;
      i.Calculate();
 
      // Create a FileStream to write with.
      Stream writer = new FileStream(filename, FileMode.Create);
      // Serialize the object, and close the TextWriter
      serializer.Serialize(writer, i);
      writer.Close();
   }
}

// </Snippet1>
