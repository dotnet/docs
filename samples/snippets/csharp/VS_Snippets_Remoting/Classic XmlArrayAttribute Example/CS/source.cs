// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeDocument("books.xml");
   }
 
   public void SerializeDocument(string filename)
   {
      // Creates a new XmlSerializer.
      XmlSerializer s = 
      new XmlSerializer(typeof(MyRootClass));

      // Writing the file requires a StreamWriter.
      TextWriter myWriter= new StreamWriter(filename);

      // Creates an instance of the class to serialize. 
      MyRootClass myRootClass = new MyRootClass();

      /* Uses a basic method of creating an XML array: Create and 
      populate a string array, and assign it to the 
      MyStringArray property. */

      string [] myString = {"Hello", "world", "!"};
      myRootClass.MyStringArray = myString;
       
      /* Uses a more advanced method of creating an array:
         create instances of the Item and BookItem, where BookItem 
         is derived from Item. */
      Item item1 = new Item();
      BookItem item2 = new BookItem();
  
      // Sets the objects' properties.
      item1.ItemName = "Widget1";
      item1.ItemCode = "w1";
      item1.ItemPrice = 231;
      item1.ItemQuantity = 3;
 
      item2.ItemCode = "w2";
      item2.ItemPrice = 123;
      item2.ItemQuantity = 7;
      item2.ISBN = "34982333";
      item2.Title = "Book of Widgets";
      item2.Author = "John Smith";
       
      // Fills the array with the items.
      Item [] myItems = {item1,item2};
       
      // Sets the class's Items property to the array.
      myRootClass.Items = myItems;
 
      /* Serializes the class, writes it to disk, and closes 
         the TextWriter. */
      s.Serialize(myWriter, myRootClass);
      myWriter.Close();
   }
}

// This is the class that will be serialized.
public class MyRootClass
{
   private Item [] items;
 
   /* Here is a simple way to serialize the array as XML. Using the
      XmlArrayAttribute, assign an element name and namespace. The
      IsNullable property determines whether the element will be 
      generated if the field is set to a null value. If set to true,
      the default, setting it to a null value will cause the XML
      xsi:null attribute to be generated. */
   [XmlArray(ElementName = "MyStrings",
   Namespace = "http://www.cpandl.com", IsNullable = true)]
   public string[] MyStringArray;
  
   /* Here is a more complex example of applying an 
      XmlArrayAttribute. The Items property can contain both Item 
      and BookItem objects. Use the XmlArrayItemAttribute to specify
      that both types can be inserted into the array. */
   [XmlArrayItem(ElementName= "Item", 
   IsNullable=true,
   Type = typeof(Item),
   Namespace = "http://www.cpandl.com"),
   XmlArrayItem(ElementName = "BookItem", 
   IsNullable = true, 
   Type = typeof(BookItem),
   Namespace = "http://www.cohowinery.com")]
   [XmlArray]
   public Item []Items
   {
      get{return items;}
      set{items = value;}
   }
}
 
public class Item{
   [XmlElement(ElementName = "OrderItem")]
   public string ItemName;
   public string ItemCode;
   public decimal ItemPrice;
   public int ItemQuantity;
}
 
public class BookItem:Item
{
   public string Title;
   public string Author;
   public string ISBN;
}
   
// </Snippet1>
