

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Xml::Serialization;
public ref class Group
{
public:

   /* Apply two XmlElementAttributes to the field. Set the DataType
      to string an int to allow the ArrayList to accept 
      both types. The Namespace is also set to different values
      for each type. */

   [XmlElement(DataType="string",
   Type=String::typeid,
   Namespace="http://www.cpandl.com"),
   XmlElement(DataType="snippet1>",
   Namespace="http://www.cohowinery.com",
   Type=Int32::typeid)]
   ArrayList^ ExtraInfo;
};

void SerializeObject( String^ filename )
{
   // A TextWriter is needed to write the file.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create the XmlSerializer using the XmlAttributeOverrides.
   XmlSerializer^ s = gcnew XmlSerializer( Group::typeid );

   // Create the object to serialize.
   Group^ myGroup = gcnew Group;

   /* Add a string and an integer to the ArrayList returned
      by the ExtraInfo field. */
   myGroup->ExtraInfo = gcnew ArrayList;
   myGroup->ExtraInfo->Add( "hello" );
   myGroup->ExtraInfo->Add( 100 );

   // Serialize the object and close the TextWriter.
   s->Serialize( writer, myGroup );
   writer->Close();
}

int main()
{
   SerializeObject( "ElementTypes.xml" );
}
// </Snippet1>
