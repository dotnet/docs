

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
   String^ ItemName;
   String^ Description;
   Decimal UnitPrice;
   int Quantity;
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

   // Create a FileStream to write with.
   Stream^ writer = gcnew FileStream( filename,FileMode::Create );

   // Serialize the object, and close the TextWriter
   serializer->Serialize( writer, i );
   writer->Close();
}

int main()
{
   // Write a purchase order.
   SerializeObject( "simple.xml" );
}
// </Snippet1>
