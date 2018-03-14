

// <Snippet1>
#using <System.dll>
#using <System.xml.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::IO;
using namespace System::Xml::Schema;
public ref class Item
{
public:
   String^ ItemID;
   Item(){}

   Item( String^ id )
   {
      ItemID = id;
   }
};

public ref class NewItem: public Item
{
public:
   String^ Category;
   NewItem(){}

   NewItem( String^ id, String^ cat )
   {
      ItemID = id;
      Category = cat;
   }
};

public ref class PurchaseOrder
{
public:

   [XmlArrayItem(DataType="gMonth",
   ElementName="MyMonths",
   Namespace="http://www.cohowinery.com")]
   array<String^>^Months;

   [XmlArrayItem(Item::typeid),XmlArrayItem(NewItem::typeid)]
   array<Item^>^Items;

   [XmlArray(IsNullable=true)]
   [XmlArrayItem(String::typeid),
   XmlArrayItem(Double::typeid),
   XmlArrayItem(NewItem::typeid)]
   array<Object^>^Things;
};

void SerializeObject( String^ filename )
{
   // Create an instance of the XmlSerializer class;
   // specify the type of object to serialize.
   XmlSerializer^ serializer = gcnew XmlSerializer( PurchaseOrder::typeid );
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create a PurchaseOrder and set its properties.
   PurchaseOrder^ po = gcnew PurchaseOrder;
   array<String^>^months = {"March","May","August"};
   po->Months = months;
   array<Item^>^items = {gcnew Item( "a1" ),gcnew NewItem( "b1","book" )};
   po->Items = items;
   array<Object^>^things = {"String",2003.31,gcnew NewItem( "Item100","book" )};
   po->Things = things;

   // Serialize the purchase order, and close the TextWriter.
   serializer->Serialize( writer, po );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   // Create an instance of the XmlSerializer class;
   // specify the type of object to be deserialized.
   XmlSerializer^ serializer = gcnew XmlSerializer( PurchaseOrder::typeid );

   // A FileStream is needed to read the XML document.
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );

   // Declare an object variable of the type to be deserialized.
   PurchaseOrder^ po;

   /* Use the Deserialize method to restore the object's state with
      data from the XML document. */
   po = safe_cast<PurchaseOrder^>(serializer->Deserialize( fs ));
   for ( int i = 0; i < po->Months->Length; ++i )
      Console::WriteLine( po->Months[ i ] );
   for ( int i = 0; i < po->Items->Length; ++i )
      Console::WriteLine( po->Items[ i ]->ItemID );
   for ( int i = 0; i < po->Things->Length; ++i )
      Console::WriteLine( po->Things[ i ] );
}

int main()
{
   // Read and write purchase orders.
   SerializeObject(  "ArrayItemEx.xml" );
   DeserializeObject(  "ArrayItemEx.xml" );
}
// </Snippet1>
