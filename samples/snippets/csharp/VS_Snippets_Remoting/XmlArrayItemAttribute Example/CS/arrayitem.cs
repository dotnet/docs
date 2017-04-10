// <Snippet1>
using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Schema;
public class PurchaseOrder
{
   [XmlArrayItem(DataType = "gMonth", 
   ElementName="MyMonths",
   Namespace = "http://www.cohowinery.com")]
   public string[] Months;

   [XmlArrayItem(typeof(Item)), XmlArrayItem(typeof(NewItem))]
   public Item[] Items;

   [XmlArray(IsNullable = true)]
   [XmlArrayItem(typeof(string)), 
   XmlArrayItem(typeof(double)), 
   XmlArrayItem(typeof(NewItem))]
   public object[] Things;
   }

public class Item{
   public string ItemID;
   public Item(){}
   public Item(string id){
   	ItemID = id;
   }
}
public class NewItem:Item{
   public string Category;
   public NewItem(){}
   public NewItem(string id, string cat){
   	this.ItemID = id;
   	Category = cat;
   	}
}
 
public class Test
{
   public static void Main()
   {
      // Read and write purchase orders.
      Test t = new Test();
      t.SerializeObject("ArrayItemEx.xml");
      t.DeserializeObject("ArrayItemEx.xml");
   } 

   private void SerializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class;
      // specify the type of object to serialize.
      XmlSerializer serializer = 
      new XmlSerializer(typeof(PurchaseOrder));
      TextWriter writer = new StreamWriter(filename);
      // Create a PurchaseOrder and set its properties.
      PurchaseOrder po=new PurchaseOrder();
      po.Months = new string[]{ "March", "May", "August"};
      po.Items= new Item[]{new Item("a1"), new NewItem("b1", "book")};
      po.Things= new object[] {"String", 2003.31, new NewItem("Item100", "book")};
      
      // Serialize the purchase order, and close the TextWriter.
      serializer.Serialize(writer, po);
      writer.Close();
   }
 
   protected void DeserializeObject(string filename)
   {
      // Create an instance of the XmlSerializer class;
      // specify the type of object to be deserialized.
      XmlSerializer serializer = new XmlSerializer(typeof(PurchaseOrder));
   
      // A FileStream is needed to read the XML document.
      FileStream fs = new FileStream(filename, FileMode.Open);
      // Declare an object variable of the type to be deserialized.
      PurchaseOrder po;
      /* Use the Deserialize method to restore the object's state with
      data from the XML document. */
      po = (PurchaseOrder) serializer.Deserialize(fs);
      foreach(string s in po.Months)
      	  Console.WriteLine(s);
      foreach(Item i in po.Items)
         Console.WriteLine(i.ItemID);
      foreach(object thing in po.Things)
         Console.WriteLine(thing); 
   } 
}

// </Snippet1>

