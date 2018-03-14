// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

// This is the class that will be deserialized.
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
 
public class Test
{
   public static void Main()
   {
      Test t = new Test();
      // Read a purchase order.
      t.DeserializeObject("simple.xml");
   }

   private void DeserializeObject(string filename)
   {   
      Console.WriteLine("Reading with Stream");
      // Create an instance of the XmlSerializer.
      XmlSerializer serializer = 
      new XmlSerializer(typeof(OrderedItem));
          
      // Declare an object variable of the type to be deserialized.
      OrderedItem i;

      using (Stream reader = new FileStream(filename, FileMode.Open))
      {
          // Call the Deserialize method to restore the object's state.
          i = (OrderedItem)serializer.Deserialize(reader);          
      }

      // Write out the properties of the object.
      Console.Write(
      i.ItemName + "\t" +
      i.Description + "\t" +
      i.UnitPrice + "\t" +
      i.Quantity + "\t" +
      i.LineTotal);
   }
}

// </Snippet1>
