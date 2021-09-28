

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Schema;

public ref class Group
{
public:

   [XmlAttributeAttribute(Namespace="http://www.cpandl.com")]
   String^ GroupName;

   [XmlAttributeAttribute(DataType="base64Binary")]
   array<Byte>^GroupNumber;

   [XmlAttributeAttribute(DataType="date",AttributeName="CreationDate")]
   DateTime Today;
};

void SerializeObject( String^ filename )
{
   // Create an instance of the XmlSerializer class.
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Group::typeid );

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create an instance of the class that will be serialized.
   Group^ myGroup = gcnew Group;

   // Set the object properties.
   myGroup->GroupName = ".NET";
   array<Byte>^hexByte = {Convert::ToByte( 100 ),Convert::ToByte( 50 )};
   myGroup->GroupNumber = hexByte;
   DateTime myDate = DateTime(2001,1,10);
   myGroup->Today = myDate;

   // Serialize the class, and close the TextWriter.
   mySerializer->Serialize( writer, myGroup );
   writer->Close();
}

int main()
{
   SerializeObject( "Attributes.xml" );
}
// </Snippet1>
