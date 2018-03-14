

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Xml;

// Apply the XmlRootAttribute and set the IsNullable property to false.

[XmlRoot(IsNullable=false)]
public ref class Group
{
public:
   String^ Name;
};

void SerializeObject( String^ filename )
{
   XmlSerializer^ s = gcnew XmlSerializer( Group::typeid );

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create the object to serialize.
   Group^ mygroup = nullptr;

   // Serialize the object, and close the TextWriter.
   s->Serialize( writer, mygroup );
   writer->Close();
}

int main()
{
   Console::WriteLine( "Running" );
   SerializeObject( "NullDoc.xml" );
}
// </Snippet1>
