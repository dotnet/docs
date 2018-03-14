

//<Snippet1>
#using <System.dll>
#using <System.xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Xml;
public ref class Group
{
public:
   String^ GroupName;

   [XmlAnyElement]
   array<Object^>^Things;
};

void SerializeObject( String^ filename );
void DeserializeObject( String^ filename );
XmlSerializer^ CreateOverrideSerializer();
int main()
{
   // 1 Run this and create the XML document.
   // 2 Add new elements to the XML document.
   // 3 Comment out the next line, and uncomment
   // the DeserializeObject line to deserialize the
   // XML document and see unknown elements.
   SerializeObject( "UnknownElements.xml" );

   // DeserializeObject(S"UnknownElements.xml");
}

void SerializeObject( String^ filename )
{
   XmlSerializer^ ser = gcnew XmlSerializer( Group::typeid );
   TextWriter^ writer = gcnew StreamWriter( filename );
   Group^ g = gcnew Group;
   g->GroupName = "MyGroup";
   ser->Serialize( writer, g );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlSerializer^ ser = CreateOverrideSerializer();

   // A FileStream is needed to read the XML document.
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Group^ g = safe_cast<Group^>(ser->Deserialize( fs ));
   fs->Close();
   Console::WriteLine( g->GroupName );
   Console::WriteLine( g->Things->Length );
   for ( int i = 0; i < g->Things->Length; ++i )
   {
      XmlElement^ xelement = safe_cast<XmlElement^>(g->Things[ i ]);
      Console::WriteLine( "{0}: {1}", xelement->Name, xelement->InnerXml );
   }
}

XmlSerializer^ CreateOverrideSerializer()
{
   XmlAnyElementAttribute^ myAnyElement = gcnew XmlAnyElementAttribute;
   XmlAttributeOverrides^ xOverride = gcnew XmlAttributeOverrides;
   XmlAttributes^ xAtts = gcnew XmlAttributes;
   xAtts->XmlAnyElements->Add( myAnyElement );
   xOverride->Add( Group::typeid, "Things", xAtts );
   return gcnew XmlSerializer( Group::typeid,xOverride );
}
//</Snippet1>  
