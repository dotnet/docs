#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Sample
{
   // <Snippet1>
private:
   void SerializeObject( String^ filename )
   {
      XmlSerializer^ serializer =
         gcnew XmlSerializer( OrderedItem::typeid );

      // Create an instance of the class to be serialized.
      OrderedItem^ i = gcnew OrderedItem;

      // Set the public property values.
      i->ItemName = "Widget";
      i->Description = "Regular Widget";
      i->Quantity = 10;
      i->UnitPrice = (Decimal)2.30;

      // Writing the document requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );

      // Serialize the object, and close the TextWriter.
      serializer->Serialize( writer, i );
      writer->Close();
   }

public:
   // This is the class that will be serialized.
   ref class OrderedItem
   {
   public:
      String^ ItemName;
      String^ Description;
      Decimal UnitPrice;
      int Quantity;
   };
   // </Snippet1>
};
