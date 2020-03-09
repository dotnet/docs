

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

// This is the class that will be serialized.
public ref class OrderedItem
{
public:

   [XmlElement(Namespace="http://www.cpandl.com")]
   String^ ItemName;

   [XmlElement(Namespace="http://www.cpandl.com")]
   String^ Description;

   [XmlElement(Namespace="http://www.cohowinery.com")]
   Decimal UnitPrice;

   [XmlElement(Namespace="http://www.cpandl.com")]
   int Quantity;

   [XmlElement(Namespace="http://www.cohowinery.com")]
   Decimal LineTotal;

   // A custom method used to calculate price per item.
   void Calculate()
   {
      LineTotal = UnitPrice * Quantity;
   }
};

void SerializeObject( String^ filename )
{
   Console::WriteLine( "Writing With Stream" );
   XmlSerializer^ serializer = gcnew XmlSerializer( OrderedItem::typeid );
   OrderedItem^ i = gcnew OrderedItem;
   i->ItemName = "Widget";
   i->Description = "Regular Widget";
   i->Quantity = 10;
   i->UnitPrice = (Decimal)2.30;
   i->Calculate();

   // Create an XmlSerializerNamespaces object.
   XmlSerializerNamespaces^ ns = gcnew XmlSerializerNamespaces;

   // Add two prefix-namespace pairs.
   ns->Add( "inventory", "http://www.cpandl.com" );
   ns->Add( "money", "http://www.cohowinery.com" );

   // Create a FileStream to write with.
   Stream^ writer = gcnew FileStream( filename,FileMode::Create );

   // Serialize the object, and close the TextWriter
   serializer->Serialize( writer, i, ns );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   Console::WriteLine( "Reading with Stream" );

   // Create an instance of the XmlSerializer.
   XmlSerializer^ serializer = gcnew XmlSerializer( OrderedItem::typeid );

   // Writing the file requires a Stream.
   Stream^ reader = gcnew FileStream( filename,FileMode::Open );

   // Declare an object variable of the type to be deserialized.
   OrderedItem^ i;

   /* Use the Deserialize method to restore the object's state 
      using data from the XML document. */
   i = dynamic_cast<OrderedItem^>(serializer->Deserialize( reader ));

   // Write out the properties of the object.
   Console::Write( "{0}\t{1}\t{2}\t{3}\t{4}", i->ItemName, i->Description, i->UnitPrice, i->Quantity, i->LineTotal );
}

int main()
{
   // Write a purchase order.
   SerializeObject( "simple.xml" );
   DeserializeObject( "simple.xml" );
}
// </Snippet1>
