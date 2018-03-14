// <Snippet1>

using System;
using System.IO;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class OrderedItem {
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
    public void Calculate() {
        LineTotal = UnitPrice * Quantity;
    }
}
 
public class Test {
    
   public static void Main() {
        Test t = new Test();
        // Write a purchase order.
        t.SerializeObject("simple.xml");
        t.DeserializeObject("simple.xml");
   }
 
   private void SerializeObject(string filename) {
        Console.WriteLine("Writing With Stream");
 
        XmlSerializer serializer = 
            new XmlSerializer(typeof(OrderedItem));

        OrderedItem i = new OrderedItem();
        i.ItemName = "Widget";
        i.Description = "Regular Widget";
        i.Quantity = 10;
        i.UnitPrice = (decimal) 2.30;
        i.Calculate();
 
        // Create an XmlSerializerNamespaces object.
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

        // Add two prefix-namespace pairs.
        ns.Add("inventory", "http://www.cpandl.com");
        ns.Add("money", "http://www.cohowinery.com");

        // Create a FileStream to write with.
        Stream writer = new FileStream(filename, FileMode.Create);

        // Serialize the object, and close the TextWriter
        serializer.Serialize(writer, i, ns);
        writer.Close();
    }
 
    private void DeserializeObject(string filename) {
        Console.WriteLine("Reading with Stream");
        // Create an instance of the XmlSerializer.
        XmlSerializer serializer = new XmlSerializer(typeof(OrderedItem));

        // Writing the file requires a Stream.
        Stream reader= new FileStream(filename,FileMode.Open);
          
        // Declare an object variable of the type to be deserialized.
        OrderedItem i;

        /* Use the Deserialize method to restore the object's state 
           using data from the XML document. */
        i = (OrderedItem) serializer.Deserialize(reader);

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
