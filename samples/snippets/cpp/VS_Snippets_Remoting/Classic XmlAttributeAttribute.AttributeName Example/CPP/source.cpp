

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Group
{
public:

   // Change the XML attribute name.

   [XmlAttributeAttribute(AttributeName="MgrName")]
   String^ Name;
   /* Use the AttributeName to collect all the XML attributes
      in the XML-document instance. */
};

void SerializeObject( String^ filename )
{
   Console::WriteLine( "Serializing" );

   // Create an instance of the XmlSerializer class.
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Group::typeid );

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create an instance of the class that will be serialized.
   Group^ myGroup = gcnew Group;

   /* Set the Name property, which will be generated
      as an XML attribute. */
   myGroup->Name = "Wallace";

   // Serialize the class, and close the TextWriter.
   mySerializer->Serialize( writer, myGroup );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   Console::WriteLine( "Deserializing" );
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Group::typeid );
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Group^ myGroup = dynamic_cast<Group^>(mySerializer->Deserialize( fs ));
   Console::WriteLine( myGroup->Name );
}

int main()
{
   /* To use the AttributeName to collect all the
      XML attributes. Call SerializeObject to generate 
      an XML document and alter the document by adding
      new XML attributes to it. Then comment out the SerializeObject
      method, and call DeserializeObject. */
   SerializeObject( "MyAtts.xml" );
   DeserializeObject( "MyAtts.xml" );
}
// </Snippet1>
