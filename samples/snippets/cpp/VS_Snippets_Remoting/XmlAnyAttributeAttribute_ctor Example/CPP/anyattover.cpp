

//<Snippet1>
#using <System.dll>
#using <System.XML.dll>

using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Xml;
public ref class Group
{
public:
   String^ GroupName;

   // The Things array will be used to collect all unknown
   // attributes found when deserializing.
   array<XmlAttribute^>^Things;
};

XmlSerializer^ CreateOverrideSerializer();
void DeserializeObject( String^ filename )
{
   // Use the CreateOverrideSerializer to return an instance
   // of the XmlSerializer customized for overrides.
   XmlSerializer^ ser = CreateOverrideSerializer();

   // A FileStream is needed to read the XML document.
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Group^ g = safe_cast<Group^>(ser->Deserialize( fs ));
   fs->Close();
   Console::WriteLine( g->GroupName );
   Console::WriteLine( g->Things->Length );
   for ( IEnumerator ^ e = g->Things->GetEnumerator(); e->MoveNext();  )
   {
      XmlAttribute^ xAtt = safe_cast<XmlAttribute^>(e->Current);
      Console::WriteLine( "{0}: {1}", xAtt->Name, xAtt->InnerXml );
   }
}

XmlSerializer^ CreateOverrideSerializer()
{
   // Override the Things field to capture all
   // unknown XML attributes.
   XmlAnyAttributeAttribute^ myAnyAttribute = gcnew XmlAnyAttributeAttribute;
   XmlAttributeOverrides^ xOverride = gcnew XmlAttributeOverrides;
   XmlAttributes^ xAtts = gcnew XmlAttributes;
   xAtts->XmlAnyAttribute = myAnyAttribute;
   xOverride->Add( Group::typeid, "Things", xAtts );
   return gcnew XmlSerializer( Group::typeid,xOverride );
}

int main()
{
   DeserializeObject(  "UnknownAttributes.xml" );
}
//</Snippet1>  
