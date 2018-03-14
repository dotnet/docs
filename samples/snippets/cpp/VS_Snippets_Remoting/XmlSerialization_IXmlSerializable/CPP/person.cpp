

// <snippet0>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Xml::Serialization;
public ref class Person: public IXmlSerializable
{
private:

   // Private state
   String^ personName;

public:

   // Constructors
   Person( String^ name )
   {
      personName = name;
   }

   Person()
   {
      personName = nullptr;
   }

   // Xml Serialization Infrastructure
   // <snippet1>
   virtual void WriteXml( XmlWriter^ writer )
   {
      writer->WriteString( personName );
   }
   // </snippet1>

   // <snippet2>
   virtual void ReadXml( XmlReader^ reader )
   {
      personName = reader->ReadString();
   }
   // </snippet2>

   // <snippet3>
   virtual XmlSchema^ GetSchema()
   {
      return nullptr;
   }
   // </snippet3>

   // Print
   virtual String^ ToString() override
   {
      return (personName);
   }
};
// </snippet0>
