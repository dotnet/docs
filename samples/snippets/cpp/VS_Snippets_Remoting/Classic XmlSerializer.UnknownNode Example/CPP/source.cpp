

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Group
{
public:

   // Only the GroupName field will be known.
   String^ GroupName;
};

public ref class Test
{
public:
   static void main()
   {
      Test^ t = gcnew Test;
      t->DeserializeObject( "UnknownNodes.xml" );
   }

private:
   void DeserializeObject( String^ filename )
   {
      XmlSerializer^ mySerializer = gcnew XmlSerializer( Group::typeid );
      FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
      mySerializer->UnknownNode += gcnew XmlNodeEventHandler( this, &Test::serializer_UnknownNode );
      Group^ myGroup = dynamic_cast<Group^>(mySerializer->Deserialize( fs ));
      fs->Close();
   }

private:
   void serializer_UnknownNode( Object^ /*sender*/, XmlNodeEventArgs^ e )
   {
      Console::WriteLine( "UnknownNode Name: {0}", e->Name );
      Console::WriteLine( "UnknownNode LocalName: {0}", e->LocalName );
      Console::WriteLine( "UnknownNode Namespace URI: {0}", e->NamespaceURI );
      Console::WriteLine( "UnknownNode Text: {0}", e->Text );
      XmlNodeType myNodeType = e->NodeType;
      Console::WriteLine( "NodeType: {0}", myNodeType );
      Group^ myGroup = dynamic_cast<Group^>(e->ObjectBeingDeserialized);
      Console::WriteLine( "GroupName: {0}", myGroup->GroupName );
      Console::WriteLine();
   }
};

int main()
{
   Test::main();
}

/* Paste this XML into a file named UnknownNodes:
<?xml version="1.0" encoding="utf-8"?>
<Group xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 

xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:coho = "http://www.cohowinery.com" 

xmlns:cp="http://www.cpandl.com">
   <coho:GroupName>MyGroup</coho:GroupName>
   <cp:GroupSize>Large</cp:GroupSize>
   <cp:GroupNumber>444</cp:GroupNumber>
   <coho:GroupBase>West</coho:GroupBase>
   <coho:ThingInfo>
      <Number>1</Number>
      <Name>Thing1</Name>
      <Elmo>
         <Glue>element</Glue>
      </Elmo>
   </coho:ThingInfo>
</Group>
*/
// </Snippet1>
