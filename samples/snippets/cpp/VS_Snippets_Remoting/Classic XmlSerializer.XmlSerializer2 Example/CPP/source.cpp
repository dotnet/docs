#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Class1
{
   // <Snippet1>
private:
   void SerializeObject( String^ filename )
   {
      // Create an XmlRootAttribute, and set its properties.
      XmlRootAttribute^ xRoot = gcnew XmlRootAttribute;
      xRoot->ElementName = "CustomRoot";
      xRoot->Namespace = "http://www.cpandl.com";
      xRoot->IsNullable = true;

      // Construct the XmlSerializer with the XmlRootAttribute.
      XmlSerializer^ serializer = gcnew XmlSerializer(
         OrderedItem::typeid,xRoot );

      // Create an instance of the object to serialize.
      OrderedItem^ i = gcnew OrderedItem;
      // Insert code to set properties of the ordered item.

      // Writing the document requires a TextWriter.
      TextWriter^ writer = gcnew StreamWriter( filename );
      serializer->Serialize( writer, i );
      writer->Close();
   }

   void DeserializeObject( String^ filename )
   {
      // Create an XmlRootAttribute, and set its properties.
      XmlRootAttribute^ xRoot = gcnew XmlRootAttribute;
      xRoot->ElementName = "CustomRoot";
      xRoot->Namespace = "http://www.cpandl.com";
      xRoot->IsNullable = true;

      XmlSerializer^ serializer = gcnew XmlSerializer(
         OrderedItem::typeid,xRoot );

      // A FileStream is needed to read the XML document.
      FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
      // Deserialize the object.
      OrderedItem^ i = dynamic_cast<OrderedItem^>(serializer->Deserialize( fs ));
      // Insert code to use the object's properties and methods.
   }
   // </Snippet1>

public:
   ref class OrderedItem{
      // Members of OrderedItem go here
   };
};
