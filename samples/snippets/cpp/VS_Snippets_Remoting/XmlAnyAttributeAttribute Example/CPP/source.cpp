

//<Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Xml;

public ref class Group
{
public:
   String^ GroupName;

   // The UnknownAttributes array will be used to collect all unknown
   // attributes found when deserializing.

   [XmlAnyAttributeAttribute]
   array<XmlAttribute^>^XAttributes;
};

void SerializeObject( String^ filename, Object^ g )
{
   XmlSerializer^ ser = gcnew XmlSerializer( Group::typeid );
   TextWriter^ writer = gcnew StreamWriter( filename );
   ser->Serialize( writer, g );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlSerializer^ ser = gcnew XmlSerializer( Group::typeid );

   // A FileStream is needed to read the XML document.
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Group^ g = safe_cast<Group^>(ser->Deserialize( fs ));
   fs->Close();

   // Write out the data, including unknown attributes.
   Console::WriteLine( g->GroupName );
   Console::WriteLine(  "Number of unknown attributes: {0}", g->XAttributes->Length );
   for ( IEnumerator ^ e = g->XAttributes->GetEnumerator(); e->MoveNext();  )
   {
      XmlAttribute^ xAtt = safe_cast<XmlAttribute^>(e->Current);
      Console::WriteLine( "{0}: {1}", xAtt->Name, xAtt->InnerXml );
   }
   SerializeObject( "AttributesAdded.xml", g );
}

int main()
{
   // Deserialize the file containing unknown attributes.
   DeserializeObject(  "UnknownAttributes.xml" );
}

//</Snippet1>  
