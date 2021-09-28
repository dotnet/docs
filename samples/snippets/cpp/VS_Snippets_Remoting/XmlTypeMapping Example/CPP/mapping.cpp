

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Collections;
using namespace System::Xml;
using namespace System::Text;

public ref class Thing
{
public:
   String^ ThingName;
};

[SoapType("TheGroup","http://www.cohowinery.com")]
public ref class Group
{
public:
   String^ GroupName;
   array<Thing^>^Things;

   [SoapElement(DataType="language")]
   static String^ Lang = "en";

   [SoapElement(DataType="integer")]
   String^ MyNumber;

   [SoapElement(DataType="duration")]
   static String^ ReDate = "8/31/01";
};

void GetMap( String^ filename )
{
   // Create an XmlSerializer instance.
   SoapReflectionImporter^ sri = gcnew SoapReflectionImporter;
   XmlTypeMapping^ map = sri->ImportTypeMapping( Group::typeid );
   Console::WriteLine( "ElementName: {0}", map->ElementName );
   Console::WriteLine( "Namespace: {0}", map->Namespace );
   Console::WriteLine( "TypeFullName: {0}", map->TypeFullName );
   Console::WriteLine( "TypeName: {0}", map->TypeName );
   XmlSerializer^ ser = gcnew XmlSerializer( map );
   Group^ xGroup = gcnew Group;
   xGroup->GroupName = "MyCar";
   xGroup->MyNumber = "5454";
   xGroup->Things = gcnew array<Thing^>(2); // {new Thing(), new Thing()};
   xGroup->Things[ 0 ] = gcnew Thing;
   xGroup->Things[ 1 ] = gcnew Thing;

   // To write the outer wrapper, use an XmlTextWriter.
   XmlTextWriter^ writer = gcnew XmlTextWriter( filename,Encoding::UTF8 );
   writer->Formatting = Formatting::Indented;
   writer->WriteStartElement( "wrapper" );
   ser->Serialize( writer, xGroup );
   writer->WriteEndElement();
   writer->Close();
}

int main()
{
   GetMap( "MyMap.xml" );
}
//</Snippet1>
