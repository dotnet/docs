

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
void DisplayNotations( XmlNamedNodeMap^ nMap )
{
   for ( int i = 0; i < nMap->Count; i++ )
   {
      XmlNotation^ note = dynamic_cast<XmlNotation^>(nMap->Item( i ));
      Console::Write( " {0} ", note->NodeType );
      Console::Write( " {0} ", note->Name );
      Console::Write( " {0} ", note->PublicId );
      Console::Write( " {0} ", note->SystemId );
      Console::WriteLine();

   }
}

int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "doment.xml" );
   Console::WriteLine( "Display information on all notations..." );
   XmlNamedNodeMap^ nMap = doc->DocumentType->Notations;
   DisplayNotations( nMap );
}

//</snippet1>
