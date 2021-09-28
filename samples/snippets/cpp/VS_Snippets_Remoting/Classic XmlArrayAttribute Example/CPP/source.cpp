

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Xml;
public ref class Item
{
public:

   [XmlElement(ElementName="OrderItem")]
   String^ ItemName;
   String^ ItemCode;
   Decimal ItemPrice;
   int ItemQuantity;
};

public ref class BookItem: public Item
{
public:
   String^ Title;
   String^ Author;
   String^ ISBN;
};

// This is the class that will be serialized.
public ref class MyRootClass
{
private:
   array<Item^>^items;

public:

   /* Here is a simple way to serialize the array as XML. Using the
         XmlArrayAttribute, assign an element name and namespace. The
         IsNullable property determines whether the element will be 
         generated if the field is set to a null value. If set to true,
         the default, setting it to a null value will cause the XML
         xsi:null attribute to be generated. */

   [XmlArray(ElementName="MyStrings",
   Namespace="http://www.cpandl.com",IsNullable=true)]
   array<String^>^MyStringArray;

   /* Here is a more complex example of applying an 
         XmlArrayAttribute. The Items property can contain both Item 
         and BookItem objects. Use the XmlArrayItemAttribute to specify
         that both types can be inserted into the array. */
   [XmlArrayItem(ElementName="Item",
   IsNullable=true,
   Type=Item::typeid,
   Namespace="http://www.cpandl.com"),
   XmlArrayItem(ElementName="BookItem",
   IsNullable=true,
   Type=BookItem::typeid,
   Namespace="http://www.cohowinery.com")]
   [XmlArray]
   property array<Item^>^ Items 
   {
      array<Item^>^ get()
      {
         return items;
      }

      void set( array<Item^>^value )
      {
         items = value;
      }
   }
};

public ref class Run
{
public:
   void SerializeDocument( String^ filename )
   {
      // Creates a new XmlSerializer.
      XmlSerializer^ s = gcnew XmlSerializer( MyRootClass::typeid );

      // Writing the file requires a StreamWriter.
      TextWriter^ myWriter = gcnew StreamWriter( filename );

      // Creates an instance of the class to serialize. 
      MyRootClass^ myRootClass = gcnew MyRootClass;

      /* Uses a basic method of creating an XML array: Create and 
            populate a string array, and assign it to the 
            MyStringArray property. */
      array<String^>^myString = {"Hello","world","!"};
      myRootClass->MyStringArray = myString;

      /* Uses a more advanced method of creating an array:
               create instances of the Item and BookItem, where BookItem 
               is derived from Item. */
      Item^ item1 = gcnew Item;
      BookItem^ item2 = gcnew BookItem;

      // Sets the objects' properties.
      item1->ItemName = "Widget1";
      item1->ItemCode = "w1";
      item1->ItemPrice = 231;
      item1->ItemQuantity = 3;
      item2->ItemCode = "w2";
      item2->ItemPrice = 123;
      item2->ItemQuantity = 7;
      item2->ISBN = "34982333";
      item2->Title = "Book of Widgets";
      item2->Author = "John Smith";

      // Fills the array with the items.
      array<Item^>^myItems = {item1,item2};

      // Sets the class's Items property to the array.
      myRootClass->Items = myItems;

      /* Serializes the class, writes it to disk, and closes 
               the TextWriter. */
      s->Serialize( myWriter, myRootClass );
      myWriter->Close();
   }
};

int main()
{
   Run^ test = gcnew Run;
   test->SerializeDocument( "books.xml" );
}
// </Snippet1>
