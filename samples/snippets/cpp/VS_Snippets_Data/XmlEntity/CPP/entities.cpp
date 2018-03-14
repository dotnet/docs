

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
public ref class Sample
{
public:
   static void DisplayEntities( XmlNamedNodeMap^ nMap )
   {
      for ( int i = 0; i < nMap->Count; i++ )
      {
         XmlEntity^ ent = dynamic_cast<XmlEntity^>(nMap->Item( i ));
         Console::Write( " {0} ", ent->NodeType );
         Console::Write( " {0} ", ent->Name );
         Console::Write( " {0} ", ent->NotationName );
         Console::Write( " {0} ", ent->PublicId );
         Console::Write( " {0} ", ent->SystemId );
         Console::WriteLine();

      }
   }

};

int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "doment.xml" );
   Console::WriteLine( "Display information on all entities..." );
   XmlNamedNodeMap^ nMap = doc->DocumentType->Entities;
   Sample^ MySample = gcnew Sample;
   MySample->DisplayEntities( nMap );
}

//</snippet1>
