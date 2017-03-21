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
   virtual void WriteXml( XmlWriter^ writer )
   {
      writer->WriteString( personName );
   }

   virtual void ReadXml( XmlReader^ reader )
   {
      personName = reader->ReadString();
   }

   virtual XmlSchema^ GetSchema()
   {
      return nullptr;
   }

   // Print
   virtual String^ ToString() override
   {
      return (personName);
   }
};